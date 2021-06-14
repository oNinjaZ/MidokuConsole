using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace みどく.Editor
{
	public class Delete
	{

		public static void DelWord(List<Word> words)
		{
			Console.WriteLine("Enter words to delete (separated by spaces)...");
			List<string> input = GetWordsToDelete();
			List<string> sucessfullyDeleted = new();
			List<string> notFound = new();
			foreach (var item in input)
			{
				if (words.Any(word => word.WordEntry == item))
				{
					sucessfullyDeleted.Add(item);
					words.Remove(words.Find(w => w.WordEntry == item));
				}
				else
				{
					notFound.Add(item);
				}
			}
			Console.WriteLine();
			if (sucessfullyDeleted.Any())
			{
				ShowDeleted(sucessfullyDeleted);
			}
			if (notFound.Any())
			{
				ShowNotFound(notFound);
			}
		}
		private static List<string> GetWordsToDelete()
		{
			return Console.ReadLine().Split(" ").ToList();
		}

		private static void ShowDeleted(List<string> deleted)
		{
			Console.Write($"{deleted.Count} deleted: [");
			foreach (var word in deleted)
			{
				Console.Write($"({deleted})");
			}
			Console.WriteLine("]");
		}

		private static void ShowNotFound(List<string> notFound)
		{
			Console.Write($"{notFound.Count} not found: [");
			foreach (var missing in notFound)
			{
				Console.Write($"({missing})");
			}
			Console.WriteLine("]");
		}


	}
}
