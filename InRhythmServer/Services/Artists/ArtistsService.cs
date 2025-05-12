using InRhythmServer.Models;
using Microsoft.EntityFrameworkCore;

namespace InRhythmServer.Services.Artists;

public class ArtistsService(Database database) : IArtistsService
{
    public async Task<Artist?> GetAsync(Guid id)
    {
        return await database.Artists.FindAsync(id);
    }

    public async Task<List<Artist>> GetSomeAsync(IEnumerable<Guid> ids)
    {
        return await database.Artists.Where(a => ids.Contains(a.Id)).ToListAsync();
    }
    
    public async Task<List<Artist>> GetPage(int pageNumber, int pageSize)
    {
        return await database.Artists
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Artist> CreateAsync(Artist artist)
    {
        database.Artists.Add(artist);
        await database.SaveChangesAsync();
        
        return artist;
    }

    public async Task<bool> UpdateAsync(Guid id, Artist entity)
    {
        var existing = await database.Artists.FindAsync(id);
        if (existing == null)
            return false;

        database.Entry(existing).CurrentValues.SetValues(entity);
        await database.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existing = await database.Artists.FindAsync(id);
        if (existing == null)
            return false;

        database.Artists.Remove(existing);
        await database.SaveChangesAsync();
        return true;
    }
}