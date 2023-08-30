using GenerativeAIResearch.Application.Client;
using GenerativeAIResearch.Application.Models;
using GenerativeAIResearch.Application.Processors;

namespace GenerativeAIResearch.Application.Handlers;

public class GetCountriesRequestHandler : IRequestHandler<GetCountriesRequest, GetCountriesResponse>
{
    private readonly CountriesApiClient _httpClient;
    private readonly CountryDataProcessor _processor;

    public GetCountriesRequestHandler(CountriesApiClient httpClient, CountryDataProcessor processor)
    {
        _httpClient = httpClient;
        _processor = processor;
    }

    public async Task<GetCountriesResponse> Handle(GetCountriesRequest request)
    {
        var httpResponse = await _httpClient.GetAsync();
        if (request.FilterByName != null)
        {
            httpResponse.Countries = _processor.FilterByCountryName(httpResponse, request.FilterByName);
        }
        if (request.FilterByPopulation != null)
        {

            httpResponse.Countries = _processor.FilterByPopulation(httpResponse, (double)request.FilterByPopulation);
        }
        return httpResponse;
    }
}
