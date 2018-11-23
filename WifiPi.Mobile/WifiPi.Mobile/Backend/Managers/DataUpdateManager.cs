using System.Threading.Tasks;
using WifiPi.Mobile.Backend.WebService;

namespace WifiPi.Mobile.Backend.Managers
{
	public class DataUpdateManager
	{
		/// <summary>
		/// DeviceGeneralInfo[]
		/// </summary>
		/// <returns></returns>
		public async Task<byte[]> GetAllGeneralData()
		{
			var repo = new WebRepository();
			var path = WebRepository.Paths.All;

			var data = await repo.GetFileFromUrl(path);

			return data;
		}

		public async Task<byte[]> GetSpecificGeneralData(string guid)
		{
			var repo = new WebRepository();
			var path = WebRepository.Paths.BasePath(guid);

			var data = await repo.GetFileFromUrl(path);

			return data;
		}

		public async Task<byte[]> GetTodayStatisticForDevice(string guid)
		{
			var repo = new WebRepository();
			var path = WebRepository.Paths.BasePath(guid) + WebRepository.Paths.Today;

			var data = await repo.GetFileFromUrl(path);

			return data;
		}

		public async Task<byte[]> GetWeeklyStatisticsForDevice(string guid)
		{
			var repo = new WebRepository();
			var path = WebRepository.Paths.BasePath(guid) + WebRepository.Paths.Week;

			var data = await repo.GetFileFromUrl(path);

			return data;
		}

		public async Task<byte[]> GetMonthlyStatisticsForDevice(string guid)
		{
			var repo = new WebRepository();
			var path = WebRepository.Paths.BasePath(guid) + WebRepository.Paths.Month;

			var data = await repo.GetFileFromUrl(path);

			return data;
		}

		public async Task<byte[]> GetNowStatisticsForDevice(string guid)
		{
			var repo = new WebRepository();
			var path = WebRepository.Paths.BasePath(guid) + WebRepository.Paths.Now;

			var data = await repo.GetFileFromUrl(path);

			return data;
		}

		public async Task<byte[]> GetEventsDataForDevice(string guid)
		{
			var repo = new WebRepository();
			var path = WebRepository.Paths.BasePath(guid) + WebRepository.Paths.Events;

			var data = await repo.GetFileFromUrl(path);

			return data;
		}

	}
}