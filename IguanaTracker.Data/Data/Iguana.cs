using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

#nullable disable

namespace IguanaTracker.Data.Data
{
    public partial class Iguana
    {
        public Iguana() {
            DatePosted = DateTime.Now;
            ImageFileName = String.Format("{0}{1}.{2}", name, Helpers.TimeHelper.GetEpochSeconds(), imageFormat.jpg.ToString());
        }

        private string name = "IguanaSighting_";
        private string directory = "sightings/";
        private string format = ".jpg";
        private enum imageFormat { jpg, png }
        private IFormFile _imageData;
        private string imageFileName;

        public int Id { get; set; }
        public DateTime DatePosted { get; set; }

        //[Required]
        //public byte[] Img { get; set; }

        public string ImageFileName { get; set; }
        public string Directory { 
            get { return directory; }
            set { }
        }

        [NotMapped]
        public IFormFile _ImageData {
			get { return _imageData; }
			set
			{
                _imageData = (IFormFile)value;
                //Img = Helpers.Helpers.ImageToByteArrayAsync((IFormFile)value);
			}

			//get;set;
		}
        public string City { get; set; }
        public string State { get; set; }
        [Column(TypeName = "decimal(11,9)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(11,9)")]
        public decimal Longitude { get; set; }
        public string Description { get; set; }
    }
}
