using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WifiPi.Mobile.Backend.Managers;
using WifiPi.Mobile.Models;
using WifiPi.Mobile.Views;
using WifiPi.Mobile.Views.Menu;
using Xamarin.Forms;

namespace WifiPi.Mobile.ViewModels
{
	public class DetailEventViewModel : BaseViewModel
	{
		public DetailEventViewModel(int id)
		{
			this.eventId = id;
			this.GoToDetailCommand = new Command(this.GoToDetailHomePage);
		}
		public Command GoToDetailCommand { get; set; }


		public async Task LoadEventData()
		{
			this.IsBusy = true;

			var manager = new EventManager();
			this.eventItem = await manager.GetEvent(this.eventId);

			this.Title = this.eventItem.Name;
			this.Information = this.eventItem.Info;
			this.Date = this.eventItem.Date;
			

			this.IsBusy = false;
		}

		private async void GoToDetailHomePage()
		{
			var devMan = new DeviceGeneralInfoManager();
			var deviceGeneralInfo = await devMan.GetDevice(this.eventItem.DeviceGuid);


			if (App.Current.MainPage.GetType() == typeof(RootPage))
			{
				App.SafeGoToPage(new DetailHomePage(deviceGeneralInfo));
			}
			else
			{
				await App.Current.MainPage.Navigation.PushAsync(new DetailHomePage(deviceGeneralInfo));
			}
		}

		#region Properties
		private int eventId;
		private EventItem eventItem;

		private string information;
		public string Information
		{
			get => this.information;
			set { this.information = value; OnPropertyChanged(); }
		}

		private string date;
		public string Date
		{
			get => this.date;
			set { this.date = value; OnPropertyChanged(); }
		}
		#endregion
	}
}
