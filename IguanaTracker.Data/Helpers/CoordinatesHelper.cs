using IguanaTracker.Data.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace IguanaTracker.Data.Helpers
{
	public class CoordinatesHelper
	{
		public static CoordinatesViewModel ToCoordinatesWithRefs(double[] latitude, double[] longitude, string latitudeRef, string longitudeRef){

			var temp = ToCoordinatesAbs(latitude, longitude);

			temp.Latitude = (latitudeRef == "N" ? 1 : -1) * temp.Latitude;
			temp.Longitude = (longitudeRef == "E" ? 1 : -1) * temp.Longitude;

			return temp;
		}

		public static CoordinatesViewModel ToCoordinatesAbs(double[] latitude, double[] longitude){
			CoordinatesViewModel temp = new CoordinatesViewModel
			{
				Latitude = latitude[0] + (latitude[1] / 60f) + (latitude[2] / 3600f),
				Longitude = longitude[0] + (longitude[1] / 60f) + (longitude[2] / 3600f)
			};


			return temp;
		}
	}
}
