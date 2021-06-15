using System;
using System.Collections.Generic;
using みどく.Settings;

namespace みどく.List.Display
{
	public class PrintSortedList
	{
		public static void ListItems(List<Word> words)
		{
			Console.WriteLine("\n======================================================\n");
			foreach (var word in words)
			{
				Console.WriteLine($"{word.WordEntry}  ({word.LastSeen})  {word.TimesSeen}x  {(!string.IsNullOrWhiteSpace(word.Note) ? $"-  {word.Note}" : "")}");
			}
			Console.WriteLine($"\n=======  Count: {words.Count}  |  By {ListView.currentSetting}  ========\n\n");
		}
	}
}
