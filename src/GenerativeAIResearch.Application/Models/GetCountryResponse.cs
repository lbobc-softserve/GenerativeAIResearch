using System.Text.Json.Serialization;

namespace GenerativeAIResearch.Application.Models;

public class GetCountryResponse
{
    [JsonPropertyName("name")]
    public CountryName Name { get; set; } = new CountryName();

    [JsonPropertyName("population")]
    public long Population { get; set; }
}