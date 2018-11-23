using System.Net.Http;
using System.Threading.Tasks;

namespace WifiPi.Mobile.Backend.WebService
{
	public class WebRepository
	{
		private HttpClient client;
		private readonly string Url = "https://8b20e2c2.NGROK.io/";



		public WebRepository()
		{
			
		}

		public async Task<byte[]> GetFileFromUrl(string url, int timeout = 5000)
		{
			byte[] output = null;
			try
			{
				using (this.client = new HttpClient())
				{
					var httpResponse = await this.client.GetAsync(this.Url + url);
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
