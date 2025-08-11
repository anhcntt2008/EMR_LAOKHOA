using NPOI.POIFS.FileSystem;
using System;
using System.IO;

namespace OfficeOpenXmlCrypto
{
	public class OleStorage : POIFSFileSystem
	{
		private readonly POIFSFileSystem PoiFS;

		public OleStorage()
		{
			this.PoiFS = new POIFSFileSystem();
		}

		public OleStorage(byte[] storageBytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(storageBytes))
			{
				this.PoiFS = new POIFSFileSystem(memoryStream);
			}
		}

		public OleStorage(string filename)
		{
			if (!File.Exists(filename))
			{
				throw new FileNotFoundException("OLE Storage file does not exist", filename);
			}
			this.PoiFS = new POIFSFileSystem(new FileStream(filename, FileMode.Open));
		}

		public byte[] ReadStream(string streamName)
		{
			byte[] numArray;
			using (Stream stream = this.PoiFS.CreatePOIFSDocumentReader(streamName))
			{
				numArray = new byte[stream.Length];
				stream.Read(numArray, 0, (int)numArray.Length);
			}
			return numArray;
		}

		public void Save(string filename)
		{
			using (FileStream fileStream = new FileStream(filename, FileMode.Create))
			{
				this.Save(fileStream);
			}
		}

		public void Save(Stream encryptedStream)
		{
			this.PoiFS.WriteFileSystem(encryptedStream);
		}

		public void WriteStream(string streamName, byte[] contents)
		{
			using (Stream memoryStream = new MemoryStream(contents))
			{
				this.PoiFS.Root.CreateDocument(streamName, memoryStream);
			}
		}
	}
}