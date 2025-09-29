using System;
using BAUST_Book_Store.Data;
using BAUST_Book_Store.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BAUST_Book_Store.Repositories;

public class SQLProfileRepository : IProfileRepository
{
    private readonly BookExchangeDbContext dbContext;

    public SQLProfileRepository(BookExchangeDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<UserProfile> CreateUserAsync(UserProfile user)
    {
        dbContext.Add(user);
        await dbContext.SaveChangesAsync();
        return user;  
    }

    public async Task DeleteUserByIdAsync(long id)
    {
        var user = await dbContext.UserProfiles.FirstOrDefaultAsync(c => c.Id == id);
        if (user is null)
        {
            throw new KeyNotFoundException($"Book with id {id} not found");
        }
        dbContext.UserProfiles.Remove(user);
        await dbContext.SaveChangesAsync();
    }

    public Task<List<UserProfile>> GetAllUserAsync()
    {
        var usersQuery = dbContext.UserProfiles.ToListAsync();
        return usersQuery;
    }

    public async Task<UserProfile?> GetUserByIdAsync(long id)
    {
        var user = await dbContext.UserProfiles.FirstOrDefaultAsync(c => c.Id == id);
        if (user is null)
        {
            return null;
        }
        return user;
    }

    public async Task<UserProfile?> UpdateUserAsync(long id, UserProfile user)
    {
        var existingUser = await dbContext.UserProfiles.FirstOrDefaultAsync(c => c.Id == id);
        if (existingUser is null)
        {
            return null;
        }

        existingUser.FullName = user.FullName;
        existingUser.Email = user.Email;
        existingUser.PhoneNumber = user.PhoneNumber;
        await dbContext.SaveChangesAsync();
        return existingUser;
    }
}