using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace みどく.Modes.Search.Kanji
{
	public class KanjiSearch
	{
		public static void SearchList(List<Word> words, string kanji)
		{
			List<Word> wordsContainingKanji = words.FindAll(word => word.WordEntry.Contains(kanji));

			PrintList(wordsContainingKanji, kanji);
		}

		private static void PrintList(List<Word> words, string kanji)
		{
			Console.WriteLine($"=======  {kanji} found in {words.Count} word(s)  =======");
			foreach (var item in words)
			{
				Console.WriteLine(item.WordEntry);
			}
		}
	}
}
