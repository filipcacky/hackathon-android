using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WifiPi.Mobile.Models;

namespace WifiPi.Mobile.ViewModels
{
	public class HomeViewModel : BaseViewModel
	{
		public HomeViewModel()
		{

		}

		#region Properties
		private ObservableCollection<string> items;
		public ObservableCollection<string> Items
		{
			get => this.items;
			set { this.items = value; OnPropertyChanged(); }
		}

		#endregion
	}
}
