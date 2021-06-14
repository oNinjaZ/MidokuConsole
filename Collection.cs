using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace みどく
{
	public class Collection
	{
		public int WordCount
		{
			get
			{
				return Words.Count;
			}
		}
		public List<Word> Words { get; }

		public Collection()
		{
			Words = new();
		}
	}
}
