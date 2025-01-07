namespace Kursach.Application.Dtos;

public class WorkShiftForCreationDto 
{
	public DateTime ShiftStartTime { get; set; }
	public DateTime ShiftEndTime { get; set; }
	public int EmployeeId { get; set; }
    public decimal Income { get; set; }
    public decimal EmployeeIncome { get; set; }
}

