using Microcharts;
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
	public partial class DetailHomePage : TabbedPage
	{
		private DetailHomeViewModel viewModel;
		public DetailHomePage(DeviceGeneralInfo deviceGeneralInfo)
		{
			InitializeComponent();
			this.viewModel = new DetailHomeViewModel(deviceGeneralInfo);
			this.BindingContext = this.viewModel;
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			await this.viewModel.LoadDeviceInfo();
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
				App.SafeGoToPage(new DetailEventPage(item.Id));
			}
		}
	}
}