using InRhythmServer.Models;

namespace InRhythmServer.Services;

public interface ITracksService : IPaginatedService<Track>
{
    Task<List<Track>> GetTracksWithTagsAsync(IEnumerable<Guid> tagIds);
    
    Task<List<Track>> GetPersonalizedTracks(Guid userId);
}