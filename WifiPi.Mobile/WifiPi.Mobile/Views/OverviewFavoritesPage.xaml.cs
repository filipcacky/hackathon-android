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
	public partial class OverviewFavoritesPage : ContentPage
	{
		private FavoritesViewModel viewModel;
		public OverviewFavoritesPage()
		{
			InitializeComponent();
			this.viewModel = new FavoritesViewModel();
			this.BindingContext = this.viewModel;
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();	
			await this.viewModel.LoadDevices();
		}

		private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
		{
			await Task.Yield();
			if (this.viewModel.Items.Count > 0)
			{
				this.DeviceListView.ScrollTo(this.viewModel.Items[0], ScrollToPosition.Start, false);
			}
		}

		private void DeviceListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (DeviceListView.SelectedItem != null)
			{
				var item = (DeviceGeneralInfo)e.SelectedItem;
				DeviceListView.SelectedItem = null;
				this.Navigation.PushAsync(new DetailHomePage(item));
			}
		}
	}
}