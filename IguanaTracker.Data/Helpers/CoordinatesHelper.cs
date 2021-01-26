using IguanaTracker.Data.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace IguanaTracker.Data.Helpers
{
	public class CoordinatesHelper
	{
		public static CoordinatesViewModel ToCoordinatesWithRefs(double[] latitude, double[] longitude, string latitudeRef, string longitudeRef){

			CoordinatesViewModel temp = ToCoordinatesAbs(latitude, longitude);

			temp.latitude = (latitudeRef == "N" ? 1 : -1) * temp.latitude;
			temp.longitude = (longitudeRef == "E" ? 1 : -1) * temp.longitude;

			return temp;
		}

		public static CoordinatesViewModel ToCoordinatesAbs(double[] latitude, double[] longitude){
			CoordinatesViewModel temp = new CoordinatesViewModel();

			temp.latitude = latitude[0] + (latitude[1] / 60f) + (latitude[2] / 3600f);
			temp.longitude = longitude[0] + (longitude[1] / 60f) + (longitude[2] / 3600f);

			return temp;
		}
	}
}
