using FloridaIguanaTracker.Application.Sightings;
using FloridaIguanaTracker.Domain.Entities;
using FloridaIguanaTracker.Infrastructure.Persistence;
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

        public async Task<(IReadOnlyList<Sighting> Items, int TotalCount)> GetPagedAsync(
            SightingQuery query,
            CancellationToken cancellationToken = default)
        {
            IQueryable<Sighting> sightings = _dbContext.Sightings
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(query.City))
            {
                var city = query.City.Trim();

                sightings = sightings.Where(
                    x => x.City == city);
            }

            if (query.FromDate.HasValue)
            {
                var fromDate = query.FromDate.Value;

                sightings = sightings.Where(
                    x => x.ReportedAt >= fromDate);
            }

            if (query.ToDate.HasValue)
            {
                var toDateExclusive = query.ToDate.Value.Date.AddDays(1);

                sightings = sightings.Where(
                    x => x.ReportedAt < toDateExclusive);
            }

            if (!string.IsNullOrWhiteSpace(query.Search))
            {
                var search = query.Search.Trim();

                sightings = sightings.Where(
                    x => x.Description != null &&
                         x.Description.Contains(search));
            }

            var totalCount = await sightings.CountAsync(cancellationToken);

            var items = await sightings
                .OrderByDescending(x => x.ReportedAt)
                .ThenByDescending(x => x.Id)
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync(cancellationToken);

            return (items, totalCount);
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
