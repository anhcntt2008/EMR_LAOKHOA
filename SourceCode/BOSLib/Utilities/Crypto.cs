using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;


namespace BOSLib
{
    public class Crypto
    {
        #region Enums, Constants & Fields
        public enum CryptoTypes
        {
            DES,
            RC2,
            Rijndael,
            TripleDES
        }

        private const string CRYPT_DEFAULT_PASSWORD = "abc123";
        private const CryptoTypes CRYPT_DEFAULT_METHOD = CryptoTypes.Rijndael;

        private byte[] mKey = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
        private byte[] mIV = { 65, 110, 68, 26, 69, 178, 200, 219 };
        private byte[] SaltByteArray = { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };
        private CryptoTypes mCryptoType = CRYPT_DEFAULT_METHOD;
        private string mPassword = CRYPT_DEFAULT_PASSWORD;
        #endregion

        #region Properties
        public CryptoTypes CryptoType
        {
            get { return mCryptoType; }

            set
            {
                if (mCryptoType != value)
                {
                    mCryptoType = value;
                    CalculateNewKeyAndIV();
                }
            }
        }
        public string Password
        {
            get { return mPassword; }

            set
            {
                if (mPassword != value)
                {
                    mPassword = value;
                    CalculateNewKeyAndIV();
                }
            }
        }
        #endregion

        #region Constructors
        public Crypto()
        {
            CalculateNewKeyAndIV();
        }

        public Crypto(CryptoTypes CryptoType)
        {
            this.CryptoType = CryptoType;
        }
        #endregion

        #region Encryption
        public string Encrypt(string inputText)
        {
            UTF8Encoding UTF8Encoder = new UTF8Encoding();
            byte[] inputBytes = UTF8Encoder.GetBytes(inputText);
            return Convert.ToBase64String(EncryptDecrypt(inputBytes, true));
        }

        public string Encrypt(string inputText, string password)
        {
            this.Password = password;
            return this.Encrypt(inputText);
        }

        public string Encrypt(string inputText, string password, CryptoTypes cryptoType)
        {
            this.mCryptoType = cryptoType;
            this.Password = password;
            return this.Encrypt(inputText);
        }

        #endregion

        #region Decryption
        public string Decrypt(string inputText)
        {
            UTF8Encoding UTF8Encoder = new UTF8Encoding();
            byte[] inputBytes = Convert.FromBase64String(inputText);
            return UTF8Encoder.GetString(EncryptDecrypt(inputBytes, false));
        }

        public string Decrypt(string inputText, string password)
        {
            this.Password = password;
            return Decrypt(inputText);
        }

        public string Decrypt(string inputText, string password, CryptoTypes cryptoType)
        {
            this.mCryptoType = cryptoType;
            this.Password = password;
            return Decrypt(inputText);
        }

        //[DDCan] [ADD] [21/05/2013] [Encrypt user id and password of database], START
        /// <summary>
        /// DeCrypt a string using dual encryption method. Return a DeCrypted clear string
        /// </summary>
        /// <param name="cipherString">encrypted string</param>
        /// <param name="useHashing">Did you use hashing to encrypt this data? pass true is yes</param>
        /// <returns></returns>
        public string DecryptNew(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            //Get your key from config file to open the lock!
            //System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            //string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
            string key = "DFHLASDLFDFSDHFSDFSLFDHFHLHKKJSJDSKLAFJKLASDJFKLSDFJKLASDJFKLDSK233434LAS998998899FDSAKFJS";

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        //[DDCan] [ADD] [21/05/2013] [Encrypt user id and password of database], END

        #endregion

        #region Symmetric Engine
        private byte[] EncryptDecrypt(byte[] inputBytes, bool Encrpyt)
        {
            ICryptoTransform transform = GetCryptoTransform(Encrpyt);
            MemoryStream memStream = new MemoryStream();

            try
            {
                CryptoStream cryptStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write);

                cryptStream.Write(inputBytes, 0, inputBytes.Length);

                cryptStream.FlushFinalBlock();

                byte[] output = memStream.ToArray();

                cryptStream.Close();

                return output;
            }
            catch (Exception e)
            {
                throw new Exception("Error in symmetric engine. Error : " + e.Message, e);
            }
        }

        private ICryptoTransform GetCryptoTransform(bool encrypt)
        {
            SymmetricAlgorithm SA = SelectAlgorithm();
            SA.Key = mKey;
            SA.IV = mIV;
            if (encrypt)
            {
                return SA.CreateEncryptor();
            }
            else
            {
                return SA.CreateDecryptor();
            }
        }

        private SymmetricAlgorithm SelectAlgorithm()
        {
            SymmetricAlgorithm SA;
            switch (mCryptoType)
            {
                case CryptoTypes.DES:
                    SA = DES.Create();
                    break;
                case CryptoTypes.RC2:
                    SA = RC2.Create();
                    break;
                case CryptoTypes.Rijndael:
                    SA = Rijndael.Create();
                    break;
                case CryptoTypes.TripleDES:
                    SA = TripleDES.Create();
                    break;
                default:
                    SA = TripleDES.Create();
                    break;
            }
            return SA;
        }

        private void CalculateNewKeyAndIV()
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(mPassword, SaltByteArray);
            SymmetricAlgorithm algo = SelectAlgorithm();
            mKey = pdb.GetBytes(algo.KeySize / 8);
            mIV = pdb.GetBytes(algo.BlockSize / 8);
        }

        #endregion
    }

}


