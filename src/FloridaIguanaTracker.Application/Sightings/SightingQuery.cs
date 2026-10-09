using System;
using System.Collections.Generic;
using System.Text;

namespace FloridaIguanaTracker.Application.Sightings
{
    public sealed record SightingQuery(
        string? City = null,
        DateTime? FromDate = null,
        DateTime? ToDate = null,
        string? Search = null,
        int Page = 1,
        int PageSize = 20);
}
