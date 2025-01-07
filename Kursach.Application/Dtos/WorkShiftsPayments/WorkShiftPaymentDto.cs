namespace Kursach.Application.Dtos;

public class WorkShiftPaymentDto 
{
	public int Id { get; set; }
	public int WorkShiftId { get; set; }
	public WorkShiftDto WorkShift { get; set; }
	public int PaymentId { get; set; }
	public PaymentDto Payment { get; set; }
}

