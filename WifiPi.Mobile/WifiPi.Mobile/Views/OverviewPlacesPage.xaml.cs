using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WifiPi.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WifiPi.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OverviewPlacesPage : ContentPage
	{
		private OverviewViewModel viewModel;
		public OverviewPlacesPage()
		{
			InitializeComponent();
			this.viewModel = new OverviewViewModel();
			this.BindingContext = this.viewModel;
		}
	}
}