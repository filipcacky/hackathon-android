using System.Threading.Tasks;
using WifiPi.Mobile.Models;

namespace WifiPi.Mobile.Backend.Managers
{
	public class DeviceGeneralInfoManager
	{
		public async Task<DeviceGeneralInfo[]> GetAll(bool force = false)
		{
			if (DataManager.AllDevices == null && !force)
			{
				var manager = new DataManager();
				return await manager.DownloadGeneralInfo();
			}
			else
			{
			return DataManager.AllDevices;
			}
		}
	}
}