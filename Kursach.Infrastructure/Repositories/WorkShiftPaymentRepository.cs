using Microsoft.EntityFrameworkCore;
using Kursach.Domain.Entities;
using Kursach.Domain.Abstractions;
using Kursach.Domain.Utilities;
using Kursach.Domain.Filters;

namespace Kursach.Infrastructure.Repositories;

public class WorkShiftPaymentRepository(AppDbContext dbContext) : IWorkShiftPaymentRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task Create(WorkShiftPayment entity) => await _dbContext.WorkShiftsPayments.AddAsync(entity);

    public async Task<IEnumerable<WorkShiftPayment>> Get(bool trackChanges) =>
        await (!trackChanges 
            ? _dbContext.WorkShiftsPayments.Include(e => e.WorkShift).ThenInclude(w => w.Employee).Include(e => e.Payment).AsNoTracking() 
            : _dbContext.WorkShiftsPayments.Include(e => e.WorkShift).ThenInclude(w => w.Employee).Include(e => e.Payment)).ToListAsync();

    public async Task<WorkShiftPayment?> GetById(int id, bool trackChanges) =>
        await (!trackChanges ?
            _dbContext.WorkShiftsPayments.Include(e => e.WorkShift).ThenInclude(w => w.Employee).Include(e => e.Payment).AsNoTracking() :
            _dbContext.WorkShiftsPayments.Include(e => e.WorkShift).ThenInclude(w => w.Employee).Include(e => e.Payment)).SingleOrDefaultAsync(e => e.Id == id);

    public void Delete(WorkShiftPayment entity) => _dbContext.WorkShiftsPayments.Remove(entity);

    public void Delete(int id) => _dbContext.WorkShiftsPayments.Remove(_dbContext.WorkShiftsPayments.First(x => x.Id == id));

    public void Update(WorkShiftPayment entity) => _dbContext.WorkShiftsPayments.Update(entity);

    public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

    public async Task<PaginatedList<WorkShiftPayment>> GetFilteredPageAsync(int page, int pageSize, WorkShiftPaymentFilter filter, bool trackChanges)
    {
        var query = _dbContext.WorkShiftsPayments.AsQueryable();

        if (filter.WorkShiftId != null)
        {
            query = query.Where(x => x.WorkShiftId == filter.WorkShiftId);
        }

        if(filter.PaymentId != null)
        {
            query = query.Where(x => x.PaymentId == filter.PaymentId);
        }

        return await (!trackChanges
                    ? PaginatedList<WorkShiftPayment>.Create(query.Include(e => e.WorkShift).ThenInclude(w => w.Employee).Include(e => e.Payment).AsNoTracking(), page, pageSize)
                    : PaginatedList<WorkShiftPayment>.Create(query.Include(e => e.WorkShift).ThenInclude(w => w.Employee).Include(e => e.Payment), page, pageSize));
    }
}

