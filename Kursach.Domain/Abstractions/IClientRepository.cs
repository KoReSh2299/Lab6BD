using Kursach.Domain.Entities;
using Kursach.Domain.Utilities;
using Kursach.Domain.Filters;

namespace Kursach.Domain.Abstractions;

public interface IClientRepository 
{
	Task<IEnumerable<Client>> Get(bool trackChanges);
	Task<Client?> GetById(int id, bool trackChanges);
    Task Create(Client entity);
    void Delete(Client entity);
    void Delete(int id);
    void Update(Client entity);
    Task SaveChangesAsync();
    Task<PaginatedList<Client>> GetFilteredPageAsync(int page, int pageSize, ClientFilter client, bool trackChanges);
}

