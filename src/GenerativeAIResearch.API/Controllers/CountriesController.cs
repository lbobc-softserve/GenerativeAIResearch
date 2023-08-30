using GenerativeAIResearch.Application.Handlers;
using GenerativeAIResearch.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace GenerativeAIResearch.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{
    private readonly IRequestHandler<GetCountriesRequest, GetCountriesResponse> _getCountiresHandler;

    public CountriesController(IRequestHandler<GetCountriesRequest, GetCountriesResponse> getCountiresHandler)
    {
        _getCountiresHandler = getCountiresHandler;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCountriesResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<GetCountriesResponse>> Get(string? filter)
    {
        var request = new GetCountriesRequest(filter);
        var response = await _getCountiresHandler.Handle(request);
        if (!response.IsSuccess)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        return Ok(response);
    }
}
