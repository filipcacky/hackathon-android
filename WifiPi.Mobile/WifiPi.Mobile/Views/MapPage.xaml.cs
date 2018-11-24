using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WifiPi.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using WifiPi.Mobile.DependencyServices;
using WifiPi.Mobile.Models;
using WifiPi.Mobile.Backend.Managers;

namespace WifiPi.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		private MapViewModel vM;

		public MapPage()
		{
			InitializeComponent();
			vM = new MapViewModel(HomePage.PlaceType);
			this.BindingContext = this.vM;
			this.Title = "Map";

		}
		
		public MapPage(double latitude,double longitude)
		{
			InitializeComponent();
			vM = new MapViewModel(HomePage.PlaceType);
			this.BindingContext = this.vM;
			this.Title = "Map";
		}

		public void CreatePins()
		{
			this.Map.CustomPins = new List<CustomPin>();
			var devices = DataManager.AllDevices.Where(item => item.PlaceType == HomePage.PlaceType);

			List<CustomPin> pins = new List<CustomPin>();

			foreach (var dev in devices)
			{
				var pin = new CustomPin()
				{
						Label = dev.Name,
						Position = new Position(dev.Latitude, dev.Longitude),
						PinColor =  Color.Blue,
						BindingContext = dev
				};
				pin.Clicked += Pin_Clicked;
				pins.Add(pin);
			}

			foreach (var pin in pins)
			{
				this.Map.CustomPins.Add(pin);
			}
			
		}

		private void Pin_Clicked(object sender, EventArgs e)
		{
			var context = (sender as CustomPin)?.BindingContext as DeviceGeneralInfo;
			App.SafeGoToPage(new DetailHomePage(context));
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			await this.vM.LoadData();
			this.CreatePins();

		}
		
	}
}