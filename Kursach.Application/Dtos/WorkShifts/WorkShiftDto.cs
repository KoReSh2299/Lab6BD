namespace Kursach.Application.Dtos;

public class WorkShiftDto 
{
	public int Id { get; set; }
	public DateTime ShiftStartTime { get; set; }
	public DateTime ShiftEndTime { get; set; }
	public int EmployeeId { get; set; }
	public decimal Income { get; set; }
	public decimal EmployeeIncome { get; set; }
	public EmployeeDto Employee { get; set; }
}

