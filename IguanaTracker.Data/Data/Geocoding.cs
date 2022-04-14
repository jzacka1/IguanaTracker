using ExifLib;
using IguanaTracker.Data.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IguanaTracker.Data
{
	/// <summary>
	/// Handles geolocation values.
	/// </summary>
	public abstract class Geocoding
	{
		/// <summary>
		/// Fetch coordinate values of file.
		/// </summary>
		/// <param name="Stream">file from the form</param>
		/// <returns>Returns values in a CoordinatesViewModel</returns>
		public CoordinatesViewModel GetGeoCoordinatesOfFile(Stream file)
		{
			try
			{
				CoordinatesViewModel vm = new CoordinatesViewModel();

				//Fetch geo-coordinates from file
				var reader = new ExifReader(file);
				reader.GetTagValue(ExifTags.GPSLatitude, out double[] latitude);
				reader.GetTagValue(ExifTags.GPSLongitude, out double[] longitude);
				reader.GetTagValue(ExifTags.GPSLatitudeRef, out string latitudeRef);
				reader.GetTagValue(ExifTags.GPSLongitudeRef, out string longitudeRef);

				if ((latitude != null && latitudeRef != null) &&
				    (longitude != null && longitudeRef != null))
				{
					vm = Helpers.CoordinatesHelper.ToCoordinatesWithRefs(latitude, longitude, latitudeRef, longitudeRef);
				}

				return vm;
			}
			catch (Exception)
			{
				// ignored
			}

			return null;
		}

	}
}
