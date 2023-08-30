using GenerativeAIResearch.Application.Models;

namespace GenerativeAIResearch.Application.Processors;

public class CountryDataProcessor
{
    public List<GetCountryResponse> FilterByCountryName(GetCountriesResponse data, string filter)
    {
        return data.Countries.Where(x => x.Name.CommonName
                             .Contains(filter, StringComparison.InvariantCultureIgnoreCase))
                             .ToList();
    }

    public List<GetCountryResponse> FilterByPopulation(GetCountriesResponse data, double filter)
    {
        return data.Countries.Where(x => x.Population < filter * 1000000).ToList();
    }
}
