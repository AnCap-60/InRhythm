using InRhythmServer.Services;
using InRhythmServer.Services.Artists;
using InRhythmServer.Services.Recommendations;
using InRhythmServer.Services.Tags;
using InRhythmServer.Services.Users;

namespace InRhythmServer;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
                .AddScoped<TagsService>()
                .AddScoped<ITracksService, TracksService>()
                .AddScoped<IArtistsService, ArtistsService>()
                .AddScoped<IUserService, UserService>()
            ;
    }

    public static IServiceCollection AddMockServices(this IServiceCollection services)
    {
        return services
                .AddScoped<ITracksService, TracksMockService>()
                .AddScoped<IArtistsService, ArtistsMockService>()
                .AddScoped<IUserService, UserMockService>()
            ;
    }

    public static IServiceCollection AddUtils(this IServiceCollection services)
    {
        return services
                .AddScoped<IRecommendations, RecommendationsByTags>()
            ;
    }
}