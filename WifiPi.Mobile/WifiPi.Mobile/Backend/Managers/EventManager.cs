using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WifiPi.Mobile.Backend.WebService;
using WifiPi.Mobile.Models;

namespace WifiPi.Mobile.Backend.Managers
{
	public class EventManager
	{
		public async Task<EventItem[]> GetEventsForDevice(string guid)
		{
			var repo = new WebRepository();
			var path = WebRepository.Paths.BasePath(guid) + WebRepository.Paths.Events;

			var data = await repo.GetFileFromUrl(path);
			var dataAsJson = DataManager.ReadMemoryToString(data);

			return JsonConvert.DeserializeObject<EventItem[]>(dataAsJson);

		}

		public async Task<EventItem[]> GetEventsToday()
		{
			var repo = new WebRepository();
			var path = WebService.WebRepository.Paths.Events;

			var data = await repo.GetFileFromUrl(path);

			var dataAsJson = DataManager.ReadMemoryToString(data);

			return JsonConvert.DeserializeObject<EventItem[]>(dataAsJson);
		}
	}
}
