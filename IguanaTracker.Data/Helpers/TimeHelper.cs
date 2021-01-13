using System;
using System.Collections.Generic;
using System.Text;

namespace IguanaTracker.Data.Helpers
{
	public class TimeHelper
	{
		//Fetch epoch skills
		public static int GetEpochSeconds()
		{
			TimeSpan t = DateTime.Now - new DateTime(1970, 1, 1);
			return (int)t.TotalSeconds;
		}
	}
}
