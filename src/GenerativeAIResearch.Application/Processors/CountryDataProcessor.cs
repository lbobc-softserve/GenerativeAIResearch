using GenerativeAIResearch.Application.Constants;
using GenerativeAIResearch.Application.Models;

namespace GenerativeAIResearch.Application.Processors;

public static class CountryDataProcessor
{
    public static IEnumerable<GetCountryResponse> FilterByCountryName(GetCountriesResponse data, string filter)
    {
        return data.Countries.Where(x => x.Name.CommonName
                             .Contains(filter, StringComparison.InvariantCultureIgnoreCase));
    }

    public static IEnumerable<GetCountryResponse> FilterByPopulation(GetCountriesResponse data, double filter)
    {
        return data.Countries.Where(x => x.Population < filter * 1000000);
    }

    public static IEnumerable<GetCountryResponse> SortByCountryName(GetCountriesResponse data, string sortOrder)
    {
        if (sortOrder == SortOrderConstants.OrderByAscending)
        {
            return data.Countries.OrderBy(x => x.Name.CommonName);
        }
        if (sortOrder == SortOrderConstants.OrderByDescending)
        {
            return data.Countries.OrderByDescending(x => x.Name.CommonName);
        }
        return data.Countries;
    }
}
