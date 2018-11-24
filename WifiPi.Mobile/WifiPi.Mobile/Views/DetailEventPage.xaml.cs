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
	public partial class DetailEventPage : ContentPage
	{
		private DetailEventViewModel viewModel;
		public DetailEventPage(int id)
		{
			InitializeComponent();
			this.viewModel = new DetailEventViewModel(id);
			this.BindingContext = this.viewModel;
		}

		protected  async override void OnAppearing()
		{
			base.OnAppearing();
			await this.viewModel.LoadEventData();
		}
	}
}