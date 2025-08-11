using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Base
{
    public class HashProvider
    {
        private string _algorithm;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithm">SHA1 MD5 SHA-256 SHA-384 SHA-512</param>
        public HashProvider(string algorithm)
        {
            _algorithm = string.IsNullOrEmpty(algorithm) ? "SHA1" : algorithm.ToUpper();
        }
        public string ComputeHash(string file)
        {
            if (File.Exists(file))
            {
                byte[] bytes = ComputeHashFile(file);
                return ToHexadecimal(bytes);
            }
            else
            {
                throw new Exception("File not found");
            }
        }
        public string ComputeHash(byte[] content)
        {
            using (var hasher = HashAlgorithm.Create(_algorithm))
                return ToHexadecimal(hasher.ComputeHash(content));
        }
        public byte[] ComputeHashToByte(byte[] content)
        {
            using (var hasher = HashAlgorithm.Create(_algorithm))
                return hasher.ComputeHash(content);
        }
        private byte[] ComputeHashFile(string file)
        {
            //using (var hasher = HashAlgorithm.Create(_algorithm))
            //{
            //    using (var stream = new FileStream(file, FileMode.Open))
            //    {
            //        return hasher.ComputeHash(stream);
            //    }
            //}
            using (var hasher = HashAlgorithm.Create(_algorithm))
            {
                using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    return hasher.ComputeHash(stream);
                }
            }
        }
        private string ToHexadecimal(byte[] source)
        {
            if (source == null) return string.Empty;

            StringBuilder sb = new StringBuilder();

            foreach (byte b in source)
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
