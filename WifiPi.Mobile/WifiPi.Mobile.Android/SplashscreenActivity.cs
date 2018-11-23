using System.Reflection;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using WifiPi.Mobile.Backend.Managers;

namespace WifiPi.Mobile.Droid
{
	[Activity(Label = "WifiPi.Mobile", Icon = "@mipmap/icon", Theme = "@style/SplashscreenTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class SplashscreenActivity : Activity
	{ 
		protected override async void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			var manager= new DataManager();
			await manager.DownloadGeneralInfo();

			var intent = new Intent(this, typeof(MainActivity));
			StartActivity(intent);
		}
	}
}