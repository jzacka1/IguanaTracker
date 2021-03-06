﻿using IguanaTracker.Data.Data;
using IguanaTracker.Mobile.Services;
using IguanaTracker.Mobile.ViewModels;
using RestfulApiService.Services.IguanaApiService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IguanaTracker.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Sightings : ContentPage
	{
		private readonly IIguanaApiService _iguanaApiService;

		public Sightings()
		{
			InitializeComponent();

			AppContainer.Initialize();
			_iguanaApiService = AppContainer.Resolve<IIguanaApiService>();
			var sightingsViewModel = AppContainer.Resolve<SightingsViewModel>();
			this.BindingContext = sightingsViewModel;
		}
	}
}