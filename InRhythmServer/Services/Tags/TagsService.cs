using InRhythmServer.Models;
using Microsoft.EntityFrameworkCore;

namespace InRhythmServer.Services.Tags;

public class TagsService(Database database) : IPaginatedService<Tag>
{
    public async Task<Tag?> GetAsync(Guid trackId)
    {
        return await database.Tags.FindAsync(trackId);
    }

    public async Task<List<Tag>> GetSomeAsync(IEnumerable<Guid> ids)
    {
        return await database.Tags.Where(t => ids.Contains(t.Id)).ToListAsync();
    }

    public async Task<List<Tag>> GetPage(int pageNumber, int pageSize)
    {
        return await database.Tags
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Tag> CreateAsync(Tag tag)
    {
        database.Tags.Add(tag);
        await database.SaveChangesAsync();

        return tag;
    }

    public async Task<bool> UpdateAsync(Guid id, Tag entity)
    {
        var existing = await database.Tags.FindAsync(id);
        if (existing == null)
            return false;

        database.Entry(existing).CurrentValues.SetValues(entity);
        await database.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existing = await database.Tags.FindAsync(id);
        if (existing == null)
            return false;

        database.Tags.Remove(existing);
        await database.SaveChangesAsync();
        return true;
    }
}