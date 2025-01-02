using InRhythmServer.Models;
using Microsoft.EntityFrameworkCore;

namespace InRhythmServer.Services;

public class TracksService(Database database) : ITracksService
{
    public async Task<Track> GetTrack(Guid trackId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Track>> GetTracks(IEnumerable<Guid> trackIds)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Track>> GetTracksWithTags(IEnumerable<Guid> tagIds)
    {
        return await database.Tracks.Where(track => !track.Tags.Select(tag => tag.Id).Except(tagIds).Any()).ToListAsync();
    }
}