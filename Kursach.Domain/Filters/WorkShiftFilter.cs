using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Domain.Filters
{
    public class WorkShiftFilter
    {
        public DateTime? MinShiftStartTime { get; set; } = null;

        public DateTime? MaxShiftStartTime { get; set; } = null;

        public DateTime? MinShiftEndTime { get; set; } = null;
        public DateTime? MaxShiftEndTime { get; set; } = null;

        public int? EmployeeId { get; set; } = null;
    }
}
