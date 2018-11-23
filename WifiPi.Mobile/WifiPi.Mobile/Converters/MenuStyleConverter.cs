using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace WifiPi.Mobile.Converters
{
	public class MenuStyleConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is bool)
			{

				if ((bool)value)
				{
					return IsSelected;
				}
				else
				{
					return IsNotSelected;
				}
			}

			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}


		public Style IsSelected { get; set; }
		public Style IsNotSelected { get; set; }
	}
}
