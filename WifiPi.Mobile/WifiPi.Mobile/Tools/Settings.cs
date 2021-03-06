﻿using System;
using System.Collections.Generic;
using System.Text;
using WifiPi.Mobile.DependencyServices;
using Xamarin.Forms;

namespace WifiPi.Mobile.Tools
{
	public static class Settings
	{
		#region Consts

		public const string FavoritesDevices = "WhereToGo.Settings.FavoritesDevices";
		#endregion
		public static string GetVariable(string key)
		{
			return DependencyService.Get<ISettings>().GetVariable(key);
		}

		public static void SetVariable(string key, string value)
		{
			DependencyService.Get<ISettings>().SetVariable(key, value);
		}
	}
}
