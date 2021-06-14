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

		public static void WriteNewPath(string fileName)
		{
			fileName += "data.txt";
			StreamWriter sw = new(fileName);
			sw.Close();
		}

		public static void WriteWords(Collection list, string fileName)
		{
			fileName += "data.txt";
			StreamWriter sw = new(fileName);
			foreach (var item in list.Words)
			{
				var dateToStr = item.LastSeenDate.ToBinary().ToString();
				var firstSeenDate = item.FirstSeenDate.ToBinary().ToString();
				sw.WriteLine($"{item.WordEntry},{item.TimesSeen},{dateToStr},{firstSeenDate}");
			}
			sw.Close();
		}

	}
}
