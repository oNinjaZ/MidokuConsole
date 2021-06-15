using System;

namespace みどく
{
	class Program
	{
		static void Main(string[] args)
		{
			User ninjaz = new();
			ninjaz.LoadMenu();
			Console.WriteLine();
			string input = string.Empty;
			bool searchMode = true;
			bool kanjiMode = false;
			bool runProgram = true;
			do
			{
				while (searchMode)
				{
					input = Console.ReadLine();
					if (input == "kanji")
					{
						searchMode = false;
						kanjiMode = true;
						Console.WriteLine("switched to kanji mode");
					}
					else if (input == "list")
					{
						ninjaz.PrintCards();
					}
					else if (input == "listmode")
					{
						みどく.Settings.ListView.SetViewMode();
					}
					else if (input == "exit")
					{
						searchMode = false;
						runProgram = false;
					}
					else if (input == "del")
					{
						ninjaz.Del();
					}
					else if (input == "menu")
					{
						Console.WriteLine("\nSaving....");
						ninjaz.ExportData();
					}
					else
					{
						ninjaz.Search(input);
					}
				}
				while (kanjiMode)
				{
					input = Console.ReadLine();
					if (input == "search")
					{
						searchMode = true;
						kanjiMode = false;
						Console.WriteLine("switched to search mode");
					}
					else if (input == "exit")
					{
						kanjiMode = false;
						runProgram = false;
					}
					else if (input == "menu")
					{
						Console.WriteLine("\nSaving....");
						ninjaz.ExportData();
					}
					else if (input == "list")
					{
						ninjaz.PrintCards();
					}
					else
					{
						ninjaz.SearchKanji(input);
					}
				}
			} while (runProgram);
		}
	}
}
