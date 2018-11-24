using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WifiPi.Mobile.DependencyServices;
using Xamarin.Forms;


[assembly: Dependency(typeof(WifiPi.Mobile.Droid.DependencyServices.Notificatios))]
namespace WifiPi.Mobile.Droid.DependencyServices
{
	public class Notificatios : INotifications
	{
		public void ShowAlert(string alert, bool longDuration = false)
		{
			if (longDuration)
			{
				Toast.MakeText(Forms.Context, alert, ToastLength.Long).Show();
			}
			else
			{
				Toast.MakeText(Forms.Context, alert, ToastLength.Short).Show();
			}
		}
	}
}