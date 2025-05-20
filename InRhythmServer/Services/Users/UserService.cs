using InRhythmServer.Models;
using Microsoft.EntityFrameworkCore;

namespace InRhythmServer.Services.Users;

public class UserService(Database database) : IUserService
{
    public async Task<List<User>> GetSomeAsync(IEnumerable<Guid> ids)
    {
        return await database.Users.Where(u => ids.Contains(u.Id)).ToListAsync();
    }

    public async Task<User?> GetAsync(Guid id)
    {
        return await database.Users.FindAsync(id);
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