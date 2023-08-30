using GenerativeAIResearch.Application.Handlers;
using GenerativeAIResearch.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace GenerativeAIResearch.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{
    private readonly IRequestHandler<GetCountriesRequest, IEnumerable<GetCountryResponse>> _getCountiresHandler;

    public CountriesController(IRequestHandler<GetCountriesRequest, IEnumerable<GetCountryResponse>> getCountiresHandler)
    {
        _getCountiresHandler = getCountiresHandler;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetCountryResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<GetCountryResponse>>> Get()
    {
        var request = new GetCountriesRequest();
        var response = await _getCountiresHandler.Handle(request);
        return Ok(response);
    }
}
