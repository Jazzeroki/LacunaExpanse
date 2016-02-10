using LacunaExpanse.BaseServices;
using LacunaExpanse.iOS.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(FileStorageServiceiOS))]
namespace LacunaExpanse.iOS.Services
{
	public class FileStorageServiceiOS : IStorageService
	{
		public async Task<byte[]> ReadBytes(string path)
		{
			byte[] bytes = new byte[0];

			using (var fs = new FileStream(path, FileMode.Open))
			{
				bytes = new byte[fs.Length];
				await fs.ReadAsync(bytes, 0, (int)fs.Length);
			}

			return bytes;
		}

		public async Task<bool> Delete(string path)
		{
			return await Task.Run(() =>
			{
				try
				{
					System.IO.File.Delete(path);
					return true;
				}
				catch (Exception ex)
				{
					Debug.WriteLine("Unable to delete: " + path);
					return false;
				}
			});
		}

		public string MyDocumentsPath { get { return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); } }

		public Stream GetFileReadStream(string path)
		{
			return File.Open(path, FileMode.Open, FileAccess.Read);
		}


		public long GetFileSize(string path)
		{
			var info = new FileInfo(path);
			return info.Length;
		}

		public bool SaveStream(Stream stream, string path)
		{
			try
			{
				using (var fileStream = System.IO.File.OpenWrite(path))
				{
					Debug.WriteLine("SavePath: " + path);
					stream.Seek(0, SeekOrigin.Begin);
					stream.CopyTo(fileStream);
				}
				return true;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
				return false;
			}
		}
	}
}
