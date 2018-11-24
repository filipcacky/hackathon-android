using System;
using System.Collections.Generic;
using System.Text;
using WifiPi.Mobile.Converters;
using WifiPi.Mobile.Models;
using WifiPi.Mobile.Views;

namespace WifiPi.Mobile.ViewModels
{
	public class MenuViewModel : BaseViewModel
	{

		public MenuViewModel()
		{
			this.MenuItems = this.GetMenuItems();
		}

		private void MarkItemAsSelected(MenuItemModel newSelectedItem)
		{
			this.selectedItem = newSelectedItem;
			foreach (var item in MenuItems)
			{
				item.Selected = item == selectedItem;
			}
		}

		public void SetIconForMainItem(TypeEnum type)
		{

			var nameConv = new TypeToNameConverter();
			var iconConv = new TypeToIconLabelConverter();
			this.MenuItems[0].Icon = iconConv.Convert(HomePage.PlaceType, null, null, null).ToString();
			this.MenuItems[0].Title = nameConv.Convert(HomePage.PlaceType, null, null, null).ToString();

		}

		#region Properties
		private List<MenuItemModel> menuItems;

		public List<MenuItemModel> MenuItems
		{
			get => menuItems;
			set { this.menuItems = value; OnPropertyChanged(); }
		}

		private MenuItemModel selectedItem;

		public MenuItemModel SelectedItem
		{
			get => this.selectedItem;
			set { this.selectedItem = value; this.MarkItemAsSelected(value); OnPropertyChanged(); }
		}

		#endregion

		public  List<MenuItemModel> GetMenuItems()
		{
			var menuItems = new List<MenuItemModel>();
			var nameConv = new TypeToNameConverter();
			var iconConv = new TypeToIconLabelConverter();
			menuItems.Add(new MenuItemModel()
			{
				Title = nameConv.Convert(HomePage.PlaceType,null,null,null).ToString(),
				FontFamily = App.Current.Resources["FontAwesomeSolid"].ToString(),
				Icon = iconConv.Convert(HomePage.PlaceType,null,null,null).ToString(),
				Selected = true,
				TargetType = typeof(HomePage)
			});
			menuItems.Add(new MenuItemModel()
			{
				Title = "Map",
				FontFamily = App.Current.Resources["FontAwesomeSolid"].ToString(),
				Icon = "\uf59f",
				Selected = false,
				TargetType = typeof(MapPage)
			});

			return menuItems;
		}
	}
}
