using System;
using System.Collections.Generic;
using System.Text;

namespace FloridaIguanaTracker.Domain.Entities
{
    public class Sighting
    {
        public int Id { get; private set; }

        public DateTime ReportedAt { get; private set; }

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public string City { get; private set; } = string.Empty;

        public string State { get; private set; } = "FL";

        public string? Description { get; private set; }

        public string? ImageBlobName { get; private set; }

        public Sighting(
            DateTime reportedAt,
            double latitude,
            double longitude,
            string city,
            string? description = null)
        {
            ReportedAt = reportedAt;
            Latitude = latitude;
            Longitude = longitude;
            City = city;
            Description = description;
        }

        private Sighting()
        {
        }
    }
}
