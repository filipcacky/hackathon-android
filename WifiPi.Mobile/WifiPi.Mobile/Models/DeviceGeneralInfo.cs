using WifiPi.Mobile.Models.SubModels;

namespace WifiPi.Mobile.Models
{
	public class DeviceGeneralInfo
	{
		public string Guid { get; set; }
		public string Name { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public string Web { get; set; }
		public string Info { get; set; }
	}
}