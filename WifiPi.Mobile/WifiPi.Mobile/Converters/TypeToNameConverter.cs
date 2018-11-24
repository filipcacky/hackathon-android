using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using WifiPi.Mobile.Models;
using Xamarin.Forms;

namespace WifiPi.Mobile.Converters
{
	class TypeToNameConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is TypeEnum)
			{
				var type = (TypeEnum)value;

				switch (type)
				{
					case TypeEnum.coffee:
						return "Cafés";
					case TypeEnum.pub:
						return "Pubs";
					case TypeEnum.library:
						return "Libraries";
					case TypeEnum.gym:
						return "Gyms";
					case TypeEnum.restaurant:
						return "Restaurants";
					case TypeEnum.shop:
						return "Shops";

				}

			}

			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
