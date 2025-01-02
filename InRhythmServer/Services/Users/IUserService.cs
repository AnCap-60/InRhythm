using InRhythmServer.Models;

namespace InRhythmServer.Services.Users;

public interface IUserService
{
    public Task<List<User>> GetUsers();
    
    public Task<User> GetUser(Guid userId);
}