using System;
using System.Collections.Generic;

namespace Kursach.Domain.Entities;

public partial class WorkShift
{
    public int Id { get; set; }

    public DateTime ShiftStartTime { get; set; }

    public DateTime ShiftEndTime { get; set; }

    public int EmployeeId { get; set; }

    public decimal Income { get; set; }

    public decimal EmployeeIncome { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<WorkShiftPayment> WorkShiftsPayments { get; set; } = new List<WorkShiftPayment>();
}
