using GenerativeAIResearch.Application.Client;
using GenerativeAIResearch.Application.Models;

namespace GenerativeAIResearch.Application.Handlers;

public class GetCountriesRequestHandler : IRequestHandler<GetCountriesRequest, IEnumerable<GetCountryResponse>>
{
    private readonly CountriesApiClient _httpClient;

    public GetCountriesRequestHandler(CountriesApiClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<GetCountryResponse>> Handle(GetCountriesRequest request)
    {
        return await _httpClient.GetAsync();
    }
}
