using Kursach.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Domain.Filters
{
    public class CarFilter
    {
        public string? Brand { get; set; } = null;

        public string? Number { get; set; } = null;

        public int? ClientId { get; set; } = null;
    }
}
