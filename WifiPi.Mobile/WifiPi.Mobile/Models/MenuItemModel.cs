using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace WifiPi.Mobile.Models
{
	public class MenuItemModel : INotifyPropertyChanged
	{
		#region PropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion

		public string Title { get; set; }

		public string Icon { get; set; }

		public string FontFamily { get; set; }

		public Type TargetType { get; set; }

		private bool selected;
		public bool Selected
		{
			get => this.selected;
			set
			{
				if (this.selected == value) return;
				this.selected = value;
				this.OnPropertyChanged();
			}
		}

		public Page Page { get; set; }


	}
}
