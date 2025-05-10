using InRhythmServer.Models;

namespace InRhythmServer.Services.Users;

public interface IUserService
{
    public Task<List<User>> GetUsers(int page = 1, int pageSize = 10);
    
    public Task<User> GetUser(Guid userId);
}