using ExifLib;
using IguanaTracker.Data.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IguanaTracker.Data
{
	public abstract class Geocoding
	{
		public CoordinatesViewModel GetGeoCoordinatesOfFile(Stream file)
		{
			try
			{
				CoordinatesViewModel vm = new CoordinatesViewModel();

				//Fetch geocoordinates from file
				using (var reader = new ExifReader(file))
				{
					reader.GetTagValue(ExifTags.GPSLatitude, out double[] latitude);
					reader.GetTagValue(ExifTags.GPSLongitude, out double[] longitude);
					reader.GetTagValue(ExifTags.GPSLatitudeRef, out string latitudeRef);
					reader.GetTagValue(ExifTags.GPSLongitudeRef, out string longitudeRef);

					if ((latitude != null && latitudeRef != null) &&
						(longitude != null && longitudeRef != null))
					{
						vm = Helpers.CoordinatesHelper.ToCoordinatesWithRefs(latitude, longitude, latitudeRef, longitudeRef);
					}
				}

				return vm;
			}
			catch (Exception ex)
			{
				
			}

			return null;
		}

	}
}
