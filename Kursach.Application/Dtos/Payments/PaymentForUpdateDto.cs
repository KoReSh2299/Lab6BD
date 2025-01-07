using System.ComponentModel.DataAnnotations;

namespace Kursach.Application.Dtos;

public class PaymentForUpdateDto 
{
	public int Id { get; set; }
	public decimal Amount { get; set; }
	public int TariffId { get; set; }
	public int? DiscountId { get; set; }
	public DateTime PaymentDate { get; set; }
	public DateTime TimeIn { get; set; }
	public DateTime TimeOut { get; set; }
	public int ParkingSpaceId { get; set; }

    [Display(Name = "Посчитать сумму автоматически")]
    public bool CalculateAmountAutomatically { get; set; }
}

