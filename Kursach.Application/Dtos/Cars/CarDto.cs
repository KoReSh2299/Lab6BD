namespace Kursach.Application.Dtos;

public class CarDto 
{
	public int Id { get; set; }
	public string Brand { get; set; }
	public string Number { get; set; }
	public int ClientId { get; set; }
	public ClientDto Client { get; set; }
}

