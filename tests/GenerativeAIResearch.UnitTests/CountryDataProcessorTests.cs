using GenerativeAIResearch.Application.Models;
using GenerativeAIResearch.Application.Processors;

namespace GenerativeAIResearch.UnitTests;

public class CountryDataProcessorTests
{
    private readonly GetCountriesResponse _data;

    public CountryDataProcessorTests()
    {
        _data = new GetCountriesResponse();
        _data!.Countries = new List<GetCountryResponse>()
        {
            new GetCountryResponse()
            {
                Name = new CountryName()
                {
                    CommonName = "Aruba",
                },
                Population = 1000000
            },
            new GetCountryResponse()
            {
                Name = new CountryName()
                {
                    CommonName = "Argentina",
                },
                Population = 2000000
            },
            new GetCountryResponse()
            {
                Name = new CountryName()
                {
                    CommonName = "Armenia",
                },
                Population = 500000
            },
            new GetCountryResponse()
            {
                Name = new CountryName()
                {
                    CommonName = "Bulgaria",
                },
                Population = 7000000
            },
            new GetCountryResponse()
            {
                Name = new CountryName()
                {
                    CommonName = "Ukraine",
                },
                Population = 20000000
            }
        };
    }

    [Fact]
    public void Should_Filter_By_Country_Name()
    {
        // Arrange
        var input = "ar";

        // Act
        var result = CountryDataProcessor.FilterByCountryName(_data, input);

        // Assert
        var expected = result.All(x => x.Name.CommonName.Contains(input, StringComparison.InvariantCultureIgnoreCase));
        Assert.True(expected);
    }

    [Fact]
    public void Should_Filter_By_Population()
    {
        // Arrange
        var input = 2;

        // Act
        var result = CountryDataProcessor.FilterByPopulation(_data, input);

        // Assert
        var expected = result.All(x => x.Population < input * 1000000);
        Assert.True(expected);
    }

    [Fact]
    public void Should_Sort_By_CountryName_Ascending()
    {
        // Arrange
        var input = "ascend";

        // Act
        var result = CountryDataProcessor.SortByCountryName(_data, input);

        // Assert
        var expected = _data.Countries.OrderBy(x => x.Name.CommonName);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Should_Sort_By_CountryName_Descending()
    {
        // Arrange
        var input = "descend";

        // Act
        var result = CountryDataProcessor.SortByCountryName(_data, input);

        // Assert
        var expected = _data.Countries.OrderByDescending(x => x.Name.CommonName);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Should_Limit_Result_Count()
    {
        // Arrange
        var input = 2;

        // Act
        var result = CountryDataProcessor.Limit(_data, input);

        // Assert
        Assert.True(result.Count() == input);
    }
}







