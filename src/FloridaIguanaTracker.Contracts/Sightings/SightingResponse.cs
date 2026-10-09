using System;
using System.Collections.Generic;
using System.Text;

namespace FloridaIguanaTracker.Contracts.Sightings
{
    public record SightingResponse(
        int Id,
        DateTime ReportedAt,
        double Latitude,
        double Longitude,
        string City,
        string State,
        string? Description,
        string? ImageUrl);
}
