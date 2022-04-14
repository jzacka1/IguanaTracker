using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using IguanaTracker.Data.Data;
using IguanaTracker.BL.Services;
using IguanaTracker.BL.Services.Interfaces;
using IguanaTracker.Test.Data;

namespace IguanaTracker.Test.BL
{
	public class BusinessLogicUnitTest : DataTesting
	{
		private IguanaTrackerService _iguanaTrackerService;

		//Arrange
		public BusinessLogicUnitTest(){
			_iguanaTrackerService = new IguanaTrackerService(_dbTest);
		}

		[Fact]
		public void test(){
			//Act
			var list = _iguanaTrackerService.GetAll();

			//Assert
			Assert.True(list.Count > 0);
		}
	}
}
