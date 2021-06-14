using System;
using System.Collections.Generic;
using System.Linq;
using みどく.Modes.Search.Vocab;
using みどく.Modes.Search.Kanji;
using みどく.Editor;
using みどく.Data.Processor;

namespace みどく
{
	public class User
	{
		List<Word> Words { get; set; }
		public List<string> SavedFilePaths { get; set; }
		public string CurrentPath { get; set; }

		public User()
		{
			Words = new();
			SavedFilePaths = new();
		}

		public void Search(string searchedWord)
		{
			WordSearch.Find(Words, searchedWord);
		}

		public void SearchKanji(string kanji)
		{
			KanjiSearch.SearchList(Words, kanji);
		}

		public void Del()
		{
			Delete.DelWord(Words);
		}

		public void PrintCards()
		{
			List.Sort.SortBy.SortList(Words);

		}


		public void delBookLog()
		{
			Console.WriteLine("enter book log to delete");
			string input = Console.ReadLine();
			if (SavedFilePaths.Remove(input))
			{	
				Write.WritePaths(SavedFilePaths);

				LoadMenu();
			}
			else
			{
				Console.WriteLine($"{input} doesn't exist");
			}
		}

		public void ExportData()
		{
			Write.SaveWords(Words, $"{CurrentPath}data.txt");

			LoadMenu();
		}

		public void LoadMenu()
		{
			Words.Clear();
			SavedFilePaths.Clear();
			Data.Processor.Read.ReadPaths(SavedFilePaths);

			if (SavedFilePaths.Count == 0)
			{
				Console.WriteLine("Enter your first book log :'D");
			}
			else
			{
				ListBooks();
			}

			SelectBook();
		}

		private void SelectBook()
		{
			string book = Console.ReadLine();
			if (book == "del")
			{
				delBookLog();
			}
			else if (SavedFilePaths.Contains(book))
			{
				this.CurrentPath = book;
				Read.LoadWords(Words, $"{book}data.txt");
				Console.WriteLine($"\nきどく - {book}");
			}
			else
			{
				Console.WriteLine($"Create new log for {book}?");
				string input = Console.ReadLine();
				if (input.ToUpper() == "Y")
				{
					SavedFilePaths.Add(book);
					Write.WritePaths(SavedFilePaths);
					Write.WriteNewDataPath($"{book}data.txt");

					Console.WriteLine($"New log created for {book}!");

					LoadMenu();
				}
				else if (input.ToUpper() == "N")
				{
					Console.WriteLine("Returning to menu....\n");

					LoadMenu();
				}
				else
				{
					Console.WriteLine("Invalid input...returning to menu\n");

					LoadMenu();
				}
			}
		}

		private void ListBooks()
		{
			Console.WriteLine($"\n=======  Book Logs ({SavedFilePaths.Count})  =======");
			foreach (var item in SavedFilePaths)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine();
		}

	}


}
