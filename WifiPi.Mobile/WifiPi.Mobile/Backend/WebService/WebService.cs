using System.Net.Http;
using System.Threading.Tasks;

namespace WifiPi.Mobile.Backend.WebService
{
	public class WebRepository
	{
		private HttpClient client;
		private readonly string Url = "https://8b20e2c2.NGROK.io/";

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
			public static string Week => "week/";
			/// <summary>
			/// Returns device specific array that contains statistics for last month
			/// </summary>
			public static string Month => "month/";
			/// <summary>
			/// Returns device specific array that contains statistics for this day
			/// </summary>
			public static string Today => "today/";
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
