using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WifiPi.Mobile.Backend.Managers;
using WifiPi.Mobile.DependencyServices;
using WifiPi.Mobile.Models;
using WifiPi.Mobile.ViewModels;
using WifiPi.Mobile.Views.Menu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WifiPi.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		private HomeViewModel viewModel;
		public static TypeEnum PlaceType;
		public HomePage()
		{
			InitializeComponent();
			this.viewModel = new HomeViewModel(PlaceType);
			this.BindingContext = this.viewModel;
		}

		private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (DeviceListView.SelectedItem != null)
			{
				var item = (DeviceGeneralInfo)e.SelectedItem;
				DeviceListView.SelectedItem = null;
				App.SafeGoToPage(new DetailHomePage(item));
			}
		}

		private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
		{
			await Task.Yield();
			if (this.viewModel.Items.Count > 0)
			{
				this.DeviceListView.ScrollTo(this.viewModel.Items[0], ScrollToPosition.Start, false);
			}
		}

		protected override async void OnAppearing()
		{
			//TODO PŘEMÍSTIT DO VIEWMODELU NAHRÁNÍ ITEMU + UDĚLAT FILTR PODLE ENUMU (this.type)
			base.OnAppearing();
			
			await this.viewModel.LoadDevices();
		}
	}
}