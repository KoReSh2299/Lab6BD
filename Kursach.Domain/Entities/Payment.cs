using System;
using System.Collections.Generic;

namespace Kursach.Domain.Entities;

public partial class Payment
{
    public int Id { get; set; }

    public decimal Amount { get; set; }

    public int TariffId { get; set; }

    public int? DiscountId { get; set; }

    public int ParkingSpaceId { get; set; }

    public DateTime PaymentDate { get; set; }

    public DateTime TimeIn { get; set; }

    public DateTime TimeOut { get; set; }

    public virtual Discount? Discount { get; set; }

    public virtual ParkingSpace ParkingSpace { get; set; } = null!;

    public virtual Tariff Tariff { get; set; } = null!;

    public virtual ICollection<WorkShiftPayment> WorkShiftsPayments { get; set; } = new List<WorkShiftPayment>();
}
