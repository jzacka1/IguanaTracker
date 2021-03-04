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
		private IguanaApiService iguanaApiService;
		public ApiServiceUnitTest(){
			Initialize();
		}

		private void Initialize(){
			iguanaApiService = new IguanaApiService();
		}

		[Fact]
		public void GetAllTest(){
			List<Iguana> iguanas = iguanaApiService.GetAll();
			Assert.True(iguanas.Count > 0);
		}
	}
}
