using InRhythmServer.Models;

namespace InRhythmServer.Services;

public class TracksMockService : ITracksService
{
    public Task<Track> GetAsync(Guid trackId)
    {
        return Task.FromResult(CreateMockTrack());
    }

    public Task<List<Track>> GetPage(int pageNumber, int pageSize)
    {
        return GetSomeAsync([]);
    }
    
    public Task<List<Track>> GetSomeAsync(IEnumerable<Guid> trackIds)
    {
        return Task.FromResult<List<Track>>([CreateMockTrack(), CreateMockTrack(), CreateMockTrack()]);
    }

    public Task<List<Track>> GetTracksWithTagsAsync(IEnumerable<Guid> tagIds)
    {
        return GetSomeAsync(tagIds);
    }

    public Task<List<Track>> GetPersonalizedTracks(Guid userId)
    {
        return GetSomeAsync([]);
    }

    private Track CreateMockTrack()
    {
        var trackId = Guid.NewGuid();
        return new Track
        {
            Id = trackId,
            Title = "Mock track " + trackId.ToString()[..3],
            DurationSeconds = 5
        };
    }

    public Task<Track> CreateAsync(Track entity)
    {
        return Task.FromResult(entity);
    }

    public Task<bool> UpdateAsync(Guid id, Track entity)
    {
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        return Task.FromResult(true);
    }
}