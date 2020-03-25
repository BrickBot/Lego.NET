using System;
using System.IO;
using System.Windows.Forms;

namespace SetPath
{
	public class SetSettings
	{
		public SetSettings()
		{
		}

		static void Main(string[] args)
		{	
			if (args.Length > 2)
			{
				string file = args[0];
				string oldValue = args[1];
				string newValue = args[2];

				if (File.Exists(file))
				{
					StreamReader SR = File.OpenText(file);
					string content = SR.ReadToEnd();
					content = content.Replace(oldValue, newValue);
					SR.Close();
					StreamWriter SW = File.CreateText(file);
					SW.Write(content);
					SW.Close();
				}
				else
				{
					Console.WriteLine("File: %1 does not exist.", file);
				}
			}
			else
			{
				Console.WriteLine("This program was only used for installing LEGO .NET .");
			}
		}
	}
}
