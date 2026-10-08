using FloridaIguanaTracker.Contracts.Sightings;
using FloridaIguanaTracker.Domain.Entities;

namespace FloridaIguanaTracker.Api.Mappings
{
    public static class SightingMappingExtensions
    {
        public static SightingResponse ToResponse(
            this Sighting sighting)
        {
            return new SightingResponse(
                sighting.Id,
                sighting.ReportedAt,
                sighting.Latitude,
                sighting.Longitude,
                sighting.City,
                sighting.State,
                sighting.Description,
                sighting.ImageBlobName);
        }
    }
}
