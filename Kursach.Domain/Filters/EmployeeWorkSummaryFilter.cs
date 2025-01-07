using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Domain.Filters
{
    public class EmployeeWorkSummaryFilter
    {
        public DateTime? PeriodStart { get; set; } = null;
        public DateTime? PeriodEnd { get; set; } = null;
    }
}
