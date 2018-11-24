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

			this.SetFavoriteIcon();

			this.Entries = new Entry[data.Length];
			for (int i = 0; i < data.Length; i++)
			{
				var item = data[i];
				this.Entries[i] = new Entry(item.Average)
				{
					Color = this.chartColor,
					Label = $"{item.Day.Day}.{item.Day.Month}"
				};
			}


			this.IsBusy = false;
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
