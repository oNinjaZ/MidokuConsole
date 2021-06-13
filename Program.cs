using System;

namespace みどく
{
	class Program
	{
		static void Main(string[] args)
		{
			User ninjaz = new();
			ninjaz.LoadData();
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
					else if (input == "exit")
					{
						searchMode = false;
						runProgram = false;
					}
					else if (input == "del")
					{
						ninjaz.delWord();
					}
					else if (input == "menu")
					{
						Console.WriteLine("Saving....");
						ninjaz.ExportData();
					}
					else
					{
						ninjaz.SearchWord(input);
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
						Console.WriteLine("Saving....");
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
