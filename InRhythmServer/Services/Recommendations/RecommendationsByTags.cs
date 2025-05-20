using InRhythmServer.Models;
using InRhythmServer.Services.Users;
using Microsoft.EntityFrameworkCore;

namespace InRhythmServer.Services.Recommendations;

public class RecommendationsByTags(IUserService userService, Database database) : IRecommendations<Track>
{
    public async Task<List<Track>> GetRecommendedAsync(Guid userId)
    {
        var user = await userService.GetAsync(userId);
        if (user == null)
            return [];

        var top3UserTagsByFrequency = user.SavedTracks
            .SelectMany(u => u.Tags)
            .GroupBy(tag => tag)
            .ToDictionary(group => group.Key, group => group.Count())
            .OrderByDescending(pair => pair.Value)
            .Take(3)
            .Select(pair => pair.Key)
            .ToArray();

        return await database.Tracks
            .Where(t => t.Tags
                .Intersect(top3UserTagsByFrequency)
                .Any()
            ).ToListAsync();
    }
}