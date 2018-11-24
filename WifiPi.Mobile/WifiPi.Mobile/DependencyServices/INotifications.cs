using System;
using System.Collections.Generic;
using System.Text;

namespace WifiPi.Mobile.DependencyServices
{
	public interface INotifications
	{
		void ShowAlert(string alert, bool longDuration = false);
	}
}
