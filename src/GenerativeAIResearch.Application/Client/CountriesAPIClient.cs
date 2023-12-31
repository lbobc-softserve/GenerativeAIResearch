﻿using GenerativeAIResearch.Application.Config;
using GenerativeAIResearch.Application.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace GenerativeAIResearch.Application.Client;

public class CountriesApiClient
{
    private readonly HttpClient _httpClient;

    public CountriesApiClient(HttpClient httpClient, IOptions<CountriesApiOptions> options)
    {
        _httpClient = httpClient;
        var uri = new Uri(options.Value.Url);
        _httpClient.BaseAddress = uri;
    }

    public async Task<GetCountriesResponse> GetAsync()
    {
        var response = await _httpClient.GetAsync("/v3.1/all");
        if (!response.IsSuccessStatusCode)
        {
            return new GetCountriesResponse() { IsSuccess = false };
        }
        var result = JsonSerializer.Deserialize<IEnumerable<GetCountryResponse>>(response.Content.ReadAsStream());
        var countriesResponse = new GetCountriesResponse()
        {
            IsSuccess = true,
            Countries = result!
        };
        return countriesResponse;
    }
}
