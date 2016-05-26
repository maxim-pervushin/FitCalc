using System;
using Android.Content;
using Java.IO;
using System.IO;
using System.Text;

namespace FitCalculator.Droid
{
	public class FileStorage: IStorage
	{
		private Context context;

		public FileStorage (Context context)
		{
			this.context = context;
		}

		public bool WriteFile (string name, string content)
		{
			try {
				var writer = new OutputStreamWriter (context.OpenFileOutput (name, FileCreationMode.Private));
				writer.Write (content);
				writer.Close ();
				return true;

			} catch (Exception) {
				return false;
			}
		}

		public string ReadFile (string name)
		{
			try {
				var input = context.OpenFileInput (name);
				var inputReader = new InputStreamReader (input);
				var reader = new BufferedReader (inputReader);
				var str = "";
				var builder = new StringBuilder ();

				while ((str = reader.ReadLine ()) != null) {
					builder.Append (str);
				}
				input.Close ();
				return builder.ToString ();

			} catch (Exception) {
				return "";
			}
		}
	}
}

