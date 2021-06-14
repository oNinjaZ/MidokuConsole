using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using みどく.Settings;

namespace みどく.List.Sort
{
	public class SortBy
	{

		private delegate List<Word> SortSelection(List<Word> words);

		public static void SortList(List<Word> words)
		{
			var sortSetting = ListView.LoadViewMode();

			switch (sortSetting)
			{
				// sorts by frequency
				case "1":
					SortBySelected(words, list => list.OrderBy(word => word.TimesSeen).ToList());
					break;
				// sorts by most recent
				case "2":
					SortBySelected(words, list => list.OrderBy(word => word.LastSeenDate).ToList());
					break;
				default:

					break;
			}
		}
		private static void SortBySelected(List<Word> words, SortSelection sort)
		{
			var sortedList = sort(words);
			Display.PrintSortedList.ListItems(sortedList);
		}

	}
}
