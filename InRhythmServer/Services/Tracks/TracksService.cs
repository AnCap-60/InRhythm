using InRhythmServer.Models;
using Microsoft.EntityFrameworkCore;

namespace InRhythmServer.Services;

public class TracksService(Database database) : ITracksService
{
    public async Task<Track> GetAsync(Guid trackId)
    {
        return await database.Tracks.FindAsync(trackId);
    }

    public async Task<List<Track>> GetSomeAsync(IEnumerable<Guid> trackIds)
    {
        return await database.Tracks.Where(t => trackIds.Contains(t.Id)).ToListAsync();
    }
    
    public async Task<List<Track>> GetPage(int pageNumber, int pageSize)
    {
        return await database.Tracks
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<List<Track>> GetTracksWithTagsAsync(IEnumerable<Guid> tagIds)
    {
        return await database.Tracks.Where(track => !track.Tags.Select(tag => tag.Id).Except(tagIds).Any()).ToListAsync();
    }

    public Task<List<Track>> GetPersonalizedTracks(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<Track> CreateAsync(Track track)
    {
        database.Tracks.Add(track);
        await database.SaveChangesAsync();
        
        return track;
    }

    public async Task<bool> UpdateAsync(Guid id, Track entity)
    {
        var existing = await database.Tracks.FindAsync(id);
        if (existing == null)
            return false;

        database.Entry(existing).CurrentValues.SetValues(entity);
        await database.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existing = await database.Tracks.FindAsync(id);
        if (existing == null)
            return false;

        database.Tracks.Remove(existing);
        await database.SaveChangesAsync();
        return true;
    }
}