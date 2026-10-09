using FloridaIguanaTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FloridaIguanaTracker.Application.Sightings
{
    public interface ISightingRepository
    {
        Task<Sighting?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default);

        Task<(IReadOnlyList<Sighting> Items, int TotalCount)> GetPagedAsync(
            SightingQuery query,
            CancellationToken cancellationToken = default);

        Task AddAsync(
            Sighting sighting,
            CancellationToken cancellationToken = default);
    }
}
