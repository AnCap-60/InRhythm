using InRhythmServer.Models;

namespace InRhythmServer.Services.Users;

public interface IUserService : IPaginatedService<User>
{
    Task<User?> GetByUsernameAsync(string username);

    Task RegisterAsync(string username, string password);

    Task<bool> ValidateCredentialsAsync(string username, string password);
}