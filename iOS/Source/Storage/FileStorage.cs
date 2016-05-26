using System;
using System.IO;
using Foundation;

namespace FitCalculator.iOS
{
	public class FileStorage: IStorage
	{
		private string docsPath {
			get {
				return Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
			}
		}

		public FileStorage ()
		{
		}

		public bool WriteFile (string name, string content)
		{
			var path = Path.Combine (docsPath, name);
			var str = NSString.FromObject (content) as NSString;
			var data = str.Encode (NSStringEncoding.UTF8);
			var result = data.Save (path, true);
			System.Diagnostics.Debug.WriteLine (string.Format("Write: {0}", result));
			return result;
		}

		public string ReadFile (string name)
		{
			var path = Path.Combine (docsPath, name);
			var data = NSData.FromFile (path);
			var str = NSString.FromData (data, NSStringEncoding.UTF8);
			System.Diagnostics.Debug.WriteLine (string.Format("Read: {0}", str));
			return str;
		}
	}
}

