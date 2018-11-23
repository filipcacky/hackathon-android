using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WifiPi.Mobile.Models;

namespace WifiPi.Mobile.ViewModels
{
	public class HomeViewModel : BaseViewModel
	{
		public HomeViewModel()
		{
			this.Title = "Přehled";
			this.backUpList = new List<DeviceGeneralInfo>();
			for (int i = 0; i < 10; i++)
			{
				this.backUpList.Add(new DeviceGeneralInfo
			{
				Name = $"{i}",
				Info = $"informace {i}"
			});
			}
			this.Items = this.backUpList;
		}


		private List<DeviceGeneralInfo> Search()
		{
			var output = new List<DeviceGeneralInfo>();
			if (this.backUpList.Count > 0)
			{
				output = this.backUpList.Where(item => item.Name.IndexOf(this.searchText, StringComparison.CurrentCultureIgnoreCase) >= 0 ||
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
					this.Items = this.backUpList;
				}
				OnPropertyChanged();
			}
		}


		#endregion
	}
}
