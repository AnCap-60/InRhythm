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
        return await service.GetTrack(id);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Track>>> GetTracks(IEnumerable<Guid> ids)
    {
        return await service.GetTracks(ids);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Track>>> GetTracks(params Guid[] ids)
    {
        return await service.GetTracks(ids);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Track>>> GetPersonalizedTracks(Guid userId)
    {
        throw new NotImplementedException();
    }
}