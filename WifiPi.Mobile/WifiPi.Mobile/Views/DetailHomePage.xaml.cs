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
			//TODO LOAD EVENTS 
			this.chartView.HeightRequest = 200;
			this.chartView.Margin = 0;
			this.chartView.Chart = new LineChart() { Entries = this.viewModel.Entries, BackgroundColor = SkiaSharp.SKColor.Parse("ffffff"), LabelTextSize = 35 };
		}
	}
}