using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LacunaExpanse.BaseServices;
using LacunaExpanse.Droid.Services;
using System.Threading.Tasks;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(FileServiceAndroid))]
namespace LacunaExpanse.Droid.Services
{
	class FileServiceAndroid : IStorageService
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
				catch
				{
					//Debug.WriteLine("Unable to delete: " + path);
					return false;
				}
			});
		}

		public string MyDocumentsPath { get { return System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments); } }


		public Stream GetFileReadStream(string path)
		{
			return System.IO.File.OpenRead(path);
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
					stream.Seek(0, SeekOrigin.Begin);
					stream.CopyTo(fileStream);
				}
				return true;
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.ToString());
				return false;
			}
		}
	}
}