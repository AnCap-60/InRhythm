using InRhythmServer.Models;

namespace InRhythmServer.Services;

public interface ITracksService
{
    Task<Track> GetTrack(Guid trackId);
    
    Task<List<Track>> GetTracks(IEnumerable<Guid> trackIds);
    
    Task<List<Track>> GetTracksWithTags(IEnumerable<Guid> tagIds);
}