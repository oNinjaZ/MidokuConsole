using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace みどく.Data.Processor
{
	public class Write
	{

		public static void WritePaths(List<string> paths)
		{
			StreamWriter sw = new("savedBooks.txt");
			foreach (var item in paths)
			{
				sw.WriteLine(item);
			}
			sw.Close();
		}

		public static void WriteNewDataPath(string fileName)
		{
			StreamWriter sw = new(fileName);
			sw.Close();
		}

		public static void SaveWords(List<Word> words, string fileName)
		{
			StreamWriter sw = new(fileName);
			foreach (var item in words)
			{
				var dateToStr = item.LastSeenDate.ToBinary().ToString();
				var firstSeenDate = item.FirstSeenDate.ToBinary().ToString();
				sw.WriteLine($"{item.WordEntry},{item.TimesSeen},{dateToStr},{firstSeenDate}");
			}
			sw.Close();
		}

	}
}
