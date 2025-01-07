using System;
using System.Collections.Generic;

namespace Kursach.Domain.Entities;

public partial class WorkShiftPayment
{
    public int Id { get; set; }

    public int WorkShiftId { get; set; }

    public int PaymentId { get; set; }

    public virtual Payment Payment { get; set; } = null!;

    public virtual WorkShift WorkShift { get; set; } = null!;
}
