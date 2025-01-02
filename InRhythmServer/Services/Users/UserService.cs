using InRhythmServer.Models;

namespace InRhythmServer.Services.Users;

public class UserService
{
    // ordering?
    public async Task<List<User>> GetUsers(int page = 1, int pageSize = 10)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUser(Guid userId)
    {
        throw new NotImplementedException();
    }
}