using Microcharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WifiPi.Mobile.Models;
using WifiPi.Mobile.ViewModels;
using WifiPi.Mobile.Views.Menu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WifiPi.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailHomePage : TabbedPage
	{
		private DetailHomeViewModel viewModel;
		private bool firstLoad = true;
		public DetailHomePage(DeviceGeneralInfo deviceGeneralInfo)
		{
			InitializeComponent();
			this.viewModel = new DetailHomeViewModel(deviceGeneralInfo);
			this.BindingContext = this.viewModel;

		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			if (this.firstLoad)
			{
				await this.viewModel.LoadDeviceInfo();
				this.firstLoad = false;
			}

			this.chartView.HeightRequest = 200;
			this.chartView.Margin = 0;
			this.chartView.Chart = new LineChart() { Entries = this.viewModel.Entries, BackgroundColor = SkiaSharp.SKColor.Parse("ffffff"), LabelTextSize = 35 };
		}

		private void EventsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (EventsListView.SelectedItem != null)
			{
				var item = (EventItem)e.SelectedItem;
				EventsListView.SelectedItem = null;
				if (App.Current.MainPage.GetType() == typeof(RootPage))
				{
					App.SafeGoToPage(new DetailEventPage(item.Id));
				}
				else
				{
					this.Navigation.PushAsync(new DetailEventPage(item.Id));
				}
			}
		}
		
	}
}