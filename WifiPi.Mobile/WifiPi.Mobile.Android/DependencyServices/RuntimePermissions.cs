using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using WifiPi.Mobile.DependencyServices;
using WifiPi.Mobile.Droid.DependencyServices;
using Xamarin.Forms;

[assembly:Dependency(typeof(RuntimePermissions))]
namespace WifiPi.Mobile.Droid.DependencyServices
{
	public class RuntimePermissions : IRuntimePermissions
	{
		public async Task<bool> GetLocationPermission()
		{
			if (LowSdk())
			{
				return true;
			}
			else
			{
				string[] permissions =
				{
				Manifest.Permission.AccessFineLocation
				};
				return await RequestPermission(permissions, MainActivity.RuntimePermissionLocation);

			}
		}

		private async Task<bool> RequestPermission(string[] permissions, int code)
		{
			var thisActivity = Forms.Context as Activity;
			bool granted = true;
			foreach (var perm in permissions)
			{
				if (ContextCompat.CheckSelfPermission(thisActivity, perm) != (int)Android.Content.PM.Permission.Granted)
				{
					granted = false;
				}
			}
			if (granted)
			{
				return true;
			}

			MainActivity.RuntimePermissionResult = new TaskCompletionSource<bool>();
			thisActivity.RequestPermissions(permissions, code);
			return await MainActivity.RuntimePermissionResult.Task;
		}


		private bool LowSdk()
		{
			if ((int)Build.VERSION.SdkInt < 23)
			{
				return true;
			}
			return false;
		}
	}
}