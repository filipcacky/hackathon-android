using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WifiPi.Mobile.Backend.Managers;
using WifiPi.Mobile.Models;
using WifiPi.Mobile.Tools;
using Xamarin.Forms;

namespace WifiPi.Mobile.ViewModels
{
	public class FavoritesViewModel : BaseViewModel
	{


		public FavoritesViewModel()
		{
			this.backUpList = new ObservableCollection<DeviceGeneralInfo>();
			this.RefreshCommand = new Command(this.RefreshCommand_Execute);
		}

		private ObservableCollection<DeviceGeneralInfo> Search()
		{
			var list = new List<DeviceGeneralInfo>();
			var output = new ObservableCollection<DeviceGeneralInfo>();
			if (this.backUpList.Count > 0)
			{
				list = this.backUpList.ToList().Where(item => item.Name.IndexOf(this.searchText, StringComparison.CurrentCultureIgnoreCase) >= 0 ||
				item.Info.IndexOf(this.searchText, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
			}
			foreach (var item in list)
			{
				output.Add(item);
			}
			return output;
		}

		public async Task LoadDevices(bool force = false)
		{
			this.IsBusy = true;
			

			this.backUpList.Clear();

			var jsonSettings = Settings.GetVariable(Settings.FavoritesDevices);
			var deviceListGuid = new List<string>();
			if (jsonSettings != string.Empty)
			{
				deviceListGuid = JsonConvert.DeserializeObject<List<string>>(jsonSettings);
			}

			if (deviceListGuid.Count > 0)
			{
				var dataManager = new DeviceGeneralInfoManager();
				var list = new List<DeviceGeneralInfo>(await dataManager.GetAll(force));

				foreach (var item in list)
				{
					if (deviceListGuid.Contains(item.Guid))
					{
						this.backUpList.Add(item);
					}
				}
			}

			this.Items = this.backUpList;
			this.IsBusy = false;
		}

		#region Commands
		public Command RefreshCommand { get; set; }
		private async void RefreshCommand_Execute()
		{
			await this.LoadDevices(true);
		}


		#endregion

		#region Properties
		private ObservableCollection<DeviceGeneralInfo> backUpList;
		private ObservableCollection<DeviceGeneralInfo> items;
		public ObservableCollection<DeviceGeneralInfo> Items
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
