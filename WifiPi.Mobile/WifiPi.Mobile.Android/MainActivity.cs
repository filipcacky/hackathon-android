using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;

namespace WifiPi.Mobile.Droid
{
	[Activity(Label = "WhereToGo", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		public static int RuntimePermissionLocation => 1000;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(savedInstanceState);
			global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
			LoadApplication(new App());
		}
		public static TaskCompletionSource<bool> RuntimePermissionResult { get; set; }

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
		{
			//lokace
			if (grantResults.Length > 0 && requestCode == RuntimePermissionLocation)
			{

				foreach (var grant in grantResults)
				{
					if (grant == Permission.Denied)
					{
						RuntimePermissionResult.SetResult(false);
						return;
					}
				}
				RuntimePermissionResult.SetResult(true);
			}

			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

		}
	}
}