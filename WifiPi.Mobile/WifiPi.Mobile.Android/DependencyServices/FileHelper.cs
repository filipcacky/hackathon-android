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
using WifiPi.Mobile.Droid.DependencyServices;
using Xamarin.Forms;

[assembly:Dependency(typeof(FileHelper))]
namespace WifiPi.Mobile.Droid.DependencyServices
{
	public class FileHelper : IFileHelper
	{
		public string GetAbsolutePath()
		{
			return Forms.Context.FilesDir.AbsolutePath + "/";
		}
	}
}