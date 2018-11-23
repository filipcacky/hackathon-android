using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WifiPi.Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WifiPi.Mobile.Views.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RootPage : MasterDetailPage
	{
		public RootPage()
		{
			InitializeComponent();
			this.MasterBehavior = MasterBehavior.Popover;
			this.MenuPage.ItemSelected += Menu_ItemSelected;
			this.GoToPage((Page)Activator.CreateInstance(typeof(OverviewPage)));
		}
		public RootPage(TypeEnum type)
		{
			InitializeComponent();
			this.MasterBehavior = MasterBehavior.Popover;
			this.MenuPage.ItemSelected += Menu_ItemSelected;
			this.GoToPage(new HomePage(type));
		}
		public static NavigationPage RootNavigationPage { get; protected set; }


		private void Menu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem is MenuItemModel item)
			{
				if (item.TargetType != null)
				{
					this.GoToPage((Page)Activator.CreateInstance(item.TargetType));
				}
				else
				{
					this.GoToPage(new HomePage(TypeEnum.shop)); //TODO CO TADY ZA TYPE ? xd
				}
			}
			this.IsPresented = false;
		}

		public void GoToPage(Page page)
		{
			try
			{
				RootNavigationPage = new NavigationPage(page)
				{
					BarBackgroundColor = (Color)App.Current.Resources["PrimaryToolbarColor"],
					BarTextColor = Color.White
				};
				this.Detail = RootNavigationPage;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}


		protected override bool OnBackButtonPressed()
		{
			if (RootPage.RootNavigationPage.Navigation.NavigationStack.Count == 1)
			{
				App.Current.MainPage = new NavigationPage(new OverviewPage());
				return true;
			}
			return base.OnBackButtonPressed();
		}

	}
}