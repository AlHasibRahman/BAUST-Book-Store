using System;
using BAUST_Book_Store.Models.Domain;

namespace BAUST_Book_Store.Repositories;

public interface IProfileRepository
{
    Task<List<UserProfile>> GetAllUserAsync();
    Task<UserProfile?> GetUserByIdAsync(long id);
    Task<UserProfile> CreateUserAsync(UserProfile user);
    Task<UserProfile?> UpdateUserAsync(long id, UserProfile user);
    Task DeleteUserByIdAsync(long id);
}
