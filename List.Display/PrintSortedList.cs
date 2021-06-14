using System;
using System.Collections.Generic;
using みどく.Settings;

namespace みどく.List.Display
{
	public class PrintSortedList
	{
		public static void ListItems(List<Word> words)
		{
			Console.WriteLine("\n");
			foreach (var item in words)
			{
				Console.WriteLine($"{item.WordEntry} (Seen {item.LastSeen}) {item.TimesSeen}x");
			}
			Console.WriteLine($"\n=======  Count: {words.Count}  |  By {ListView.currentSetting}  ========\n\n");
		}
	}
}
