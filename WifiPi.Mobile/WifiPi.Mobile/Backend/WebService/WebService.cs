using System.Net.Http;
using System.Threading.Tasks;

namespace WifiPi.Mobile.Backend.WebService
{
	public class WebRepository
	{
		private HttpClient client;
		private readonly string Url = "https://e1cc2153.NGROK.io/api/";

		public static class Paths
		{
			#region General data
			/// <summary>
			/// api return general information on all devices
			/// </summary>
			public static string All => "all/";

			#endregion

			#region Specific device data
			/// <summary>
			/// used to create a path to specific device
			/// </summary>
			/// <param name="guid"></param>
			/// <returns></returns>
			public static string BasePath(string guid)
			{
				return $"device/{guid}/";
			}
			/// <summary>
			/// Returns device specific array that contains statistics for last week
			/// </summary>
			public static string Week => "this-week/";
			/// <summary>
			/// Returns device specific array that contains statistics for last month
			/// </summary>
			public static string Month => "month/";
			/// <summary>
			/// Returns device specific array that contains statistics for this day
			/// </summary>
			public static string Today => "today/";

			/// <summary>
			/// Returns device specific data that contains current amount of ppl
			/// </summary>
			public static string Now => "now/";

			/// <summary>
			/// Returns device specific events
			/// </summary>
			public static string Events => "events/";

			public static string Event => "event/";
			public static string EventsToday =>"events-happening-right-now/";

			#endregion
		}

		public async Task<byte[]> GetFileFromUrl(string path)
		{
			byte[] output = null;
			try
			{
				using (this.client = new HttpClient())
				{
					var httpResponse = await this.client.GetAsync(this.Url + path);
					output = await httpResponse.Content?.ReadAsByteArrayAsync();
					return output;
				}
			}
			catch
			{
				return null;
			}
		}
	}
}
