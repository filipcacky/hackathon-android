using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WifiPi.Mobile.DependencyServices;
using WifiPi.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace WifiPi.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		private MapViewModel vM;
		public MapPage()
		{
			InitializeComponent();
			vM = new MapViewModel();
			this.BindingContext = this.vM;
			this.Title = "Mapa míst";
		}


		public void CreatePins()
		{
			var devices = this.vM.Devices;
			List<Pin> pins = new List<Pin>();

			foreach (var dev in devices)
			{
				var pin = new Pin()
				{
						Label = dev.Name,
						Position = new Position(dev.Latitude, dev.Longitude)
				};
				pins.Add(pin);
			}

			foreach (var pin in pins)
			{
				this.Map.Pins.Add(pin);
			}
		
			
		}



		protected override async void OnAppearing()
		{
			base.OnAppearing();

			await this.vM.LoadFakeData();

			this.CreatePins();
			
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			if(await DependencyService.Get<IRuntimePermissions>().GetLocationPermission())
			{
				this.Map.IsShowingUser = true;
			}
		}
	}
}