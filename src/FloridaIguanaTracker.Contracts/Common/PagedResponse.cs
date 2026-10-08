using System;
using System.Collections.Generic;
using System.Text;

namespace FloridaIguanaTracker.Contracts.Common
{
    public record PagedResponse<T>(
        IReadOnlyList<T> Items,
        int Page,
        int PageSize,
        int TotalCount,
        int TotalPages);
}
