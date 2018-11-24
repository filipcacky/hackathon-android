using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WifiPi.Mobile.Backend.Managers;
using WifiPi.Mobile.Converters;
using WifiPi.Mobile.Models;
using Xamarin.Forms;

namespace WifiPi.Mobile.ViewModels
{
	public class HomeViewModel : BaseViewModel
	{

		public HomeViewModel(TypeEnum type)
		{
			var conv = new TypeToNameConverter();
			this.Title = (string)conv.Convert(type,null,null,null);
			this.type = type;
			this.RefreshCommand = new Command(this.RefreshCommand_Execute);
			//	this.FilterCommand = new Command(this.FilterCommand_Execute);
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

		public async Task LoadDevices(bool force = false)
		{
			this.IsBusy = true;

			var dataManager = new DeviceGeneralInfoManager();
			var list = new List<DeviceGeneralInfo>(await dataManager.GetAll(force));

			this.backUpList = list.Where(item => item.PlaceType == this.type).ToList();
			this.Items = this.backUpList;

			this.IsBusy = false;
		}

		#region Commands
		public Command RefreshCommand { get; set; }
		private async void RefreshCommand_Execute()
		{
			await this.LoadDevices(true);
		}

		//public Command FilterCommand { get; set; }
		//private async void FilterCommand_Execute()
		//{
		//
		//}
		#endregion

		#region Properties
		private TypeEnum type;
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
