using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WifiPi.Mobile.DependencyServices;
using WifiPi.Mobile.ViewModels;
using Xamarin.Forms;
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