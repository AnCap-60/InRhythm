using System.Security.Cryptography;
using System.Text;
using InRhythmServer.Models;
using Microsoft.EntityFrameworkCore;

namespace InRhythmServer.Services.Users;

public class UserService(Database database) : IUserService
{
    public async Task RegisterAsync(string username, string password)
    {
        var hash = HashPassword(password);
        database.Users.Add(new User { Username = username, PasswordHash = hash });
        await database.SaveChangesAsync();
    }

    public async Task<bool> ValidateCredentialsAsync(string username, string password)
    {
        var user = await database.Users.FirstOrDefaultAsync(u => u.Username == username);
        if (user == null) return false;

        return user.PasswordHash == HashPassword(password);
    }

    private static string HashPassword(string password)
    {
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = SHA256.HashData(bytes);
        return Convert.ToBase64String(hash);
    }

    public async Task<List<User>> GetSomeAsync(IEnumerable<Guid> ids)
    {
        return await database.Users.Where(u => ids.Contains(u.Id)).ToListAsync();
    }

    public async Task<User?> GetAsync(Guid id)
    {
        return await database.Users.FindAsync(id);
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await database.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<User> CreateAsync(User entity)
    {
        database.Users.Add(entity);
        await database.SaveChangesAsync();
        
        return entity;
    }

    public async Task<bool> UpdateAsync(Guid id, User entity)
    {
        var existing = await database.Users.FindAsync(id);
        if (existing == null)
            return false;

        database.Entry(existing).CurrentValues.SetValues(entity);
        await database.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existing = await database.Users.FindAsync(id);
        if (existing == null)
            return false;

        database.Users.Remove(existing);
        await database.SaveChangesAsync();
        return true;
    }

    public async Task<List<User>> GetPage(int pageNumber, int pageSize)
    {
        return await database.Users
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}