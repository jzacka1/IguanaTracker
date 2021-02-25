using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

#nullable disable

namespace IguanaTracker.Data.Data
{
    public partial class Iguana : Image
    {
        public Iguana() {

            Name = "IguanaSighting_";
            directory = "sightings/";

            DatePosted = DateTime.Now;
            ImageFileName = $"{Name}{Helpers.TimeHelper.GetEpochSeconds()}.{ImageFormat.Jpg}";
        }

        private IFormFile _imageData;

        public int Id { get; set; }
        public DateTime DatePosted { get; set; }

        public string ImageFileName { get; set; }
        public string Directory { 
            get => directory;
            set { }
        }

        //Fetch image and its geocoordinates
        [NotMapped]
        public IFormFile ImageData {
			get => _imageData;
			set
			{
                _imageData = (IFormFile)value;

                //Fetch coordinates of uploaded file
                var coords = GetGeoCoordinatesOfFile(_imageData.OpenReadStream());

                //Check if coordinates are not null.
                Latitude = coords?.Latitude ?? Latitude;
                Longitude = coords?.Longitude ?? Longitude;

                //Img = Helpers.Helpers.ImageToByteArrayAsync((IFormFile)value);
            }
		}
        public string City { get; set; }
        public string State { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
    }
}
