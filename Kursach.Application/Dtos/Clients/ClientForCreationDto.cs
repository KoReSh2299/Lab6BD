using System.Text.Json.Serialization;

namespace Kursach.Application.Dtos;

public class ClientForCreationDto 
{
    [JsonPropertyName("surname")]
    public string Surname { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("middleName")]
    public string MiddleName { get; set; }
    [JsonPropertyName("telephone")]
    public string Telephone { get; set; }
    [JsonPropertyName("isRegularClient")]
    public bool IsRegularClient { get; set; }
}

