using Kursach.Domain.Entities;
using Kursach.Domain.Filters;
using Kursach.Domain.Utilities;

namespace Kursach.Domain.Abstractions;

public interface IParkingSpaceRepository 
{
	Task<IEnumerable<ParkingSpace>> Get(bool trackChanges);
	Task<ParkingSpace?> GetById(int id, bool trackChanges);
    Task Create(ParkingSpace entity);
    void Delete(ParkingSpace entity);
    void Delete(int id);
    void Update(ParkingSpace entity);
    Task SaveChangesAsync();
    Task<PaginatedList<ParkingSpace>> GetFilteredPageAsync(int page, int pageSize, ParkingSpaceFilter parkingSpace, bool trackChanges);
}

