using InRhythmServer.Models;
using InRhythmServer.Services.Tags;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InRhythmServer.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class TagsController(TagsService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Track>> Get(Guid id)
    {
        var tag = await service.GetAsync(id);
        if (tag == null)
            return NotFound();

        return Ok(tag);
    }

    [HttpGet("getAll")]
    public async Task<ActionResult<IEnumerable<Tag>>> GetTracks(IEnumerable<Guid> ids)
    {
        return await service.GetSomeAsync(ids);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tag>>> GetTagsPage([FromQuery] int page = 1, [FromQuery] int pageSize = 15)
    {
        return await service.GetPage(page, pageSize);
    }
    
    [HttpPost]
    public async Task<ActionResult<Tag>> Create(Tag product)
    {
        var created = await service.CreateAsync(product);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, Tag product)
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