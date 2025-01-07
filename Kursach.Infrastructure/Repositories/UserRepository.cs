using Kursach.Domain.Abstractions;
using Kursach.Domain.Entities;
using Kursach.Domain.Filters;
using Kursach.Domain.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Kursach.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext dbContext) : IUserRepository
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task Create(User entity) => await _dbContext.Users.AddAsync(entity);

        public async Task<IEnumerable<User>> Get(bool trackChanges) =>
            await (!trackChanges
                ? _dbContext.Users.AsNoTracking()
                : _dbContext.Users).ToListAsync();

        public async Task<User?> GetById(int id, bool trackChanges) =>
            await (!trackChanges ?
                _dbContext.Users.AsNoTracking() :
                _dbContext.Users).SingleOrDefaultAsync(e => e.Id == id);

        public async Task<User?> GetByUsername(string username, bool trackChanges) =>
           await (!trackChanges ?
               _dbContext.Users.AsNoTracking() :
               _dbContext.Users).SingleOrDefaultAsync(e => e.Username == username);

        public void Delete(User entity) => _dbContext.Users.Remove(entity);
        public void Delete(int id) => _dbContext.Users.Remove(_dbContext.Users.First(x => x.Id == id));

        public void Update(User entity) => _dbContext.Users.Update(entity);

        public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

        public async Task<PaginatedList<User>> GetFilteredPageAsync(int page, int pageSize, UserFilter filter, bool trackChanges)
        {
            var query = _dbContext.Users.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Username))
            {
                query = query.Where(x => x.Username.Contains(filter.Username));
            }

            if (!string.IsNullOrEmpty(filter.Role))
            {
                query = query.Where(x => x.Role.Contains(filter.Role));
            }

            var minCreatedAt = filter.MinCreatedAt ?? new DateTime(1754, 1, 1);
            var maxCreatedAt = filter.MaxCreatedAt ?? new DateTime(9999, 12, 31);

            query = query.Where(x => x.CreatedAt >=  minCreatedAt && x.CreatedAt <= maxCreatedAt);

            return await (!trackChanges
                ? PaginatedList<User>.Create(query.AsNoTracking(), page, pageSize)
                : PaginatedList<User>.Create(query, page, pageSize));
        }
    }
}
