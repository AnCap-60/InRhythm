using InRhythmServer.Services;
using InRhythmServer.Services.Recommendations;
using InRhythmServer.Services.Tags;
using InRhythmServer.Services.Users;

namespace InRhythmServer;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
                .AddSingleton<TagsService>()
                .AddSingleton<ITracksService, TracksService>()
                .AddSingleton<IUserService, UserService>()
            ;
    }

    public static IServiceCollection AddMockServices(this IServiceCollection services)
    {
        return services
                .AddSingleton<ITracksService, TracksMockService>()
                .AddSingleton<IUserService, UserMockService>()
            ;
    }

    public static IServiceCollection AddUtils(this IServiceCollection services)
    {
        return services
                .AddSingleton<IRecommendations, RecommendationsByTags>()
            ;
    }
}