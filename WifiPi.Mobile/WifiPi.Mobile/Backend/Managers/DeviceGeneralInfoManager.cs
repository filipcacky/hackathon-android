using WifiPi.Mobile.Models;

namespace WifiPi.Mobile.Backend.Managers
{
	public class DeviceGeneralInfoManager
	{
		public DeviceGeneralInfo[] GetAll()
		{
			return DataManager.AllDevices;
		}
	}
}