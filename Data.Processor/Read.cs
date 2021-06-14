using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace みどく.Data.Processor
{
	class Read
	{

		public static void ReadPaths(List<string> paths)
		{
			if (File.Exists("savedBooks.txt"))
			{
				StreamReader sr = new("savedBooks.txt");
				while (sr.ReadLine() is string s)
				{
					paths.Add(s);
				}
				sr.Close();
			}
			else
			{
				StreamWriter sw = new("savedBooks.txt");
				sw.Close();
			}
		}

		public static void ReadWords(Collection list, string fileName)
		{
			string[] data;
			StreamReader sr = new(fileName);
			while (sr.ReadLine() is string s)
			{
				data = s.Split(",").ToArray();
				DateTime date = DateTime.FromBinary(long.Parse(data[2]));
				DateTime FirstSeenDate = DateTime.FromBinary(long.Parse(data[3]));
				list.Words.Add(new Word { WordEntry = data[0], TimesSeen = int.Parse(data[1]), LastSeenDate = date, FirstSeenDate = FirstSeenDate });
			}
			sr.Close();
		}

	}
}
