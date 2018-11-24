
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WifiPi.Mobile.DependencyServices;
using WifiPi.Mobile.Droid.DependencyServices;
using Xamarin.Forms;

[assembly:Dependency(typeof(MapHelper))]
namespace WifiPi.Mobile.Droid.DependencyServices
{
	public class MapHelper : IMapHelper
	{
		public void StartNavigation(double latitude, double longitude)
		{
			var strLat = latitude.ToString().Replace(',','.');
			var strLong = longitude.ToString().Replace(',','.');
			Uri gmmIntentUri = Uri.Parse($"google.navigation:q={strLat},{strLong}");
			Intent mapIntent = new Intent(Intent.ActionView, gmmIntentUri);
			mapIntent.SetPackage("com.google.android.apps.maps");
			Forms.Context.StartActivity(mapIntent);
		}
	}
}