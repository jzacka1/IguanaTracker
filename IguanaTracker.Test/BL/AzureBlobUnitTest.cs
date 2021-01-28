using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace IguanaTracker.Test.BL
{
	//https://gist.github.com/trailmax/7505283
	public class AzureBlobUnitTest
	{
		private string containerName;
		private string directoryName;

		public AzureBlobUnitTest(){
			Setup();
		}

		public void Setup(){
			AzureStorageEmulator.Start();
		}
	}
}
