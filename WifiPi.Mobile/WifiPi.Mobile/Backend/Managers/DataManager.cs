﻿using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WifiPi.Mobile.Models;

namespace WifiPi.Mobile.Backend.Managers
{
	public class DataManager
	{
		public static DeviceGeneralInfo[] AllDevices { get; set; }

		public async Task<DeviceGeneralInfo[]> DownloadGeneralInfo()
		{
			var service = new DataUpdateManager();

			byte[] dataAsByteArray = await service.GetAllGeneralData();
			string dataAsJson = this.ReadMemoryToString(dataAsByteArray);

			AllDevices = JsonConvert.DeserializeObject<DeviceGeneralInfo[]>(dataAsJson);
			return AllDevices;
		}


		private string ReadMemoryToString(byte[] memory)
		{
			string dataAsJson;

			using (var stream = new MemoryStream(memory))
			{
				using (var streamReader = new StreamReader(stream))
				{
					dataAsJson = streamReader.ReadToEnd();
				}
			}

			return dataAsJson;
		}
	}
}