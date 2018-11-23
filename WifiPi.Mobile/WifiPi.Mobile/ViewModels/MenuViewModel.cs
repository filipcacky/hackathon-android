using System;
using System.Collections.Generic;
using System.Text;
using WifiPi.Mobile.Models;

namespace WifiPi.Mobile.ViewModels
{
	public class MenuViewModel : BaseViewModel
	{

		public MenuViewModel()
		{
			this.MenuItems = MenuViewModel.GetMenuItems();
		}

		private void MarkItemAsSelected(MenuItemModel newSelectedItem)
		{
			this.selectedItem = newSelectedItem;
			foreach (var item in MenuItems)
			{
				item.Selected = item == selectedItem;
			}
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



		public static List<MenuItemModel> GetMenuItems()
		{
			var menuItems = new List<MenuItemModel>();
			menuItems.Add(new MenuItemModel()
			{
				Title = "Home",
				FontFamily = App.Current.Resources["FontAwesomeSolid"].ToString(),
				Icon = "\uf6d5",
				Selected = true,
				TargetType = null
			});
			menuItems.Add(new MenuItemModel()
			{
				Title = "Home",
				FontFamily = App.Current.Resources["FontAwesomeSolid"].ToString(),
				Icon = "\uf6d5",
				Selected = false,
				TargetType = null
			});
			menuItems.Add(new MenuItemModel()
			{
				Title = "Home",
				FontFamily = App.Current.Resources["FontAwesomeSolid"].ToString(),
				Icon = "\uf6d5",
				Selected = false,
				TargetType = null
			});

			return menuItems;
		}
	}
}
