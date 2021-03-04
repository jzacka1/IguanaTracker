using IguanaTracker.Data.Data;
using RestfulApiService.Services.IguanaApiService;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IguanaTracker.Test.ApiService
{
	public class ApiServiceUnitTest
	{
		private IguanaApiService _iguanaApiService;
		public ApiServiceUnitTest(){
			Initialize();
		}

		private void Initialize(){
			_iguanaApiService = new IguanaApiService();
		}

		[Fact]
		public void GetAllTest(){
			List<Iguana> iguanas = _iguanaApiService.GetAll();
			Assert.True(iguanas.Count > 0);
		}
	}
}
