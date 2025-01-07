namespace Kursach.Application.Dtos;

public class ParkingSpaceForUpdateDto 
{
	public int Id { get; set; }
	public bool IsPenalty { get; set; }
	public int? CarId { get; set; }
}

