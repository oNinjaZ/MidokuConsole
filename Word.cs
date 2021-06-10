﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using きどく.Statistics.Word;

namespace きどく
{
	public class Word
	{
		public string WordEntry { get; set; }
		public int TimesSeen { get; set; }
		public DateTime LastSeenDate { get; set; }
		public DateTime FirstSeenDate { get; set; }

		public string FirstSeen
		{
			get
			{
				return Seen.RelativeDate(FirstSeenDate);
			}
		}

		public string LastSeen
		{
			get
			{
				return Seen.RelativeDate(LastSeenDate);
			}
		}

		public Word()
		{
		}
		public Word(string word)
		{
			this.WordEntry = word;
			this.TimesSeen = 1;
			LastSeenDate = DateTime.Now;
			FirstSeenDate = DateTime.Now;
		}
	}
}
