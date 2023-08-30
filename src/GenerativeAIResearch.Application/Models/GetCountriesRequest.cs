namespace GenerativeAIResearch.Application.Models;

public record GetCountriesRequest(string? FilterByName = default,
    double? FilterByPopulation = default,
    string? SortOrder = default,
    int? Limit = default);
