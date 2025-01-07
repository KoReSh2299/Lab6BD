using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Application.Dtos;

public class EmployeeWorkSummaryDto
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; } = null!;
    public int WorkShiftCount { get; set; }
    public decimal TotalIncome { get; set; }
    public decimal TotalEmployeeIncome { get; set; }
}

