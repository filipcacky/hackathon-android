using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WifiPi.Mobile.ViewModels
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}



		private string title;
		public string Title
		{
			get => this.title;
			set
			{
				this.title = value; OnPropertyChanged();
			}
		}


		private bool isBusy;
		public bool IsBusy
		{
			get => this.isBusy;
			set { this.isBusy = value; OnPropertyChanged(); }
		}
	}
}
