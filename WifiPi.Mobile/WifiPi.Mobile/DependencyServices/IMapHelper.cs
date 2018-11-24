using System;
using System.Collections.Generic;
using System.Text;

namespace WifiPi.Mobile.DependencyServices
{
    public interface IMapHelper
    {
		void StartNavigation(double latitude,double longitude);
    }
}
