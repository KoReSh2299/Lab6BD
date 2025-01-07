using Microsoft.EntityFrameworkCore;
using Kursach.Domain.Entities;
using Kursach.Domain.Abstractions;
using Kursach.Domain.Utilities;
using Kursach.Domain.Filters;

namespace Kursach.Infrastructure.Repositories;

public class PaymentRepository(AppDbContext dbContext) : IPaymentRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task Create(Payment entity) => await _dbContext.Payments.AddAsync(entity);

    public async Task<IEnumerable<Payment>> Get(bool trackChanges) =>
        await (!trackChanges 
            ? _dbContext.Payments.Include(e => e.Tariff).Include(e => e.Discount).Include(e => e.ParkingSpace).AsNoTracking() 
            : _dbContext.Payments.Include(e => e.Tariff).Include(e => e.Discount).Include(e => e.ParkingSpace)).ToListAsync();

    public async Task<Payment?> GetById(int id, bool trackChanges) =>
        await (!trackChanges ?
            _dbContext.Payments.Include(e => e.Tariff).Include(e => e.Discount).Include(e => e.ParkingSpace).AsNoTracking() :
            _dbContext.Payments.Include(e => e.Tariff).Include(e => e.Discount).Include(e => e.ParkingSpace)).SingleOrDefaultAsync(e => e.Id == id);

    public void Delete(Payment entity) => _dbContext.Payments.Remove(entity);

    public void Delete(int id) => _dbContext.Payments.Remove(_dbContext.Payments.First(x => x.Id == id));

    public void Update(Payment entity) => _dbContext.Payments.Update(entity);

    public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

    public async Task<PaginatedList<Payment>> GetFilteredPageAsync(int page, int pageSize, PaymentFilter filter, bool trackChanges)
    {
        var query = _dbContext.Payments.AsQueryable();

        if (filter.TariffId != null)
        {
            query = query.Where(x => x.TariffId == filter.TariffId);
        }

        if (filter.DiscountId != null)
        {
            query = query.Where(x => x.DiscountId == filter.DiscountId);
        }

        if (filter.ParkingSpaceId != null)
        {
            query = query.Where(x => x.ParkingSpaceId == filter.ParkingSpaceId);
        }

        var minAmount = filter.MinAmount ?? 0m;
        var maxAmount = filter.MaxAmount ?? 99999999.99m;
        var minTimeOut = filter.MinTimeOut ?? new DateTime(1754, 1, 1);
        var maxTimeOut = filter.MaxTimeOut ?? new DateTime(9999, 12, 31);
        var minTimeIn = filter.MinTimeIn ?? new DateTime(1754, 1, 1);
        var maxTimeIn = filter.MaxTimeIn ?? new DateTime(9999, 12, 31);
        var minPaymentDate = filter.MinPaymentDate ?? new DateTime(1754, 1, 1);
        var maxPaymentDate = filter.MaxPaymentDate ?? new DateTime(9999, 12, 31);

        query = query.Where(x => x.Amount >= minAmount && x.Amount <= maxAmount && x.TimeIn >= minTimeIn && x.TimeIn <= maxTimeIn 
                            && x.TimeOut >= minTimeOut && x.TimeOut <= maxTimeOut && x.PaymentDate >= minPaymentDate && x.PaymentDate <= maxPaymentDate);

        return await (!trackChanges
            ? PaginatedList<Payment>.Create(query.Include(e => e.Tariff).Include(e => e.Discount).Include(e => e.ParkingSpace).AsNoTracking(), page, pageSize)
            : PaginatedList<Payment>.Create(query.Include(e => e.Tariff).Include(e => e.Discount).Include(e => e.ParkingSpace), page, pageSize));
    }
}

