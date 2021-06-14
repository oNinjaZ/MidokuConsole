using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace みどく.List.Display
{
	public class PrintSortedList
	{
		public static void ListItems(List<Word> words)
		{
			Console.WriteLine();
			foreach (var item in words)
			{
				Console.WriteLine($"{item.WordEntry} (Seen {item.LastSeen}) {item.TimesSeen}x");
			}
			Console.WriteLine($"\n=======  Count: {words.Count}  ========\n\n");
		}
	}
}
