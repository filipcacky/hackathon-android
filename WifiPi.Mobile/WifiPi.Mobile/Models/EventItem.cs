using System;
using System.Collections.Generic;
using System.Text;

namespace WifiPi.Mobile.Models
{
	public class EventItem
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public TypeEnum PlaceType { get; set; }
		public string Description { get; set; }
		public string DeviceGuid { get; set; }
		public string Date { get; set; }
	}
}
