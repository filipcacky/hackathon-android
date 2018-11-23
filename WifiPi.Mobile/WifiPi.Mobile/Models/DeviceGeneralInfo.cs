﻿namespace WifiPi.Mobile.Models
{
	public class DeviceGeneralInfo
	{
		public string Guid { get; set; }
		public string Name { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public string Website { get; set; }
		public string Info { get; set; }
		public TypeEnum PlaceType { get; set; } = TypeEnum.other;
		public int UserCount { get; set; }
	}
}