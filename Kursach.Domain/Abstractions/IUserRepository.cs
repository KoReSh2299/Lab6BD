using Kursach.Domain.Entities;
using Kursach.Domain.Utilities;
using Kursach.Domain.Filters;

namespace Kursach.Domain.Abstractions
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> Get(bool trackChanges);
        Task<User?> GetById(int id, bool trackChanges);
        Task<User?> GetByUsername(string username, bool trackChanges);
        Task Create(User entity);
        void Delete(User entity);
        void Delete(int id);
        void Update(User entity);
        Task SaveChangesAsync();
        Task<PaginatedList<User>> GetFilteredPageAsync(int pageIndex, int pageSize, UserFilter userFilter, bool trackChanges);
    }
}
