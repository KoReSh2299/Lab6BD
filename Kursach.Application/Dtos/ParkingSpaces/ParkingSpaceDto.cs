namespace Kursach.Application.Dtos;

public class ParkingSpaceDto 
{
	public int Id { get; set; }
	public bool IsPenalty { get; set; }
	public int? CarId { get; set; }
	public CarDto? Car { get; set; }
}

