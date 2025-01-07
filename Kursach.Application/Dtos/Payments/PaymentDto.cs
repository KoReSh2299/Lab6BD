namespace Kursach.Application.Dtos;

public class PaymentDto 
{
	public int Id { get; set; }
	public decimal Amount { get; set; }
	public int TariffId { get; set; }
	public TariffDto Tariff { get; set; }
	public int DiscountId { get; set; }
	public DiscountDto Discount { get; set; }
	public DateTime PaymentDate { get; set; }
	public DateTime TimeIn { get; set; }
	public DateTime TimeOut { get; set; }
	public int ParkingSpaceId { get; set; }
	public ParkingSpaceDto ParkingSpace { get; set; }
}

