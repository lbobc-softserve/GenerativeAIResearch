namespace GenerativeAIResearch.Application.Models;

public class GetCountriesResponse
{
    public IEnumerable<GetCountryResponse> Countries { get; set; } = new List<GetCountryResponse>();
    public bool IsSuccess { get; set; } = true;
}
