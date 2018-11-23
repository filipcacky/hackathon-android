using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WifiPi.Mobile.DependencyServices;
using Xamarin.Forms;
using static Android.Media.Audiofx.BassBoost;

[assembly: Dependency(typeof(Settings))]
namespace WifiPi.Mobile.Droid.DependencyServices
{
	public class Settings : ISettings
	{
		public string GetVariable(string key)
		{
			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Forms.Context);
			var output = prefs.GetString(key, string.Empty);
			prefs.Dispose();
			return output;
		}

		public void SetVariable(string key, string value)
		{
			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Forms.Context);
			ISharedPreferencesEditor settings = prefs.Edit();
			settings.PutString(key, value);
			settings.Apply();
			prefs.Dispose();
		}
	}
}