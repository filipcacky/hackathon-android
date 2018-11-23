using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WifiPi.Mobile.Droid.Renderers;
using WifiPi.Mobile.Views.Components;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(IconLabel),typeof(IconLabelRenderer))]
namespace WifiPi.Mobile.Droid.Renderers
{
		public class IconLabelRenderer : LabelRenderer
	{
		public IconLabelRenderer(Context context) : base(context)
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);
			var typeface = Typeface.CreateFromAsset(Xamarin.Forms.Forms.Context.Assets, System.IO.Path.Combine("fonts", $"{Element.FontFamily}.ttf"));
			Control.Typeface = typeface;
		}
	}
}