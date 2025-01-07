using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Domain.Filters
{
    public class EmployeeFilter
    {
        public string? Surname { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public string? MiddleName { get; set; } = string.Empty;
    }
}
