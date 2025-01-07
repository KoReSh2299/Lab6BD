using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Domain.Filters
{
    public class WorkShiftPaymentFilter
    {
        public int? WorkShiftId { get; set; } = null;
        public int? PaymentId { get; set; } = null;
    }
}
