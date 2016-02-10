using LacunaExpanse.BaseServices;
using LacunaExpanse.Windows.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using System.Threading.Tasks;
using LacunaExpanse.WinPhone.Services;
using Xamarin;

[assembly: Xamarin.Forms.Dependency(typeof(FileServiceWin81))]
namespace LacunaExpanse.WinPhone.Services
{
	public class FileServiceWin81 : IStorageService
	{
		public async Task<byte[]> ReadBytes(string path)
		{
			byte[] bytes = new byte[0];

			try
			{
				using (var fs = File.Open(path, FileMode.Open, FileAccess.Read)) // new FileStream(path, FileMode.Open))
				{
					bytes = new byte[fs.Length];
					await fs.ReadAsync(bytes, 0, (int)fs.Length);
				}
			}
			catch (Exception ex)
			{
				Insights.Report(ex, Insights.Severity.Error);
				throw;
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
					Debug.WriteLine("Unable to delete: " + path);
					return false;
				}
			});
		}

		public string MyDocumentsPath
		{
			get { return ApplicationData.Current.LocalFolder.Path; }
		}

		public Stream GetFileReadStream(string path)
		{
			return File.OpenRead(path);
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
				Debug.WriteLine(ex.ToString());
				return false;
			}
		}
	}
}
