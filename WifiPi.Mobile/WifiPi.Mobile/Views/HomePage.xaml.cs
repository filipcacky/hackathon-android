﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WifiPi.Mobile.Backend.Managers;
using WifiPi.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WifiPi.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		private HomeViewModel viewModel;
		public HomePage ()
		{
			InitializeComponent ();
			this.viewModel = new HomeViewModel();
			this.BindingContext = this.viewModel;
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			var dataManager = new DataManager();
			await dataManager.DownloadGeneralInfo();
		}
	}
}