using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WifiPi.Mobile.Backend.Managers;
using WifiPi.Mobile.Models;

namespace WifiPi.Mobile.ViewModels
{
	public class DetailEventViewModel : BaseViewModel
	{
		public DetailEventViewModel(int id)
		{
			this.eventId = id;
		}


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
