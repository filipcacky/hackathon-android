using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WifiPi.Mobile.Models;
using Xamarin.Forms;

namespace WifiPi.Mobile.ViewModels
{
	public class HomeViewModel : BaseViewModel
	{

		public HomeViewModel()
		{
			this.Title = "Přehled";
		}

		private List<DeviceGeneralInfo> Search()
		{
			var output = new List<DeviceGeneralInfo>();
			if (this.BackUpList.Count > 0)
			{
				output = this.BackUpList.Where(item => item.Name.IndexOf(this.searchText, StringComparison.CurrentCultureIgnoreCase) >= 0 ||
				item.Info.IndexOf(this.searchText, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
			}
			return output;
		}

		#region Commands
		#endregion

		#region Properties
		private List<DeviceGeneralInfo> backUpList;
		private List<DeviceGeneralInfo> items;
		public List<DeviceGeneralInfo> Items
		{
			get => this.items;
			set { this.items = value; OnPropertyChanged(); }
		}

		private string searchText;

		public string SearchText
		{
			get => this.searchText;
			set
			{
				this.searchText = value;
				if (!string.IsNullOrEmpty(value))
				{
					this.Items = this.Search();
				}
				else
				{
					this.Items = this.BackUpList;
				}
				OnPropertyChanged();
			}
		}

		public List<DeviceGeneralInfo> BackUpList
		{
			get { return this.backUpList; }
			set { this.backUpList = value; this.OnPropertyChanged(); }
		}

		#endregion
	}
}
