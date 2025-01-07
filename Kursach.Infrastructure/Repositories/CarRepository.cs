using Microsoft.EntityFrameworkCore;
using Kursach.Domain.Entities;
using Kursach.Domain.Abstractions;
using Kursach.Domain.Utilities;
using Kursach.Domain.Filters;
using System.Reflection.Metadata.Ecma335;

namespace Kursach.Infrastructure.Repositories;

public class CarRepository(AppDbContext dbContext) : ICarRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task Create(Car entity) => await _dbContext.Cars.AddAsync(entity);

    public async Task<IEnumerable<Car>> Get(bool trackChanges) =>
        await (!trackChanges 
            ? _dbContext.Cars.Include(e => e.Client).AsNoTracking() 
            : _dbContext.Cars.Include(e => e.Client)).ToListAsync();

    public async Task<Car?> GetById(int id, bool trackChanges) =>
        await (!trackChanges ?
            _dbContext.Cars.Include(e => e.Client).AsNoTracking() :
            _dbContext.Cars.Include(e => e.Client)).SingleOrDefaultAsync(e => e.Id == id);

    public void Delete(Car entity) => _dbContext.Cars.Remove(entity);
    public void Delete(int id) => _dbContext.Cars.Remove(_dbContext.Cars.First(x => x.Id == id));

    public void Update(Car entity) => _dbContext.Cars.Update(entity);

    public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

    public async Task<PaginatedList<Car>> GetFilteredPageAsync(int page, int pageSize, CarFilter car, bool trackChanges)
    {
        var query = _dbContext.Cars.AsQueryable();

        if(!string.IsNullOrEmpty(car.Brand))
        {
            query = query.Where(x => x.Brand.Contains(car.Brand));
        }

        if(!string.IsNullOrEmpty(car.Number))
        {
            query = query.Where(x => x.Number.Contains(car.Number));
        }

        if(car.ClientId != null)
        {
            query = query.Where(x => x.ClientId == car.ClientId);
        }

        return await (!trackChanges
            ? PaginatedList<Car>.Create(query.Include(e => e.Client).AsNoTracking(), page, pageSize)
            : PaginatedList<Car>.Create(query.Include(e => e.Client), page, pageSize));
    }
}

