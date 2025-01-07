using Microsoft.EntityFrameworkCore;
using Kursach.Domain.Entities;
using Kursach.Domain.Abstractions;
using Kursach.Domain.Utilities;
using Kursach.Domain.Filters;

namespace Kursach.Infrastructure.Repositories;

public class ParkingSpaceRepository(AppDbContext dbContext) : IParkingSpaceRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task Create(ParkingSpace entity) => await _dbContext.ParkingSpaces.AddAsync(entity);

    public async Task<IEnumerable<ParkingSpace>> Get(bool trackChanges) =>
        await (!trackChanges 
            ? _dbContext.ParkingSpaces.OrderBy(x => x.Id).Include(e => e.Car).AsNoTracking() 
            : _dbContext.ParkingSpaces.OrderBy(x => x.Id).Include(e => e.Car)).ToListAsync();

    public async Task<ParkingSpace?> GetById(int id, bool trackChanges) =>
        await (!trackChanges ?
            _dbContext.ParkingSpaces.Include(e => e.Car).AsNoTracking() :
            _dbContext.ParkingSpaces.Include(e => e.Car)).SingleOrDefaultAsync(e => e.Id == id);

    public void Delete(ParkingSpace entity) => _dbContext.ParkingSpaces.Remove(entity);
    public void Delete(int id) => _dbContext.ParkingSpaces.Remove(_dbContext.ParkingSpaces.First(x => x.Id == id));

    public void Update(ParkingSpace entity) => _dbContext.ParkingSpaces.Update(entity);

    public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

    public async Task<PaginatedList<ParkingSpace>> GetFilteredPageAsync(int page, int pageSize, ParkingSpaceFilter filter, bool trackChanges)
    {
        var query = _dbContext.ParkingSpaces.AsQueryable();

        if (filter.IsPenalty != null)
        {
            query = query.Where(x => x.IsPenalty == filter.IsPenalty);
        }

        if (filter.CarId == null)
                query = query.Where(x => x.CarId == null);
        else if(filter.CarId != -1)
            query = query.Where(x => x.CarId == filter.CarId);


        return await (!trackChanges
            ? PaginatedList<ParkingSpace>.Create(query.Include(e => e.Car).AsNoTracking(), page, pageSize)
            : PaginatedList<ParkingSpace>.Create(query.Include(e => e.Car), page, pageSize));
    }
}

