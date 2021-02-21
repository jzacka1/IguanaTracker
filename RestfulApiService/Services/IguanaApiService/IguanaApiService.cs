using IguanaTracker.Data.Data;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestfulApiService.Services.IguanaApiService
{
	public class IguanaApiService : BaseClient, IIguanaApiService
	{
		public IguanaApiService()
			: base("https://iguanatrackerapi20210213201548.azurewebsites.net/api/"){
				this._baseURL = BaseUrl.ToString();
		}

		public List<Iguana> GetAll()
		{
			RestRequest request = new RestRequest("Home", Method.GET);
			List<Iguana> iguanaList = Get<List<Iguana>>(request);
			return iguanaList;
		}
	}
}
