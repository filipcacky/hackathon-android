using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WifiPi.Mobile.Annotations;
using WifiPi.Mobile.Backend.Managers;
using WifiPi.Mobile.Models;

namespace WifiPi.Mobile.ViewModels
{
	public class MapViewModel : BaseViewModel
	{
		private List<DeviceGeneralInfo> devices;

		public List<DeviceGeneralInfo> Devices
		{
			get { return devices; }
			set
			{
				devices = value;
				this.OnPropertyChanged();
			}
		}

		private TypeEnum type;
		public MapViewModel(TypeEnum type)
		{
			this.type = type;
		}

		public async Task LoadData()
		{
			var manager = new DeviceGeneralInfoManager();
			this.Devices = new List<DeviceGeneralInfo>(await manager.GetAll()).Where(d => d.PlaceType == this.type).ToList();
		}

		public async Task LoadFakeData()
		{
			await Task.Delay(100);

			this.Devices = new List<DeviceGeneralInfo>()
			{
					new DeviceGeneralInfo()
					{
						PlaceType = TypeEnum.coffee,
							Name= "Kavarna 1",

							Latitude = 50.72423320,
							Longitude = 15.178632999999990,
							UserCount = 69
					},
					new DeviceGeneralInfo()
					{
						PlaceType = TypeEnum.coffee,
							Name= "Kavarna 2",
							Latitude = 50.7403640,
							Longitude = 15.1776519999999660,
							UserCount = 5

					},
					new DeviceGeneralInfo()
					{
						PlaceType = TypeEnum.coffee,
							Name= "Kavarna 3",

							Latitude = 50.71574560,
							Longitude = 15.163042600000040,
							UserCount = 25

					},
					new DeviceGeneralInfo()
					{
						PlaceType = TypeEnum.pub,
						Name = "Hospoda",

							Latitude = 50.74260470,
							Longitude = 15.1805580999999850,
							UserCount = 20
					},
			};
		}

	}
}