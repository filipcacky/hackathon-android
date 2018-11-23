using System.Threading.Tasks;
using Newtonsoft.Json;
using WifiPi.Mobile.Backend.WebService;
using WifiPi.Mobile.Models;

namespace WifiPi.Mobile.Backend.Managers
{
	public class StatisticsManager
	{
		public async Task<StatisticsItem[]> GetTodayStatisticForDevice(string guid)
		{
			var repo = new WebRepository();
			var path = WebRepository.Paths.BasePath(guid) + WebRepository.Paths.Today;

			var data = await repo.GetFileFromUrl(path);
			var dataAsJson = DataManager.ReadMemoryToString(data);

			return JsonConvert.DeserializeObject<StatisticsItem[]>(dataAsJson);
		}

		public async Task<StatisticsItem[]> GetWeeklyStatisticsForDevice(string guid)
		{
			var repo = new WebRepository();
			var path = WebRepository.Paths.BasePath(guid) + WebRepository.Paths.Today;

			var data = await repo.GetFileFromUrl(path);
			var dataAsJson = DataManager.ReadMemoryToString(data);

			return JsonConvert.DeserializeObject<StatisticsItem[]>(dataAsJson);
		}

		public async Task<StatisticsItem[]> GetMonthlyStatisticsForDevice(string guid)
		{
			var repo = new WebRepository();
			var path = WebRepository.Paths.BasePath(guid) + WebRepository.Paths.Today;

			var data = await repo.GetFileFromUrl(path);
			var dataAsJson = DataManager.ReadMemoryToString(data);

			return JsonConvert.DeserializeObject<StatisticsItem[]>(dataAsJson);
		}

		public async Task<StatisticsItem> GetNowStatisticsForDevice(string guid)
		{
			var repo = new WebRepository();
			var path = WebRepository.Paths.BasePath(guid) + WebRepository.Paths.Now;

			var data = await repo.GetFileFromUrl(path);
			var dataAsJson = DataManager.ReadMemoryToString(data);

			return JsonConvert.DeserializeObject<StatisticsItem>(dataAsJson);
		}

	}
}