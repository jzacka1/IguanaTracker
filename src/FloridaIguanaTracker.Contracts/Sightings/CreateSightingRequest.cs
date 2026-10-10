using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FloridaIguanaTracker.Contracts.Sightings
{
    public record CreateSightingRequest(
        [Required]
        [StringLength(100, MinimumLength = 1)]
        string City,

        [Range(-90, 90)]
        double Latitude,

        [Range(-180, 180)]
        double Longitude,

        [StringLength(2000)]
        string? Description
    );
}
