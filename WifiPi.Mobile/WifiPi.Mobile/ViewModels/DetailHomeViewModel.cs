using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WifiPi.Mobile.Backend.Managers;
using WifiPi.Mobile.Models;
using Xamarin.Forms;
using Entry = Microcharts.Entry;

namespace WifiPi.Mobile.ViewModels
{
	public class DetailHomeViewModel : BaseViewModel
	{
		public DetailHomeViewModel(DeviceGeneralInfo deviceGeneralInfo)
		{
			this.OpenUrlCommand = new Command(this.OpenUrlCommand_Execute);
			this.deviceGeneralInfo = deviceGeneralInfo;
			this.Title = deviceGeneralInfo.Name;
			this.chartColor = SkiaSharp.SKColor.Parse("#fcbe05");
		}


		public async Task LoadDeviceInfo()
		{
			this.IsBusy = true;
			var manager = new DeviceGeneralInfoManager();
			this.deviceGeneralInfo = await manager.GetDevice(this.deviceGeneralInfo.Guid);

			this.UniqueDevices = $"Přibližný počet lidí: {this.deviceGeneralInfo.UserCount}";
			this.Title = this.deviceGeneralInfo.Name;
			this.Info = this.deviceGeneralInfo.Info;
			this.Web = this.deviceGeneralInfo.Website;

			//todo data pro graf
			this.Entries = new Entry[]
			{
				new Entry(5)
				{
					Color = this.chartColor,Label= "1"
					
				},new Entry(15)
				{
					Color = this.chartColor,Label= "2"
				},new Entry(8)
				{
					Color = this.chartColor,Label= "3"
				},new Entry(12)
				{
					Color = this.chartColor,Label= "4"
				},new Entry(1)
				{
					Color = this.chartColor,Label= "5"
				},
			};
			this.IsBusy = false;
		}


		#region Commands
		public Command OpenUrlCommand { get; set; }
		private void OpenUrlCommand_Execute()
		{
			Xamarin.Forms.Device.OpenUri(new Uri(this.deviceGeneralInfo.Website));
		}

		#endregion

		#region Properties

		private readonly SkiaSharp.SKColor chartColor;
		private DeviceGeneralInfo deviceGeneralInfo;


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

		public Entry[] Entries { get; set; }
		#endregion
	}
}
