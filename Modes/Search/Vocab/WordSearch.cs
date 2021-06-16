using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace みどく.Modes.Search.Vocab
{
	public class WordSearch
	{

		public static void Find(List<Word> words, string searchedWord)
		{
			var word = words.Find(word => word.WordEntry == searchedWord);
			if (word != null)
			{
				UpdateOnSeen(word);
			}
			else
			{
				AddWordToList(words, searchedWord);
			}
		}

		private static void UpdateOnSeen(Word word)
		{
			word.TimesSeen++;
			PrintWordInfo(word);
			word.LastSeenDate = DateTime.Now;
		}

		private static void AddWordToList(List<Word> words, string newWord)
		{
			Console.WriteLine("Enter note (Optional)... or press Enter to continue");
			string note = Console.ReadLine();
			if (string.IsNullOrWhiteSpace(note))
			{
				words.Add(new Word(newWord, ""));
			}
			else
			{
				words.Add(new Word(newWord, note));
			}
			Console.WriteLine($"\n[{newWord}] added");
		}

		private static void PrintWordInfo(Word word)
		{
			Console.WriteLine($"\nFirst seen: {word.FirstSeen}\n" +
				$"Last seen: {word.LastSeen}\n" +
				$"Frequency: {word.TimesSeen}x");
		}

	}
}
