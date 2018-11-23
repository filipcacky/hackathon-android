using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WifiPi.Mobile.Models;
using WifiPi.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WifiPi.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OverviewEventsPage : ContentPage
	{
		private OverviewEventsViewModel vM;
		public OverviewEventsPage()
		{
			InitializeComponent();
			this.vM = new OverviewEventsViewModel();
			this.BindingContext = this.vM;
			//TODO PO KLIKNUTÍ NA EVENT ZOBRAZIT DETAIL EVENTU
		}


		protected override async void OnAppearing()
		{
			base.OnAppearing();
			await this.vM.LoadFakeData();
		}

		private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (EventsListView.SelectedItem != null)
			{
				var item = (EventItem)e.SelectedItem;
				EventsListView.SelectedItem = null;
				this.Navigation.PushAsync(new DetailEventPage(item.Id));
			}
		}
	}
}