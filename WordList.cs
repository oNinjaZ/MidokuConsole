using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace みどく
{
	public class WordList
	{
		public int WordCount
		{
			get
			{
				return Words.Count;
			}
		}
		public List<Word> Words { get; }

		public WordList()
		{
			Words = new();
		}
	}
}
