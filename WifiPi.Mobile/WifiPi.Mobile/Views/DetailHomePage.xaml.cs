using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WifiPi.Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WifiPi.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailHomePage : ContentPage
	{
		public DetailHomePage (DeviceGeneralInfo deviceGeneralInfo)
		{
			InitializeComponent ();
		}
	}
}