using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Auth.Domain.Entities;
using Auth.Domain.Pagination;

namespace Auth.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<PageList<User>> GetAllAsync(PageParams pageParams);
        Task<PageList<User>> GetAllActiveUsersAsync(PageParams pageParams);
        Task<bool> ExistsByEmailAsync(string email);
        Task<bool> ExistsByIdAsync(int id);
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);
        Task<User?> GetByEmailAndPasswordAsync(string email, string password);
        Task<bool> ValidateCredentialsAsync(string email, string password);
    }
}