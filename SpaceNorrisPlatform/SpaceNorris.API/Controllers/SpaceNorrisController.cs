using Microsoft.AspNetCore.Mvc;
using SpaceNorris.API.Application.Tools;

namespace SpaceNorris.API.Controllers;

[ApiController]
[Route("/")]
public class SpaceNorrisController: ControllerBase
{
    private readonly ChuckNorrisApi _chuckNorrisApi;
    private readonly StarWarsApi _starWarsApi;
    private readonly ILogger<SpaceNorrisController> _logger;

    public SpaceNorrisController(ChuckNorrisApi chuckNorrisApi, StarWarsApi starWarsApi, ILogger<SpaceNorrisController> logger)
    {
        _chuckNorrisApi = chuckNorrisApi;
        _starWarsApi = starWarsApi;
        _logger = logger;
    }
    
    [HttpGet("swapi/people")]
    public async Task<ActionResult> People()
    {
        try
        {
            var people = await _starWarsApi.PeopleAsync();
            
            return new OkObjectResult(people);
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult("Oops! Something went wrong. The force is not with you.");
        }
    }

    [HttpGet("chuck/categories")]
    public ActionResult Categories()
    {
        try
        {
            return new OkObjectResult(_chuckNorrisApi.Categories);
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult("Oops! Something went wrong. Chuck Norris can compile syntax errors.");
        }
    }
    
    //TODO Need to search both APIs
    [HttpGet("chuck/search")]
    public async Task<ActionResult> Search(string query)
    {
        try
        {
            var jokes = await _chuckNorrisApi.SearchAsync(query);
            
            return new OkObjectResult(jokes);
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult("Oops! Something went wrong. Chuck Norris can compile syntax errors.");
        }
    }
}