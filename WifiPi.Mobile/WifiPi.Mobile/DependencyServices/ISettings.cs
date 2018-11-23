using System;
using System.Collections.Generic;
using System.Text;

namespace WifiPi.Mobile.DependencyServices
{
    public interface ISettings
    {
		void SetVariable(string key, string value);
		string GetVariable(string key);
    }
}
