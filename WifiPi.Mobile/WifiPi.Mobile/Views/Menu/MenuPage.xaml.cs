using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WifiPi.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WifiPi.Mobile.Views.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
		private MenuViewModel viewModel;
		public MenuPage()
		{
			InitializeComponent();
			this.viewModel = new MenuViewModel();
			this.BindingContext = this.viewModel;
			viewModel.PropertyChanged += MenuPage_PropertyChanged;
		}
		public event EventHandler<SelectedItemChangedEventArgs> ItemSelected;

		private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			this.ItemSelected?.Invoke(this, e);
		}
		private void MenuPage_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "SelectedItem")
			{
				OnItemSelected(this, new SelectedItemChangedEventArgs(viewModel.SelectedItem));
			}
		}
	}
}