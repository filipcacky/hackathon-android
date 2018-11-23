using System;
using System.Collections.Generic;
using System.Text;
using WifiPi.Mobile.Models;
using WifiPi.Mobile.Views;
using WifiPi.Mobile.Views.Menu;
using Xamarin.Forms;

namespace WifiPi.Mobile.ViewModels
{
	public class OverviewViewModel : BaseViewModel
	{
		public OverviewViewModel()
		{
			this.PushCommand = new Command<string>(this.PushCommand_Execute);
		}

		#region Commands
		public Command<string> PushCommand { get; set; }
		private void PushCommand_Execute(string strType)
		{
			TypeEnum type;
			switch (strType)
			{
				case "0":
					type = TypeEnum.pub;
					break;
				case "1":
					type = TypeEnum.restaurant;
					break;
				case "2":
					type = TypeEnum.coffee;
					break;
				case "3":
					type = TypeEnum.gym;
					break;
				case "4":
					type = TypeEnum.library;
					break;
				case "5":
					type = TypeEnum.shop;
					break;
				default:
					type = TypeEnum.shop;
					break;
			}
			App.Current.MainPage = new RootPage(type);
		}
		#endregion
	}
}
