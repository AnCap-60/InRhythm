using InRhythmServer.Models;
using InRhythmServer.Services.Users;

namespace InRhythmServer.Services.Tracks;

public class Recommendations(IUserService userService, ITracksService tracksService)
{
    public IEnumerable<Track> TracksThatMatchesWithUserTags(Guid userId)
    {
        var tracks = new List<Track>();
        
        return tracks;
    }
}