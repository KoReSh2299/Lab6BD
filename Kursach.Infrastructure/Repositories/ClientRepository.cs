using Microsoft.EntityFrameworkCore;
using Kursach.Domain.Entities;
using Kursach.Domain.Abstractions;
using Kursach.Domain.Utilities;
using Kursach.Domain.Filters;

namespace Kursach.Infrastructure.Repositories;

public class ClientRepository(AppDbContext dbContext) : IClientRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task Create(Client entity) => await _dbContext.Clients.AddAsync(entity);

    public async Task<IEnumerable<Client>> Get(bool trackChanges) =>
        await (!trackChanges 
            ? _dbContext.Clients.AsNoTracking() 
            : _dbContext.Clients).ToListAsync();

    public async Task<Client?> GetById(int id, bool trackChanges) =>
        await (!trackChanges ?
            _dbContext.Clients.AsNoTracking() :
            _dbContext.Clients).SingleOrDefaultAsync(e => e.Id == id);

    public void Delete(Client entity) => _dbContext.Clients.Remove(entity);
    public void Delete(int id) => _dbContext.Clients.Remove(_dbContext.Clients.First(x => x.Id == id));

    public void Update(Client entity) => _dbContext.Clients.Update(entity);

    public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

    public async Task<PaginatedList<Client>> GetFilteredPageAsync(int page, int pageSize, ClientFilter filter, bool trackChanges)
    {
        var query = _dbContext.Clients.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Name))
        {
            query = query.Where(x => x.Name.Contains(filter.Name));
        }

        if (!string.IsNullOrEmpty(filter.Surname))
        {
            query = query.Where(x => x.Surname.Contains(filter.Surname));
        }

        if (!string.IsNullOrEmpty(filter.MiddleName))
        {
            query = query.Where(x => x.MiddleName.Contains(filter.MiddleName));
        }

        if (!string.IsNullOrEmpty(filter.Telephone))
        {
            query = query.Where(x => x.Telephone.Contains(filter.Telephone));
        }

        if (filter.IsRegularClient != null)
        {
            query = query.Where(x => x.IsRegularClient ==  filter.IsRegularClient);
        }

        return await (!trackChanges
            ? PaginatedList<Client>.Create(query.AsNoTracking(), page, pageSize)
            : PaginatedList<Client>.Create(query, page, pageSize));
    }
}

