using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WifiPi.Mobile.DependencyServices
{
    public interface IRuntimePermissions
    {
		Task<bool> GetLocationPermission();
    }
}
