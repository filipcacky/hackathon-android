using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WifiPi.Mobile.Views.Components
{
	public class IconLabel : Label
	{
		public static readonly BindableProperty FontNameProperty =
			BindableProperty.Create("FontName", typeof(string), typeof(IconLabel), null);

		public string FontName
		{
			get => (string)GetValue(FontNameProperty);
			set => SetValue(FontNameProperty, value);
		}
	}
}
