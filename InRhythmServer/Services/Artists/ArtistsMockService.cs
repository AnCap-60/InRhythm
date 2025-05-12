using InRhythmServer.Models;

namespace InRhythmServer.Services.Artists;

public class ArtistsMockService : IArtistsService
{
    public Task<Artist> GetAsync(Guid trackId)
    {
        return Task.FromResult(CreateMockArtist());
    }

    public Task<List<Artist>> GetPage(int pageNumber, int pageSize)
    {
        return GetSomeAsync([]);
    }
    
    public Task<List<Artist>> GetSomeAsync(IEnumerable<Guid> ids)
    {
        return Task.FromResult<List<Artist>>([CreateMockArtist(), CreateMockArtist(), CreateMockArtist()]);
    }

    private Artist CreateMockArtist()
    {
        var id = Guid.NewGuid();
        return new Artist
        {
            Id = id,
            Name = "Unnamed singer " + id.ToString()[..3],
        };
    }

    public Task<Artist> CreateAsync(Artist entity)
    {
        return Task.FromResult(entity);
    }

    public Task<bool> UpdateAsync(Guid id, Artist entity)
    {
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        return Task.FromResult(true);
    }
}