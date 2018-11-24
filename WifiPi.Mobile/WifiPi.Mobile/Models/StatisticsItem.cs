using System;
using System.Collections.Generic;
using System.Text;

namespace WifiPi.Mobile.Models
{
	public class StatisticsItem
	{
		public DateTime Day { get; set; }
		public float Average { get; set; }

		public int HourLbl { get; set; }
		public int MinuteLbl { get; set; }

		public StatisticsItem[] Hours { get; set; }
	}
}
