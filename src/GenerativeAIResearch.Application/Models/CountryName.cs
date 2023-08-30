using System.Text.Json.Serialization;

namespace GenerativeAIResearch.Application.Models;

public class CountryName
{
    [JsonPropertyName("common")]
    public string CommonName { get; set; } = string.Empty;
}
