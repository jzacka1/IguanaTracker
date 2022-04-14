using System;
using System.Collections.Generic;
using System.Text;

namespace RestfulApiService.Services.MapApiService
{
	public sealed class AzureMapApiService : BaseClient
	{
		public AzureMapApiService() : base("https://atlas.microsoft.com/search/address/reverse/json")
		{
			this._baseURL = BaseUrl.ToString();
		}
	}
}
