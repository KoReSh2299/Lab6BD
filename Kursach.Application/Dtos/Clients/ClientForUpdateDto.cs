namespace Kursach.Application.Dtos;

public class ClientForUpdateDto 
{
	public int Id { get; set; }
	public string Surname { get; set; }
	public string Name { get; set; }
	public string MiddleName { get; set; }
	public string Telephone { get; set; }
	public bool IsRegularClient { get; set; }
}

