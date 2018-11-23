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
			var manager = new EventManager();
			var events = await manager.GetEventsToday();

			this.Items = new List<EventItem>(events);
		}

		public async Task LoadFakeData()
		{
			await Task.Delay(100);

			this.Items = new List<EventItem>()
			{
				new EventItem()
				{
					Date = "21.11.2018",
					Description = "ahsidfahjksdfhaslhjdfhdalkdfasdfasdf",
					Name = "Ochutnávky kávy z někud",
					PlaceType = TypeEnum.coffee
				},
				new EventItem()
				{
					Date = "21.11.2018",
					Description = "ahsidfahjksdfhaslhjdfhdalkdfasdfasdf",
					Name = "Předčítání básniček od někoho",
					PlaceType = TypeEnum.coffee
				},
					new EventItem()
					{
					Date = "21.11.2018",
					Description = "ahsidfahjksdfhaslhjdfhdalkdfasdfasdf",
					Name = "Knižní klub",
					PlaceType = TypeEnum.library
				},
			};
		}
	}
}