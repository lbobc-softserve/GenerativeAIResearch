using GenerativeAIResearch.Application.Client;
using GenerativeAIResearch.Application.Models;
using GenerativeAIResearch.Application.Processors;

namespace GenerativeAIResearch.Application.Handlers;

public class GetCountriesRequestHandler : IRequestHandler<GetCountriesRequest, GetCountriesResponse>
{
    private readonly CountriesApiClient _httpClient;

    public GetCountriesRequestHandler(CountriesApiClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetCountriesResponse> Handle(GetCountriesRequest request)
    {
        var httpResponse = await _httpClient.GetAsync();
        if (request.FilterByName != null)
        {
            httpResponse.Countries = CountryDataProcessor.FilterByCountryName(httpResponse, request.FilterByName);
        }
        if (request.FilterByPopulation != null)
        {

            httpResponse.Countries = CountryDataProcessor.FilterByPopulation(httpResponse, (double)request.FilterByPopulation);
        }
        if(request.SortOrder != null)
        {
            httpResponse.Countries = CountryDataProcessor.SortByCountryName(httpResponse, request.SortOrder);
        }
        if(request.Limit != null)
        {
            httpResponse.Countries = CountryDataProcessor.Limit(httpResponse, (int)request.Limit);
        }

        return httpResponse;
    }
}
