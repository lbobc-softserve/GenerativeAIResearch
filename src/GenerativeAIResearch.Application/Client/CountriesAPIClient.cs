using GenerativeAIResearch.Application.Config;
using GenerativeAIResearch.Application.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace GenerativeAIResearch.Application.Client;

public class CountriesApiClient
{
    private readonly HttpClient _httpClient;
    private readonly CountriesApiOptions _options;

    public CountriesApiClient(HttpClient httpClient, IOptions<CountriesApiOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
        var uri = new Uri(_options.Url);
        _httpClient.BaseAddress = uri;
    }

    public async Task<IEnumerable<GetCountryResponse>> GetAsync()
    {
        var response = await _httpClient.GetAsync("/v3.1/all");
        var result = JsonSerializer.Deserialize<IEnumerable<GetCountryResponse>>(response.Content.ReadAsStream());
        return result;
    }
}
