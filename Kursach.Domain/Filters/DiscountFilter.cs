using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Domain.Filters
{
    public class DiscountFilter
    {
        public string? Description { get; set; } = string.Empty;
        public int? MinPercentage { get; set; } = null;
        public int? MaxPercentage { get; set; } = null;
    }
}
