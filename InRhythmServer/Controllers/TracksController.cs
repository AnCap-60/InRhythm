using InRhythmServer.Models;
using InRhythmServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace InRhythmServer.Controllers;

[Route("api/Tracks")]
[ApiController]
public class TracksController(ITracksService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Track>> GetTrack(Guid id)
    {
        var track = await service.GetAsync(id);
        if (track == null)
            return NotFound();

        return Ok(track);
    }

    [HttpGet("getTracks")]
    public async Task<ActionResult<IEnumerable<Track>>> GetTracks(IEnumerable<Guid> ids)
    {
        return await service.GetSomeAsync(ids);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Track>>> GetTracksPage([FromQuery] int page = 1, [FromQuery] int pageSize = 15)
    {
        return await service.GetPage(page, pageSize);
    }
    
    [HttpGet("getPersonalizedTracks")]
    public async Task<ActionResult<IEnumerable<Track>>> GetPersonalizedTracks(Guid userId)
    {
        return await service.GetPersonalizedTracks(userId);
    }
    
    [HttpPost]
    public async Task<ActionResult<Track>> Create(Track product)
    {
        var created = await service.CreateAsync(product);
        return CreatedAtAction(nameof(GetTrack), new { id = created.Id }, created);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, Track product)
    {
        if (id != product.Id)
            return BadRequest("ID mismatch");

        var success = await service.UpdateAsync(id, product);
        if (!success)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await service.DeleteAsync(id);
        if (!success)
            return NotFound();

        return NoContent();
    }
}