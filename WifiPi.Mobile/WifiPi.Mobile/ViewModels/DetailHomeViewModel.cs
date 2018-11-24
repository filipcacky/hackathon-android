using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WifiPi.Mobile.Backend.Managers;
using WifiPi.Mobile.DependencyServices;
using WifiPi.Mobile.Models;
using WifiPi.Mobile.Tools;
using WifiPi.Mobile.Views;
using WifiPi.Mobile.Views.Menu;
using Xamarin.Forms;
using Entry = Microcharts.Entry;

namespace WifiPi.Mobile.ViewModels
{
	public class DetailHomeViewModel : BaseViewModel
	{
		public DetailHomeViewModel(DeviceGeneralInfo deviceGeneralInfo)
		{
			this.OpenUrlCommand = new Command(this.OpenUrlCommand_Execute);
			this.RefreshCommand = new Command(this.RefreshCommand_Execute);
			this.FavoriteCommand = new Command(this.FavoriteCommand_Execute);
			this.NavigationCommand = new Command(this.NavigationCommand_Execute);
			this.deviceGeneralInfo = deviceGeneralInfo;
			this.Title = deviceGeneralInfo.Name;
			this.chartColor = SkiaSharp.SKColor.Parse("#fcbe05");
		}


		public async Task LoadDeviceInfo()
		{
			this.IsBusy = true;
			var manager = new DeviceGeneralInfoManager();
			this.deviceGeneralInfo = await manager.GetDevice(this.deviceGeneralInfo.Guid);

			this.UniqueDevices = this.deviceGeneralInfo.UserCount.ToString();
			this.Title = this.deviceGeneralInfo.Name;
			this.Info = this.deviceGeneralInfo.Info;
			this.Web = this.deviceGeneralInfo.Website;
			this.OpeningHours = this.deviceGeneralInfo.OpeningHoursFormatted;

			var eventsManager = new EventManager();
			var arr = await eventsManager.GetEventsForDevice(this.deviceGeneralInfo.Guid);
			this.Items = arr.ToList();

			var statisticManager = new StatisticsManager();
			var data = await statisticManager.GetWeeklyStatisticsForDevice(this.deviceGeneralInfo.Guid);

			var stats = CreateEntries(data);

			this.SetFavoriteIcon();

			this.Entries = new Entry[stats.Count/2];

			int a = 0;
			bool set = false;
			for (int i = 0; i < stats.Count; i++)
			{
				if (i % 2 == 0)
				{
					a++;
					if (!set)
					{
						a = a - 1;
						set = true;
					}
					var item = stats[i];
					this.Entries[a] = new Entry(item.Average)
					{
							Color = this.chartColor,
							Label = $"{item.HourLbl}"
					};
				}
			}


			this.IsBusy = false;
		}

		private List<StatisticsItem> CreateEntries(StatisticsItem[] data)
		{
			List<StatisticsItem> entries = new List<StatisticsItem>() { };
			for (var i = 0; i < data[0].Hours.Length; i++)
			{
				StatisticsItem hourlyEntry = new StatisticsItem();
				hourlyEntry.HourLbl = i;
				hourlyEntry.MinuteLbl = 0;

				hourlyEntry.Day = data[0].Hours[i].Day;

				float[] vals = new float[]
				{
						data[0].Hours[i].Average,
						data[1].Hours[i].Average, //i-tá hodina z každedho dne
						data[2].Hours[i].Average,
						data[3].Hours[i].Average,
						data[4].Hours[i].Average,
						data[5].Hours[i].Average,
						data[6].Hours[i].Average,
				};

				float avg = 0;

				foreach (var val in vals)
				{
					avg += val;
				}

				hourlyEntry.Average = avg / vals.Length;
				entries.Add(hourlyEntry);
			}

			return entries;
		}

		private async void SetFavoriteIcon()
		{
			var dataManager = new DeviceGeneralInfoManager();
			var list = new List<DeviceGeneralInfo>(await dataManager.GetAll());

			var jsonSettings = Settings.GetVariable(Settings.FavoritesDevices);
			var deviceListGuid = new List<string>();
			if (jsonSettings != string.Empty)
			{
				deviceListGuid = JsonConvert.DeserializeObject<List<string>>(jsonSettings);
			}
			this.isFavorite = deviceListGuid.Contains(this.deviceGeneralInfo.Guid);
			this.FavoriteIcon = this.isFavorite ? "ic_favorite" : "ic_favorite_no";
		}


		#region Commands
		public Command OpenUrlCommand { get; set; }
		private void OpenUrlCommand_Execute()
		{
			Xamarin.Forms.Device.OpenUri(new Uri(this.deviceGeneralInfo.Website));
		}

		public Command NavigationCommand { get; set; }
		private void NavigationCommand_Execute()
		{
			DependencyService.Get<IMapHelper>().StartNavigation(this.deviceGeneralInfo.Latitude,this.deviceGeneralInfo.Longitude);
		}
		public Command RefreshCommand { get; set; }
		private async void RefreshCommand_Execute()
		{
			await this.LoadDeviceInfo();
		}

		public Command FavoriteCommand { get; set; }
		private async void FavoriteCommand_Execute()
		{
			if (isFavorite)
			{

				var jsonSettings = Settings.GetVariable(Settings.FavoritesDevices);
				var deviceListGuid = JsonConvert.DeserializeObject<List<string>>(jsonSettings);
				deviceListGuid.Remove(this.deviceGeneralInfo.Guid);
				Settings.SetVariable(Settings.FavoritesDevices, JsonConvert.SerializeObject(deviceListGuid));
				DependencyService.Get<INotifications>().ShowAlert($"{this.deviceGeneralInfo.Name} removed from favorites");
			}
			else
			{

				var jsonSettings = Settings.GetVariable(Settings.FavoritesDevices);
				var deviceListGuid = new List<string>();
				if (jsonSettings != string.Empty)
				{
					deviceListGuid = JsonConvert.DeserializeObject<List<string>>(jsonSettings);
				}
				deviceListGuid.Add(this.deviceGeneralInfo.Guid);
				Settings.SetVariable(Settings.FavoritesDevices, JsonConvert.SerializeObject(deviceListGuid));
				DependencyService.Get<INotifications>().ShowAlert($"{this.deviceGeneralInfo.Name} added to favorites");
			}
			this.isFavorite = !this.isFavorite;
			this.FavoriteIcon = this.isFavorite ? "ic_favorite" : "ic_favorite_no";
		}

		#endregion

		#region Properties
		private bool isFavorite;
		private readonly SkiaSharp.SKColor chartColor;
		private DeviceGeneralInfo deviceGeneralInfo;


		private List<EventItem> items;
		public List<EventItem> Items
		{
			get => this.items;
			set { this.items = value; OnPropertyChanged(); }
		}

		private string info;

		public string Info
		{
			get => this.info;
			set { this.info = value; OnPropertyChanged(); }
		}

		private string web;
		public string Web
		{
			get => this.web;
			set { this.web = value; OnPropertyChanged(); }
		}

		private string uniqueDevices;
		public string UniqueDevices
		{
			get => this.uniqueDevices;
			set { this.uniqueDevices = value; OnPropertyChanged(); }
		}

		private string favoriteIcon;
		public string FavoriteIcon
		{
			get => this.favoriteIcon;
			set { this.favoriteIcon = value; OnPropertyChanged(); }
		}

		private string openingHours;
		public string OpeningHours
		{
			get => this.openingHours;
			set { this.openingHours = value; OnPropertyChanged(); }
		}

		public Entry[] Entries { get; set; }
		#endregion
	}
}
