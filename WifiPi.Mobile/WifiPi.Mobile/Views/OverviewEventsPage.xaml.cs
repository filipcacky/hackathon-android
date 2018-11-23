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

		private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
		{
			await Task.Yield();
			//todo
			//if (this.viewModel.Items.Count > 0)
			//{
			//	this.DeviceListView.ScrollTo(this.viewModel.Items[0], ScrollToPosition.Start, false);
			//}
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			await this.vM.LoadFakeData();
		}

		private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (DeviceListView.SelectedItem != null)
			{
				var item = (EventItem)e.SelectedItem;
				DeviceListView.SelectedItem = null;
				//TODO PŘEJÍT NA INFORMACE O EVENTU
			}
		}
	}
}