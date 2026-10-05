using FloridaIguanaTracker.Application.Sightings;
using FloridaIguanaTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FloridaIguanaTracker.Infrastructure.Persistence.Repositories
{
    public class SightingRepository : ISightingRepository
    {
        private readonly FloridaIguanaTrackerDbContext _dbContext;

        public SightingRepository(FloridaIguanaTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Sighting?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.Sightings
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    x => x.Id == id,
                    cancellationToken);
        }

        public async Task<IReadOnlyList<Sighting>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.Sightings
                .AsNoTracking()
                .OrderByDescending(x => x.ReportedAt)
                .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(
            Sighting sighting,
            CancellationToken cancellationToken = default)
        {
            await _dbContext.Sightings.AddAsync(
                sighting,
                cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
