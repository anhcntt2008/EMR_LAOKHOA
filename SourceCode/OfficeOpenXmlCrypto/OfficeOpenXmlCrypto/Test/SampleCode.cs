using OfficeOpenXmlCrypto;
using System;
using System.IO;

namespace OfficeOpenXmlCrypto.Test
{
	public static class SampleCode
	{
		public static void AccessEncryptedFile()
		{
			using (OfficeCryptoStream officeCryptoStream = OfficeCryptoStream.Open("a.xlsx", "password"))
			{
				SampleCode.DoStuff(officeCryptoStream);
				officeCryptoStream.Save();
			}
		}

		public static void AccessEncryptedFileManualSave()
		{
			OfficeCryptoStream officeCryptoStream = OfficeCryptoStream.Open("a.xlsx", "password");
			SampleCode.DoStuff(officeCryptoStream);
			officeCryptoStream.Save();
			officeCryptoStream.Close();
		}

		public static void AccessPlaintextFile()
		{
			using (OfficeCryptoStream officeCryptoStream = OfficeCryptoStream.Open("a.xlsx"))
			{
				SampleCode.DoStuff(officeCryptoStream);
				officeCryptoStream.Save();
			}
		}

		public static void CreateEncryptedFile()
		{
			using (OfficeCryptoStream officeCryptoStream = OfficeCryptoStream.Create("a.xlsx"))
			{
				SampleCode.DoStuff(officeCryptoStream);
				officeCryptoStream.Password = "password";
				officeCryptoStream.Save();
			}
		}

		public static void DoStuff(Stream stream)
		{
		}

		public static OfficeCryptoStream OpenPasswordProtectedFile(string file)
		{
			string str = null;
			OfficeCryptoStream officeCryptoStream = null;
			while (!OfficeCryptoStream.TryOpen(file, str, out officeCryptoStream))
			{
				Console.Write("Enter password: ");
				str = Console.ReadLine();
			}
			return officeCryptoStream;
		}
	}
}