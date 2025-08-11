using System;
using System.IO;
using System.IO.Packaging;
using System.Security.Cryptography;
using System.Text;

namespace OfficeOpenXmlCrypto
{
	public class OfficeCrypto
	{
		internal const string csEncryptionInfoStreamName = "EncryptionInfo";

		internal const string csEncryptedPackageStreamName = "EncryptedPackage";

		internal const string csNotStorage = "The file is not an OLE Storage document.";

		internal const string csNoEntry = "The file does not contain an entry called {0}.";

		internal const string csNoStream = "The file does not contain a stream called {0}.";

		internal const string csNotStream = "The entry in the file called {0} is not a stream.";

		private ushort versionMajor;

		private ushort versionMinor;

		private OfficeCrypto.EncryptionFlags encryptionFlags = OfficeCrypto.EncryptionFlags.fCryptoAPI | OfficeCrypto.EncryptionFlags.fAES;

		private uint sizeExtra;

		private OfficeCrypto.AlgId algId = OfficeCrypto.AlgId.AES128;

		private OfficeCrypto.AlgHashId algHashId = OfficeCrypto.AlgHashId.SHA1;

		private int keySize = 128;

		private OfficeCrypto.ProviderType providerType = OfficeCrypto.ProviderType.AES;

		private string CSPName = "";

		private int saltSize = 16;

		private byte[] salt;

		private byte[] encryptedVerifier;

		private int verifierHashSize = 20;

		private byte[] encryptedVerifierHash;

		private byte[] encryptedPackage;

		public OfficeCrypto()
		{
		}

		private byte[] AESDecrypt(byte[] data, byte[] key)
		{
			return this.AESDecrypt(data, 0, (int)data.Length, key);
		}

		private byte[] AESDecrypt(byte[] data, int index, int count, byte[] key)
		{
			byte[] numArray;
			byte[] numArray1 = null;
			RijndaelManaged rijndaelManaged = new RijndaelManaged()
			{
				Mode = CipherMode.ECB,
				Padding = PaddingMode.None,
				KeySize = this.keySize
			};
			ICryptoTransform cryptoTransform = rijndaelManaged.CreateDecryptor(key, null);
			using (MemoryStream memoryStream = new MemoryStream(data, index, count))
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read))
				{
					numArray1 = new byte[(int)data.Length];
					cryptoStream.Read(numArray1, 0, (int)numArray1.Length);
					numArray = numArray1;
				}
			}
			return numArray;
		}

		private byte[] AESEncrypt(byte[] data, byte[] key)
		{
			byte[] array;
			RijndaelManaged rijndaelManaged = new RijndaelManaged()
			{
				Mode = CipherMode.ECB,
				Padding = PaddingMode.None,
				KeySize = this.keySize
			};
			ICryptoTransform cryptoTransform = rijndaelManaged.CreateEncryptor(key, null);
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
				{
					cryptoStream.Write(data, 0, (int)data.Length);
					cryptoStream.FlushFinalBlock();
				}
				array = memoryStream.ToArray();
			}
			return array;
		}

		private Package CreatePackage(byte[] decryptedPackage)
		{
			Package package;
			using (MemoryStream memoryStream = this.CreateStream(decryptedPackage))
			{
				package = Package.Open(memoryStream, FileMode.Open, FileAccess.ReadWrite);
			}
			return package;
		}

		private MemoryStream CreateStream(byte[] decryptedPackage)
		{
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(decryptedPackage, 0, (int)decryptedPackage.Length);
			memoryStream.Flush();
			memoryStream.Position = (long)0;
			return memoryStream;
		}

		private void CreateVerifier(byte[] key)
		{
			byte[] v = (new RijndaelManaged()).IV;
			this.encryptedVerifier = this.AESEncrypt(v, key);
			byte[] numArray = this.SHA1Hash(v);
			byte[] numArray1 = new byte[32];
			Array.Copy(numArray, numArray1, (int)numArray.Length);
			numArray = numArray1;
			this.encryptedVerifierHash = this.AESEncrypt(numArray, key);
		}

		internal byte[] DecryptInternal(string password, byte[] encryptionInfo, byte[] encryptedPackage)
		{
			using (MemoryStream memoryStream = new MemoryStream(encryptionInfo))
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				this.versionMajor = binaryReader.ReadUInt16();
				this.versionMinor = binaryReader.ReadUInt16();
				this.encryptionFlags = (OfficeCrypto.EncryptionFlags)binaryReader.ReadUInt32();
				if (this.encryptionFlags == OfficeCrypto.EncryptionFlags.fExternal)
				{
					throw new Exception("An external cryptographic provider is not supported");
				}
				uint num = binaryReader.ReadUInt32();
				binaryReader.ReadInt32();
				num -= 4;
				this.sizeExtra = binaryReader.ReadUInt32();
				num -= 4;
				this.algId = (OfficeCrypto.AlgId)binaryReader.ReadUInt32();
				num -= 4;
				this.algHashId = (OfficeCrypto.AlgHashId)binaryReader.ReadUInt32();
				num -= 4;
				this.keySize = binaryReader.ReadInt32();
				num -= 4;
				this.providerType = (OfficeCrypto.ProviderType)binaryReader.ReadUInt32();
				num -= 4;
				binaryReader.ReadUInt32();
				num -= 4;
				binaryReader.ReadUInt32();
				num -= 4;
				this.CSPName = Encoding.Unicode.GetString(binaryReader.ReadBytes((int)num));
				this.saltSize = binaryReader.ReadInt32();
				this.salt = binaryReader.ReadBytes(this.saltSize);
				this.encryptedVerifier = binaryReader.ReadBytes(16);
				this.verifierHashSize = binaryReader.ReadInt32();
				this.encryptedVerifierHash = binaryReader.ReadBytes((this.providerType == OfficeCrypto.ProviderType.RC4 ? 20 : 32));
			}
			Console.WriteLine("Encryption key generation");
			byte[] numArray = this.GeneratePasswordHashUsingSHA1(password);
			if (numArray == null)
			{
				return null;
			}
			Console.WriteLine("Password verification");
			if (!this.PasswordVerifier(numArray))
			{
				Console.WriteLine("Password verification failed");
				throw new InvalidPasswordException("The password is not valid");
			}
			Console.WriteLine("Password verification succeeded");
			long num1 = BitConverter.ToInt64(encryptedPackage, 0);
			Console.WriteLine("Decrypt the stream using the generated and validated key");
			encryptedPackage = this.AESDecrypt(encryptedPackage, 8, (int)encryptedPackage.Length - 8, numArray);
			byte[] numArray1 = encryptedPackage;
			if ((long)((int)encryptedPackage.Length) > num1)
			{
				numArray1 = new byte[num1];
				Array.Copy(encryptedPackage, numArray1, (int)numArray1.Length);
			}
			return numArray1;
		}

		public byte[] DecryptToArray(string filename, string password)
		{
			Console.WriteLine("Open the storage");
			return this.DecryptToArray(new OleStorage(filename), password);
		}

		public byte[] DecryptToArray(byte[] contents, string password)
		{
			Console.WriteLine("Open the storage");
			return this.DecryptToArray(new OleStorage(contents), password);
		}

		public byte[] DecryptToArray(OleStorage stgRoot, string password)
		{
			this.encryptedPackage = stgRoot.ReadStream("EncryptedPackage");
			byte[] numArray = stgRoot.ReadStream("EncryptionInfo");
			return this.DecryptInternal(password, numArray, this.encryptedPackage);
		}

		public Package DecryptToPackage(string filename, string password)
		{
			return this.CreatePackage(this.DecryptToArray(filename, password));
		}

		public Package DecryptToPackage(byte[] contents, string password)
		{
			return this.CreatePackage(this.DecryptToArray(contents, password));
		}

		public Package DecryptToPackage(OleStorage stgRoot, string password)
		{
			return this.CreatePackage(this.DecryptToArray(stgRoot, password));
		}

		public MemoryStream DecryptToStream(string filename, string password)
		{
			return this.CreateStream(this.DecryptToArray(filename, password));
		}

		public MemoryStream DecryptToStream(byte[] contents, string password)
		{
			return this.CreateStream(this.DecryptToArray(contents, password));
		}

		public MemoryStream DecryptToStream(OleStorage stgRoot, string password)
		{
			return this.CreateStream(this.DecryptToArray(stgRoot, password));
		}

		private byte[] DeriveKey(byte[] hashValue)
		{
			byte[] numArray = new byte[64];
			for (int i = 0; i < (int)numArray.Length; i++)
			{
				numArray[i] = (byte)((i < (int)hashValue.Length ? 54 ^ hashValue[i] : 54));
			}
			byte[] numArray1 = this.SHA1Hash(numArray);
			if (this.verifierHashSize > this.keySize / 8)
			{
				return numArray1;
			}
			for (int j = 0; j < (int)numArray.Length; j++)
			{
				numArray[j] = (byte)((j < (int)hashValue.Length ? 92 ^ hashValue[j] : 92));
			}
			byte[] numArray2 = this.SHA1Hash(numArray);
			byte[] numArray3 = new byte[(int)numArray1.Length + (int)numArray2.Length];
			Array.Copy(numArray1, 0, numArray3, 0, (int)numArray1.Length);
			Array.Copy(numArray1, 0, numArray3, (int)numArray1.Length, (int)numArray2.Length);
			return numArray3;
		}

		public void EncryptPackage(string filename, string password, out byte[] encryptionInfo, out byte[] encryptedPackage)
		{
			if (!File.Exists(filename))
			{
				throw new ArgumentException("Package file does not exist");
			}
			byte[] numArray = null;
			using (FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			{
				numArray = new byte[fileStream.Length];
				fileStream.Read(numArray, 0, (int)numArray.Length);
			}
			this.EncryptPackage(numArray, password, out encryptionInfo, out encryptedPackage);
		}
        public void EncryptPackage(byte[] packageContents, string password, out byte[] encryptionInfo, out byte[] encryptedPackage)
		{
			this.versionMajor = 3;
			this.versionMinor = 2;
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			this.saltSize = 16;
			byte[] numArray = this.SHA1Hash(rijndaelManaged.IV);
			rijndaelManaged = null;
			this.verifierHashSize = (int)numArray.Length;
			this.salt = new byte[this.saltSize];
			Array.Copy(numArray, this.salt, this.saltSize);
			byte[] numArray1 = this.GeneratePasswordHashUsingSHA1(password);
			this.CreateVerifier(numArray1);
			int length = (int)packageContents.Length;
			int num = (int)packageContents.Length % 16;
			if (num != 0)
			{
				byte[] numArray2 = new byte[(int)packageContents.Length + 16 - num];
				Array.Copy(packageContents, numArray2, (int)packageContents.Length);
				packageContents = numArray2;
			}
			byte[] numArray3 = this.AESEncrypt(packageContents, numArray1);
			encryptedPackage = new byte[(int)numArray3.Length + 8];
			Array.Copy(BitConverter.GetBytes((long)length), encryptedPackage, 8);
			Array.Copy(numArray3, 0, encryptedPackage, 8, (int)numArray3.Length);
			byte[] array = null;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				binaryWriter.Write((int)this.encryptionFlags);
				binaryWriter.Write((int)this.sizeExtra);
				binaryWriter.Write((int)this.algId);
				binaryWriter.Write((int)this.algHashId);
				binaryWriter.Write(this.keySize);
				binaryWriter.Write((int)this.providerType);
				binaryWriter.Write(new byte[] { 160, 199, 220, 2, 0, 0, 0, 0 });
				binaryWriter.Write(Encoding.Unicode.GetBytes("Microsoft Enhanced RSA and AES Cryptographic Provider (Prototype)\0"));
				memoryStream.Flush();
				array = memoryStream.ToArray();
			}
			byte[] array1 = null;
			using (MemoryStream memoryStream1 = new MemoryStream())
			{
				BinaryWriter binaryWriter1 = new BinaryWriter(memoryStream1);
				binaryWriter1.Write((int)this.salt.Length);
				binaryWriter1.Write(this.salt);
				binaryWriter1.Write(this.encryptedVerifier);
				binaryWriter1.Write(this.verifierHashSize);
				binaryWriter1.Write(this.encryptedVerifierHash);
				memoryStream1.Flush();
				array1 = memoryStream1.ToArray();
			}
			using (MemoryStream memoryStream2 = new MemoryStream())
			{
				BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2);
				binaryWriter2.Write(this.versionMajor);
				binaryWriter2.Write(this.versionMinor);
				binaryWriter2.Write((int)this.encryptionFlags);
				binaryWriter2.Write((int)array.Length);
				binaryWriter2.Write(array);
				binaryWriter2.Write(array1);
				memoryStream2.Flush();
				encryptionInfo = memoryStream2.ToArray();
			}
		}

		public static bool EncryptPackageFile(string filename, string password, out byte[] encryptionInfo, out byte[] encryptedPackage)
		{
			bool flag;
			OfficeCrypto officeCrypto = new OfficeCrypto();
			encryptionInfo = null;
			encryptedPackage = null;
			try
			{
				officeCrypto.EncryptPackage(filename, password, out encryptionInfo, out encryptedPackage);
				Console.WriteLine("Package encrypted");
				officeCrypto.TestEncrytion(password, encryptionInfo, encryptedPackage);
				flag = true;
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.Message);
				return false;
			}
			return flag;
		}

		public void EncryptToFile(byte[] packageContents, string password, string encryptedFilename)
		{
			byte[] numArray;
			byte[] numArray1;
			this.EncryptPackage(packageContents, password, out numArray, out numArray1);
			OleStorage oleStorage = new OleStorage();
			oleStorage.WriteStream("EncryptionInfo", numArray);
			oleStorage.WriteStream("EncryptedPackage", numArray1);
			oleStorage.Save(encryptedFilename);
		}

		public void EncryptToStream(byte[] packageContents, string password, Stream encryptedStream)
		{
			byte[] numArray;
			byte[] numArray1;
			this.EncryptPackage(packageContents, password, out numArray, out numArray1);
			OleStorage oleStorage = new OleStorage();
			oleStorage.WriteStream("EncryptionInfo", numArray);
			oleStorage.WriteStream("EncryptedPackage", numArray1);
			oleStorage.Save(encryptedStream);
		}

		private byte[] GeneratePasswordHashUsingSHA1(string password)
		{
			byte[] numArray;
			byte[] numArray1 = null;
			try
			{
				numArray1 = this.SHA1Hash(this.salt, password);
				for (int i = 0; i < 50000; i++)
				{
					numArray1 = this.SHA1Hash(i, numArray1);
				}
				numArray1 = this.SHA1Hash(numArray1, 0);
				byte[] numArray2 = this.DeriveKey(numArray1);
				byte[] numArray3 = new byte[this.keySize / 8];
				Array.Copy(numArray2, numArray3, (int)numArray3.Length);
				numArray = numArray3;
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.Message);
				return null;
			}
			return numArray;
		}

		private byte[] HashPassword(byte[] salt, string password)
		{
			byte[] bytes = Encoding.Unicode.GetBytes(password);
			byte[] numArray = new byte[(int)salt.Length + (int)bytes.Length];
			Array.Copy(salt, numArray, (int)salt.Length);
			Array.Copy(bytes, 0, numArray, (int)salt.Length, (int)bytes.Length);
			return numArray;
		}

		public static Package OfficePasswordHash(string filename, string password)
		{
			Package package;
			OfficeCrypto officeCrypto = new OfficeCrypto();
			try
			{
				Package package1 = officeCrypto.DecryptToPackage(filename, password);
				Console.WriteLine("Package decrypted and opened");
				package = package1;
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.Message);
				return null;
			}
			return package;
		}

		private bool PasswordVerifier(byte[] key)
		{
			byte[] numArray = this.AESDecrypt(this.encryptedVerifier, key);
			byte[] numArray1 = new byte[16];
			Array.Copy(numArray, numArray1, (int)numArray1.Length);
			numArray = numArray1;
			byte[] numArray2 = this.AESDecrypt(this.encryptedVerifierHash, key);
			byte[] numArray3 = this.SHA1Hash(numArray);
			for (int i = 0; i < (int)numArray3.Length; i++)
			{
				if (numArray2[i] != numArray3[i])
				{
					return false;
				}
			}
			return true;
		}

		private byte[] SHA1Hash(byte[] salt, string password)
		{
			return this.SHA1Hash(this.HashPassword(salt, password));
		}

		private byte[] SHA1Hash(int iterator, byte[] hashBuf)
		{
			byte[] numArray = new byte[24];
			Array.Copy(BitConverter.GetBytes(iterator), numArray, 4);
			Array.Copy(hashBuf, 0, numArray, 4, (int)hashBuf.Length);
			return this.SHA1Hash(numArray);
		}

		private byte[] SHA1Hash(byte[] hashBuf, int block)
		{
			byte[] numArray = new byte[24];
			Array.Copy(hashBuf, numArray, (int)hashBuf.Length);
			Array.Copy(BitConverter.GetBytes(block), 0, numArray, (int)hashBuf.Length, 4);
			return this.SHA1Hash(numArray);
		}

		private byte[] SHA1Hash(byte[] hashBuf, byte[] block0)
		{
			byte[] numArray = new byte[(int)hashBuf.Length + (int)block0.Length];
			Array.Copy(hashBuf, numArray, (int)hashBuf.Length);
			Array.Copy(block0, 0, numArray, (int)hashBuf.Length, (int)block0.Length);
			return this.SHA1Hash(numArray);
		}

		private byte[] SHA1Hash(byte[] inputBuffer)
		{
			return SHA1.Create().ComputeHash(inputBuffer);
		}

		private bool TestAES()
		{
			byte[] numArray = new byte[] { 0, 1, 2, 3, 5, 6, 7, 8, 10, 11, 12, 13, 15, 16, 17, 18 };
			byte[] numArray1 = this.AESEncrypt(new byte[] { 80, 104, 18, 164, 95, 8, 200, 137, 185, 127, 89, 128, 3, 139, 131, 89 }, numArray);
			numArray1 = this.AESDecrypt(numArray1, numArray);
			return true;
		}

		public void TestEncrytion(string password, byte[] encryptionInfo, byte[] encryptedPackage)
		{
			this.DecryptInternal(password, encryptionInfo, encryptedPackage);
		}

		private bool TestSHA1()
		{
			string str = "The quick brown fox jumps over the lazy dog";
			byte[] numArray = new byte[] { 47, 212, 225, 198, 122, 45, 40, 252, 237, 132, 158, 225, 187, 118, 231, 57, 27, 147, 235, 18 };
			byte[] numArray1 = this.SHA1Hash(Encoding.ASCII.GetBytes(str));
			for (int i = 0; i < (int)numArray1.Length; i++)
			{
				if (numArray1[i] != numArray[i])
				{
					return false;
				}
			}
			return true;
		}

		private enum AlgHashId
		{
			Any = 0,
			RC4 = 32768,
			SHA1 = 32772
		}

		private enum AlgId
		{
			ByFlags = 0,
			AES128 = 26126,
			AES192 = 26127,
			AES256 = 26128,
			RC4 = 26625
		}

		[Flags]
		private enum EncryptionFlags
		{
			None = 0,
			Reserved1 = 1,
			Reserved2 = 2,
			fCryptoAPI = 4,
			fDocProps = 8,
			fExternal = 16,
			fAES = 32
		}

		private enum ProviderType
		{
			Any = 0,
			RC4 = 1,
			AES = 24
		}
	}
}