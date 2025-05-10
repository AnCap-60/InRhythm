using InRhythmServer.Models;

namespace InRhythmServer.Services.Users;

public class UserService : IUserService
{
    // ordering?
    public async Task<List<User>> GetUsers(int page = 1, int pageSize = 10)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetUsers()
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUser(Guid userId)
    {
        throw new NotImplementedException();
    }
}