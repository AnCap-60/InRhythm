using InRhythmServer.Models;

namespace InRhythmServer.Services.Users;

public class UserMockService : IUserService
{
    public Task<List<User>> GetPage(int page = 1, int pageSize = 10)
    {
        return Task.FromResult<List<User>>([CreateMockUser(), CreateMockUser(), CreateMockUser()]);
    }

    private User CreateMockUser()
    {
        var userId = Guid.NewGuid();
        return new User
        {
            Id = userId,
            Username = "MockUser" + userId.ToString()[..3]
        };
    }

    public Task<List<User>> GetSomeAsync(IEnumerable<Guid> ids)
    {
        return Task.FromResult(ids.Select(x => CreateMockUser()).ToList());
    }

    public Task<User?> GetAsync(Guid id)
    {
        return Task.FromResult<User?>(CreateMockUser());
    }

    public Task<User> CreateAsync(User entity)
    {
        return Task.FromResult(entity);
    }

    public Task<bool> UpdateAsync(Guid id, User entity)
    {
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        return Task.FromResult(true);
    }

    public Task<User?> GetByUsernameAsync(string username)
    {
        return Task.FromResult<User?>(CreateMockUser());
    }

    public Task RegisterAsync(string username, string password)
    {
        return Task.CompletedTask;
    }

    public Task<bool> ValidateCredentialsAsync(string username, string password)
    {
        return Task.FromResult(true);
    }
}