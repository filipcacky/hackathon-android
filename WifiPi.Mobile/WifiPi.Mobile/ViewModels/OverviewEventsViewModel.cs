using System.Collections.Generic;
using System.Threading.Tasks;
using WifiPi.Mobile.Backend.Managers;
using WifiPi.Mobile.Models;

namespace WifiPi.Mobile.ViewModels
{
	public class OverviewEventsViewModel : BaseViewModel
	{
		private List<EventItem> items;

		public List<EventItem> Items
		{
			get { return this.items; }
			set { this.items = value; this.OnPropertyChanged(); }
		}

		public async Task LoadData()
		{
			this.IsBusy = true;
			var manager = new EventManager();
			var events = await manager.GetEventsToday();

			this.Items = new List<EventItem>(events);
			this.IsBusy = false;
		}

	}
}