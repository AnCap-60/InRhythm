namespace InRhythmServer.Services.Recommendations;

public interface IRecommendations<T>
{
    public Task<List<T>> GetRecommendedAsync(Guid userId);
}