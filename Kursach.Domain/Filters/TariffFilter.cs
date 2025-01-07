using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Domain.Filters
{
    public class TariffFilter
    {
        public string? Description { get; set; } = String.Empty;

        public decimal? MinRate { get; set; } = null;

        public decimal? MaxRate { get; set; } = null;
    }
}
