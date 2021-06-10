using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace きどく
{
	public static class KanjiSearch
	{
		public static void SearchList(WordList list, string kanji)
		{
			List<Word> wordsContainingKanji = new();
			foreach (var word in list.Words)
			{
				if (word.WordEntry.Contains(kanji))
				{
					wordsContainingKanji.Add(word);
				}
			}
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
