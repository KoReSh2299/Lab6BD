using Kursach.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Domain.Filters
{
    public class ClientFilter
    {
        public string? Surname { get; set; } = string.Empty;

        public string? Name { get; set; } = string.Empty;

        public string? MiddleName { get; set; } = string.Empty;

        public string? Telephone { get; set; } = string.Empty;

        public bool? IsRegularClient { get; set; } = null;
    }
}
