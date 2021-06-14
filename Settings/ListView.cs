using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace みどく.Settings
{
	public class ListView
	{
		public static string currentSetting
		{
			get
			{
				if (LoadViewMode() == "1")
				{
					return "Frequency";
				}
				else
				{
					return "Recent";
				}
			}
		}

		public static string LoadViewMode()
		{
			if (File.Exists("settings.txt"))
			{
				string viewMode = string.Empty;
				StreamReader sr = new("settings.txt");
				while (sr.ReadLine() is string s)
				{
					viewMode = s;
				}
				sr.Close();
				return viewMode;
			}
			else
			{
				StreamWriter st = new("settings.txt");
				st.WriteLine("1");
				st.Close();
				return "1";
			}
		}

		public static void SetViewMode()
		{
			string option = string.Empty;
			if (ViewModeOptions(ref option))
			{
				StreamWriter st = new("settings.txt");
				st.WriteLine(option);
				st.Close();
				SetMessage(option);
			}

		}

		private static void SetMessage(string newSetting)
		{
			switch (newSetting)
			{
				case "1":
					newSetting = "Frequency";
					break;
				default:
					newSetting = "Recent";
					break;
			}
			Console.WriteLine($"Now displaying lists by {newSetting}");
		}

		private static bool ViewModeOptions(ref string option)
		{
			Console.WriteLine("======  Sort Settings  ======\n\n" +
				"Sort lists by...\n" +
				"1 - Frequency\n" +
				"2 - Recent");

			string input = Console.ReadLine();
			if (input == "1" || input == "2")
			{
				option = input;
				return true;
			}
			else
			{
				Console.WriteLine("Invalid input... enter 1 or 2");
				return false;
			}
		}
	}
}
