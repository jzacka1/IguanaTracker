using IguanaTracker.Data.Data;
using RestfulApiService.Services.IguanaApiService;
using System;
using System.Collections.Generic;
using System.Text;

namespace IguanaTracker.Mobile.ViewModels
{
	public class SightingsViewModel : BaseViewModel
	{
		private readonly IIguanaApiService _iguanaApiService;
		public SightingsViewModel(IIguanaApiService iguanaApiService)
		{
			_iguanaApiService = iguanaApiService;
			GetSightings();
		}

		public List<Iguana> Sightings { get; set; }

		private void GetSightings(){
			Sightings = _iguanaApiService.GetAll();
		}

		public void GetImage(){

		}
	}
}
