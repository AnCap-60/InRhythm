using InRhythmServer.Models;

namespace InRhythmServer.Services;

public class TracksMockService : ITracksService
{
    public Task<Track> GetTrack(Guid trackId)
    {
        return Task.FromResult(CreateMockTrack());
    }

    public Task<List<Track>> GetTracks(IEnumerable<Guid> trackIds)
    {
        return Task.FromResult<List<Track>>([CreateMockTrack(), CreateMockTrack(), CreateMockTrack()]);
    }

    public Task<List<Track>> GetTracksWithTags(IEnumerable<Guid> tagIds)
    {
        return GetTracks(tagIds);
    }

    private Track CreateMockTrack()
    {
        Guid trackId = Guid.NewGuid();
        return new Track
        {
            Id = trackId,
            Title = "Mock track " + trackId.ToString()[..3],
            DurationSeconds = 5
        };
    }
}