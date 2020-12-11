using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace IguanaTracker.Data.Data
{
    public partial class Iguana
    {
        public Iguana(){
            DatePosted = DateTime.Now;
        }

        private IFormFile _imageData;

        public int Id { get; set; }
        public DateTime DatePosted { get; set; }

        [Required]
        public byte[] Image { get; set; }

        [NotMapped]
        public IFormFile _ImageData {
            get { return _imageData; }
            set {
                Image = Helpers.Helpers.ImageToByteArray((IFormFile)value);
            }
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
