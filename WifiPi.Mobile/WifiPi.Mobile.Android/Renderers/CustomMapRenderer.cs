using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Content;
using Android.Gms.Common.Apis;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;
using Android.Widget;
using WifiPi.Mobile.Droid.Renderers;
using WifiPi.Mobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace WifiPi.Mobile.Droid.Renderers
{
	public class CustomMapRenderer : Xamarin.Forms.Maps.Android.MapRenderer
	{
		List<CustomPin> CustomPins;
		private Dictionary<string, BitmapDescriptor> colors;
		private bool pinsUpdating;

		public CustomMapRenderer(Context context) : base(context)
		{
			this.colors = new Dictionary<string, BitmapDescriptor>();
		}

		private void SetMarkerColor(MarkerOptions marker, Color color)
		{
			if (!this.colors.ContainsKey(color.ToString()))
			{
				if (color.R == color.G && color.G == color.B)
				{
					this.colors.Add(color.ToString(), BitmapDescriptorFactory.DefaultMarker(0));
				}
				else
				{
					float[] hsv = new float[3];
					Android.Graphics.Color.ColorToHSV(color.ToAndroid(), hsv);
					var bitmap = BitmapDescriptorFactory.DefaultMarker(hsv[0]);
					this.colors.Add(color.ToString(), bitmap);
				}
			}
			marker.SetIcon(this.colors[color.ToString()]);
		}

		protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Map> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null)
			{
			}

			if (e.NewElement != null)
			{
				var formsMap = (CustomMap)e.NewElement;
				CustomPins = formsMap.CustomPins;
				Control.GetMapAsync(this);
			}
		}

		protected override void OnMapReady(GoogleMap map)
		{
			base.OnMapReady(map);
			this.AddCustomItems();
			(this.Element as CustomMap).OnZoomOnAll += (sender, args) => { this.ZoomOnAll(); };
			NativeMap.InfoWindowClick += OnMapMarkerClick;
			this.ZoomOnAll();

		}

		public async void ZoomOnAll()
		{
			await Task.Yield();

			if (this.Element != null)
			{
				if ((this.Element as WifiPi.Mobile.Views.CustomMap).CustomPins.Count == 0)
				{
					return;
				}

				LatLngBounds.Builder builder = new LatLngBounds.Builder();

				foreach (var pin in (this.Element as WifiPi.Mobile.Views.CustomMap).CustomPins)
				{
					builder.Include(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
				}

				LatLngBounds bounds = builder.Build();

				float[] resultSW = new float[1];
				Location.DistanceBetween(bounds.Southwest.Latitude, bounds.Southwest.Longitude,
						bounds.Center.Latitude, bounds.Center.Longitude, resultSW);

				float[] resultNE = new float[1];
				Location.DistanceBetween(bounds.Northeast.Latitude, bounds.Northeast.Longitude,
						bounds.Center.Latitude, bounds.Center.Longitude, resultNE);

				var radius = Math.Max(resultNE[0], resultSW[0]) * 1.2;

				this.Element.MoveToRegion(
						MapSpan.FromCenterAndRadius(new Position(bounds.Center.Latitude, bounds.Center.Longitude),
								Distance.FromMeters(radius)));
			}
		}

		private void AddCustomItems()
		{
			if (NativeMap != null)
			{
				if (!this.pinsUpdating)
				{
					this.pinsUpdating = true;
					NativeMap.Clear();

					if (Element != null)
					{
						if (Element is WifiPi.Mobile.Views.CustomMap)
						{
							if ((Element as WifiPi.Mobile.Views.CustomMap).CustomPins != null)
							{
								for (int i = 0; i < (Element as WifiPi.Mobile.Views.CustomMap).CustomPins.Count; i++)
								{
									CustomPin pin = (Element as WifiPi.Mobile.Views.CustomMap).CustomPins[i];
									var markerOpt = this.CreateMarker(pin);
									var marker = NativeMap.AddMarker(markerOpt);
									pin.Id = marker.Id;
								}
							}
						}
					}

					this.pinsUpdating = false;
				}
			}
		}

		protected virtual MarkerOptions CreateMarker(CustomPin pin)
		{
			var marker = new MarkerOptions();
			marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
			marker.SetTitle(pin.Label);

			if (pin.PinColor.HasValue)
			{
				this.SetMarkerColor(marker, pin.PinColor.Value);
			}
			return marker;
		}
		private void OnMapMarkerClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
		{
			var marker = e.Marker;
			CustomPin targetPin = null;
			for (var i = 0; i < (Element as WifiPi.Mobile.Views.CustomMap).CustomPins.Count; i++)
			{
				CustomPin pin = (Element as WifiPi.Mobile.Views.CustomMap).CustomPins[i];
				if (!string.Equals(pin.Id, marker.Id))
				{
					continue;
				}

				targetPin = pin;
				break;
			}
			targetPin?.OnTap();
		}
	}
}