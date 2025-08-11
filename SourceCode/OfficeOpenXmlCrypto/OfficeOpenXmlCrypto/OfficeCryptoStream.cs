using System;
using System.IO;

namespace OfficeOpenXmlCrypto
{
	public class OfficeCryptoStream : MemoryStream
	{
		private byte[] HeaderEncrypted = new byte[] { 208, 207, 17, 224, 161, 177, 26, 225 };

		private byte[] HeaderPlaintext = new byte[] { 80, 75, 3, 4 };

		private string _password;

		private Stream _storage;

		public bool Encrypted
		{
			get
			{
				return !string.IsNullOrEmpty(this._password);
			}
		}

		public string Password
		{
			get
			{
				return this._password;
			}
			set
			{
				if (!base.CanWrite || !base.CanSeek)
				{
					throw new InvalidOperationException("Cannot set password. Underlying stream does not support seek or write. Make sure it was not closed.");
				}
				this._password = value;
			}
		}

		private OfficeCryptoStream(string file, FileMode mode, string password) : this(new FileStream(file, mode), password)
		{
		}

		public OfficeCryptoStream(Stream storageStream, string password)
		{
			this._storage = storageStream;
			this.Password = password;
			if (storageStream.Length == (long)0)
			{
				return;
			}
			bool flag = OfficeCryptoStream.ContainsHeader(storageStream, this.HeaderPlaintext);
			bool flag1 = OfficeCryptoStream.ContainsHeader(storageStream, this.HeaderEncrypted);
			if (!flag && !flag1)
			{
				this.Close();
				throw new FileFormatException("File is neither plaintext package nor Office 2007 encrypted.");
			}
			byte[] array = new byte[storageStream.Length];
			storageStream.Read(array, 0, (int)array.Length);
			if (flag1)
			{
				if (string.IsNullOrEmpty(this.Password))
				{
					this.Close();
					throw new InvalidPasswordException("Password not provided.");
				}
				try
				{
					array = (new OfficeCrypto()).DecryptToArray(array, password);
				}
				catch (Exception exception)
				{
					this.Close();
					throw;
				}
			}
			base.Write(array, 0, (int)array.Length);
			base.Flush();
			base.Position = (long)0;
		}

		public override void Close()
		{
			base.Close();
			this._storage.Close();
		}

		private static bool ContainsHeader(Stream s, byte[] header)
		{
			bool flag;
			long position = s.Position;
			try
			{
				byte[] numArray = header;
				int num = 0;
				while (num < (int)numArray.Length)
				{
					byte num1 = numArray[num];
					if (s.ReadByte() == num1)
					{
						num++;
					}
					else
					{
						flag = false;
						return flag;
					}
				}
				return true;
			}
			finally
			{
				s.Position = position;
			}
			return flag;
		}

		public static OfficeCryptoStream Create(string newFile)
		{
			return new OfficeCryptoStream(newFile, FileMode.Create, null);
		}

		public static OfficeCryptoStream Open(string file)
		{
			return OfficeCryptoStream.Open(file, null);
		}

		public static OfficeCryptoStream Open(string file, string password)
		{
			if (!File.Exists(file))
			{
				throw new FileNotFoundException("", file);
			}
			return new OfficeCryptoStream(file, FileMode.Open, password);
		}

		public void Save()
		{
			this._storage.Seek((long)0, SeekOrigin.Begin);
			this._storage.SetLength((long)0);
			this._storage.Position = (long)0;
			if (!this.Encrypted)
			{
				base.WriteTo(this._storage);
				return;
			}
			OfficeCrypto officeCrypto = new OfficeCrypto();
			officeCrypto.EncryptToStream(base.ToArray(), this.Password, this._storage);
		}

		public void SaveAs(string filename)
		{
			this._storage.Close();
			this._storage = new FileStream(filename, FileMode.CreateNew);
			this.Save();
		}

		public static bool TryOpen(string file, string password, out OfficeCryptoStream stream)
		{
			bool flag;
			stream = null;
			try
			{
				stream = OfficeCryptoStream.Open(file, password);
				return true;
			}
			catch (InvalidPasswordException invalidPasswordException)
			{
				flag = false;
			}
			return flag;
		}
	}
}