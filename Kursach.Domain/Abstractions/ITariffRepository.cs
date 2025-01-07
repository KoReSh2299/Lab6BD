using Kursach.Domain.Entities;
using Kursach.Domain.Filters;
using Kursach.Domain.Utilities;

namespace Kursach.Domain.Abstractions;

public interface ITariffRepository 
{
	Task<IEnumerable<Tariff>> Get(bool trackChanges);
	Task<Tariff?> GetById(int id, bool trackChanges);
    Task Create(Tariff entity);
    void Delete(Tariff entity);
    void Delete(int id);
    void Update(Tariff entity);
    Task SaveChangesAsync();
    Task<PaginatedList<Tariff>> GetFilteredPageAsync(int page, int pageSize, TariffFilter filter, bool trackChanges);
}

