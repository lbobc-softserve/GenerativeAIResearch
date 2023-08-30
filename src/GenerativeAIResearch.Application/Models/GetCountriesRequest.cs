namespace GenerativeAIResearch.Application.Models;

public record GetCountriesRequest(string? FilterByName = default, double? FilterByPopulation = default);
