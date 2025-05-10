using InRhythmServer.Models;
using InRhythmServer.Services.Users;

namespace InRhythmServer.Services.Recommendations;

public class RecommendationsByTags(IUserService userService, ITracksService tracksService) : IRecommendations
{
    public IEnumerable<Track> TracksThatMatchesWithUserTags(Guid userId)
    {
        var tracks = new List<Track>();
        
        return tracks;
    }
}