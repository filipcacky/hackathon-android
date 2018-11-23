using System;
using System.Globalization;
using WifiPi.Mobile.Models;
using Xamarin.Forms;

namespace WifiPi.Mobile.Converters
{
	public class TypeToIconLabelConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is TypeEnum)
			{
				var type = (TypeEnum)value;

				switch (type)
				{
					case TypeEnum.coffee:
						return (string)App.Current.Resources["Coffee"];
					case TypeEnum.pub:
						return (string)App.Current.Resources["Pub"];
					case TypeEnum.library:
						return (string)App.Current.Resources["Restaurant"];
					case TypeEnum.gym:
						return (string)App.Current.Resources["Gym"];
					case TypeEnum.restaurant:
						return (string)App.Current.Resources["Shop"];
					case TypeEnum.shop:
						return (string)App.Current.Resources["Library"];
					
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