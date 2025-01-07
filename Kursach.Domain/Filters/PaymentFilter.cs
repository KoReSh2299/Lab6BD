using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Domain.Filters
{
    public class PaymentFilter
    {
        public decimal? MinAmount { get; set; } = null;
        public decimal? MaxAmount { get; set; } = null;
        public int? TariffId { get; set; } = null;
        public int? DiscountId { get; set; } = null;
        public int? ParkingSpaceId { get; set; } = null;
        public DateTime? MinPaymentDate { get; set; } = null;
        public DateTime? MaxPaymentDate { get; set; } = null;
        public DateTime? MinTimeIn { get; set; } = null;
        public DateTime? MaxTimeIn { get; set; } = null;
        public DateTime? MinTimeOut { get; set; } = null;
        public DateTime? MaxTimeOut { get; set; } = null;
    }
}
