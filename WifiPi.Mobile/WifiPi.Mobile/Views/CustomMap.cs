using System;
using System.Collections.Generic;
using System.Drawing;
using Xamarin.Forms.Maps;

namespace WifiPi.Mobile.Views
{
	public class CustomMap : Map
	{
		public List<CustomPin> CustomPins { get; set; }

		public event EventHandler OnZoomOnAll;

		public async void ZoomOnAll()
		{
			if (OnZoomOnAll != null)
			{
				OnZoomOnAll(this, new EventArgs());
			}
		}
	}

	public class CustomPin : Pin
	{
		public Color? PinColor { get; set; }
	}
}
