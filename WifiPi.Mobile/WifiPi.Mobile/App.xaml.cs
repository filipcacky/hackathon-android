using System;
using WifiPi.Mobile.Views.Menu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WifiPi.Mobile
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new RootPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		public static void SafeGoToPage(Page page)
		{
			var stack = RootPage.RootNavigationPage.Navigation.NavigationStack;
			if (page.GetType() != stack[stack.Count - 1].GetType())
			{
				RootPage.RootNavigationPage.Navigation.PushAsync(page);
			}
		}
	}
}
