﻿using System;
using System.Collections.Generic;
using System.Linq;
using みどく.Data;

namespace みどく
{
	public class User
	{
		public WordList Words { get; set; }
		public List<string> SavedFilePaths { get; set; }
		public string FilePath { get; set; }

		public User()
		{
			Words = new();
			SavedFilePaths = new();
		}

		public void SearchWord(string searchedWord)
		{
			if (Words.Words.Any(word => word.WordEntry == searchedWord))
			{
				FetchWord(searchedWord);
			}
			else
			{
				//Console.WriteLine($"\n{searchedWord} not found...\nAdd to word list? (y/n)");
				//string answer = Console.ReadLine();
				//switch (answer.ToUpper())
				//{
				//	case "Y":
				//		AddWord(searchedWord);
				//		break;
				//	case "N":
				//		Console.WriteLine("");
				//		break;
				//	default:
				//		break;
				//}
				AddWord(searchedWord);
			}
		}
		private void FetchWord(string searchedWord)
		{
			var word = Words.Words.Find(word => word.WordEntry == searchedWord);
			word.TimesSeen++;
			PrintWordInfo(word);
			word.LastSeenDate = DateTime.Now;
		}


		private void AddWord(string newWord)
		{
			Words.Words.Add(new Word(newWord));
			Console.WriteLine($"\n[{newWord}] added");
		}

		public void delWord()
		{
			Console.WriteLine("Enter words to delete (separated by spaces)...");
			List<string> input = GetWordsToDelete();
			List<string> sucessfullyDeleted = new();
			List<string> notFound = new();
			foreach (var item in input)
			{
				if (Words.Words.Any(word => word.WordEntry == item))
				{
					sucessfullyDeleted.Add(item);
					Words.Words.Remove(Words.Words.Find(w => w.WordEntry == item));
				}
				else
				{
					notFound.Add(item);
				}
			}
			Console.WriteLine();
			if(sucessfullyDeleted.Any())
			{
				Console.Write($"{sucessfullyDeleted.Count} deleted: [");
				foreach (var deleted in sucessfullyDeleted)
				{
					Console.Write($"({deleted})");
				}
				Console.WriteLine("]");
			}
			if (notFound.Any())
			{
				Console.Write($"{notFound.Count} not found: [");
				foreach (var missing in notFound)
				{
					Console.Write($"({missing})");
				}
				Console.WriteLine("]");
			}
		}

		private List<string> GetWordsToDelete()
		{
			return Console.ReadLine().Split(" ").ToList();
		}

		private static void PrintWordInfo(Word word)
		{
			Console.WriteLine($"\nFirst seen: {word.FirstSeen}\n" +
				$"Last seen: {word.LastSeen}\n" +
				$"Frequency: {word.TimesSeen}x");
		}



		public void PrintCards()
		{
			Console.WriteLine($"\n=======  Count: {Words.WordCount}  ========");
			foreach (var item in Words.Words)
			{
				Console.WriteLine($"{item.WordEntry} (Seen {item.LastSeen}) {item.TimesSeen}x");
			}
		}

		public void SearchKanji(string kanji)
		{
			KanjiSearch.SearchList(Words, kanji);
		}



		public void ExportData()
		{
			DataProcessor.WritePaths(SavedFilePaths);
			DataProcessor.Write(Words, FilePath);
			Words = new();
			SavedFilePaths.Clear();
			LoadData();
		}

		public void delBookLog()
		{
			Console.WriteLine("enter book log to delete");
			string input = Console.ReadLine();
			if (SavedFilePaths.Any(name => name == input))
			{
				SavedFilePaths.Remove(input);
				DataProcessor.WritePaths(SavedFilePaths);
				Words = new();
				SavedFilePaths.Clear();
				LoadData();
			}
			else
			{
				Console.WriteLine($"{input} doesn't exist");
			}
		}


		public void LoadData()
		{
			DataProcessor.ReadPaths(SavedFilePaths);
			if (SavedFilePaths.Count == 0)
			{
				Console.WriteLine("Enter your first book log :'D");
			}
			else
			{
				ListBooks();
			}
			string book = Console.ReadLine();
			if (book == "del")
			{
				delBookLog();
			}
			else if (SavedFilePaths.Contains(book))
			{
				string bookPath = SavedFilePaths.Find(path => path == book) + "data.txt";
				DataProcessor.Read(Words, $"{bookPath}");
				this.FilePath = book;
				Console.WriteLine($"\nきどく - {book}");
			}
			else
			{
				Console.WriteLine($"Create new log for {book}?");
				string input = Console.ReadLine();
				if (input.ToUpper() == "Y")
				{
					CreateBookPath(book);
					DataProcessor.WritePaths(SavedFilePaths);
					Console.WriteLine($"New log created for {book}!");
					this.FilePath = book;
					DataProcessor.WriteNewPath(FilePath);
					Console.WriteLine($"\nきどく - {book}");
				}
				else if (input.ToUpper() == "N")
				{
					Console.WriteLine("Returning to menu....\n");
					SavedFilePaths.Clear();
					LoadData();
				}
				else
				{
					Console.WriteLine("Invalid input...returning to menu\n");
					SavedFilePaths.Clear();
					LoadData();
				}
			}
		}

		public void CreateBookPath(string path)
		{
			SavedFilePaths.Add(path);
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
