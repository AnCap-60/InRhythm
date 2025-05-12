using InRhythmServer.Models;
using InRhythmServer.Services.Artists;
using Microsoft.AspNetCore.Mvc;

namespace InRhythmServer.Controllers;

[Route("api/Artists")]
[ApiController]
public class ArtistsController(IArtistsService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Artist>> GetArtist(Guid id)
    {
        var artist = await service.GetAsync(id);
        if (artist == null)
            return NotFound();

        return Ok(artist);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Artist>>> GetArtistsPage([FromQuery] int page = 1, [FromQuery] int pageSize = 15)
    {
        return await service.GetPage(page, pageSize);
    }
}