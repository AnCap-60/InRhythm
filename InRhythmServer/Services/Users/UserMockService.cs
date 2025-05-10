using InRhythmServer.Models;

namespace InRhythmServer.Services.Users;

public class UserMockService : IUserService
{
    public Task<List<User>> GetUsers(int page = 1, int pageSize = 10)
    {
        return Task.FromResult<List<User>>([CreateMockUser(), CreateMockUser(), CreateMockUser()]);
    }

    public Task<User> GetUser(Guid userId)
    {
        return Task.FromResult(CreateMockUser());
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
}