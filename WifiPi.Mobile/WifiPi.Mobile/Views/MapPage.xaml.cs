using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Gms.Maps.Model;
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
			this.Map.CustomPins = new List<CustomPin>();
			var devices = this.vM.Devices;
			List<CustomPin> pins = new List<CustomPin>();

			foreach (var dev in devices)
			{
				//TODO
				var pin = new CustomPin()
				{
						Label = dev.Name,
						Position = new Position(dev.Latitude, dev.Longitude),
						PinColor =  Color.Blue
				};
				pins.Add(pin);
			}

			foreach (var pin in pins)
			{
				this.Map.CustomPins.Add(pin);
			}
			
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			await this.vM.LoadFakeData();
			this.CreatePins();

		}

		private void MenuItem_OnClicked(object sender, EventArgs e)
		{
			this.Map.ZoomOnAll();
		}
	}
}