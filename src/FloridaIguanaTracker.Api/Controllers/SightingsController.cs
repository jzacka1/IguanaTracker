using FloridaIguanaTracker.Api.Mappings;
using FloridaIguanaTracker.Application.Sightings;
using FloridaIguanaTracker.Contracts.Common;
using FloridaIguanaTracker.Contracts.Sightings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FloridaIguanaTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SightingsController : ControllerBase
    {
        private readonly ISightingRepository _sightingRepository;

        public SightingsController(ISightingRepository sightingRepository)
        {
            _sightingRepository = sightingRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SightingResponse>> GetById(
            int id,
            CancellationToken cancellationToken)
        {
            var sighting = await _sightingRepository.GetByIdAsync(
                id,
                cancellationToken);

            if (sighting is null)
            {
                return NotFound();
            }

            var response = sighting.ToResponse();

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<SightingResponse>>> GetAll(
            int page = 1,
            int pageSize = 20,
            CancellationToken cancellationToken = default)
        {
            if (page < 1)
            {
                return BadRequest("Page must be greater than or equal to 1.");
            }

            if (pageSize < 1 || pageSize > 100)
            {
                return BadRequest("Page size must be between 1 and 100.");
            }

            var (sightings, totalCount) =
                await _sightingRepository.GetPagedAsync(
                    page,
                    pageSize,
                    cancellationToken);

            var items = sightings
                .Select(sighting => sighting.ToResponse())
                .ToList();

            var totalPages = (int)Math.Ceiling(
                totalCount / (double)pageSize);

            var response = new PagedResponse<SightingResponse>(
                items,
                page,
                pageSize,
                totalCount,
                totalPages);

            return Ok(response);
        }
    }
}
