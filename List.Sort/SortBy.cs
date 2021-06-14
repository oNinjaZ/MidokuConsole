using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace みどく.List.Sort
{
	public class SortBy
	{
		public static void Frequency(List<Word> words)
		{
			List<Word> sortedList = words.OrderBy(word => word.TimesSeen).ToList();
			Display.PrintSortedList.ListItems(sortedList);
		}

		public static void Recent(List<Word> words)
		{
			List<Word> sortedList = words.OrderBy(word => word.LastSeenDate).ToList();
			Display.PrintSortedList.ListItems(sortedList);
		}
	}
}
