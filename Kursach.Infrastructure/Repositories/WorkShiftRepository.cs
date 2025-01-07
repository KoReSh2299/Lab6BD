using Microsoft.EntityFrameworkCore;
using Kursach.Domain.Entities;
using Kursach.Domain.Abstractions;
using Kursach.Domain.Utilities;
using Kursach.Domain.Filters;
using Azure.Core;
using System.Threading;

namespace Kursach.Infrastructure.Repositories;

public class WorkShiftRepository(AppDbContext dbContext) : IWorkShiftRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task Create(WorkShift entity) => await _dbContext.WorkShifts.AddAsync(entity);

    public async Task<IEnumerable<WorkShift>> Get(bool trackChanges) =>
        await (!trackChanges 
            ? _dbContext.WorkShifts.Include(e => e.Employee).AsNoTracking() 
            : _dbContext.WorkShifts.Include(e => e.Employee)).ToListAsync();

    public async Task<WorkShift?> GetById(int id, bool trackChanges) =>
        await (!trackChanges ?
            _dbContext.WorkShifts.Include(e => e.Employee).AsNoTracking() :
            _dbContext.WorkShifts.Include(e => e.Employee)).SingleOrDefaultAsync(e => e.Id == id);

    public void Delete(WorkShift entity) => _dbContext.WorkShifts.Remove(entity);

    public void Delete(int id) => _dbContext.WorkShifts.Remove(_dbContext.WorkShifts.First(x => x.Id == id));

    public void Update(WorkShift entity) => _dbContext.WorkShifts.Update(entity);

    public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

    public async Task<PaginatedList<WorkShift>> GetFilteredPageAsync(int page, int pageSize, WorkShiftFilter filter, bool trackChanges)
    {
        var query = _dbContext.WorkShifts.AsQueryable();

        if (filter.EmployeeId != null)
        {
            query = query.Where(x => x.EmployeeId == filter.EmployeeId);
        }

        var minShiftStartTime = filter.MinShiftStartTime ?? new DateTime(1754, 1, 1);
        var maxShiftStartTime = filter.MaxShiftStartTime ?? new DateTime(9999, 12, 31);
        var minShiftEndTime = filter.MinShiftEndTime ?? new DateTime(1754, 1, 1);
        var maxShiftEndTime = filter.MaxShiftEndTime ?? new DateTime(9999, 12, 31);

        query = query.Where(x => x.ShiftStartTime >= minShiftStartTime && x.ShiftStartTime <= maxShiftStartTime
                            && x.ShiftEndTime >= minShiftEndTime && x.ShiftEndTime <= maxShiftEndTime);

        return await (!trackChanges
            ? PaginatedList<WorkShift>.Create(query.Include(e => e.Employee).AsNoTracking(), page, pageSize)
            : PaginatedList<WorkShift>.Create(query.Include(e => e.Employee), page, pageSize));
    }

    public async Task<PaginatedList<EmployeeWorkSummary>> GetFilteredPageAsync(int page, int pageSize, EmployeeWorkSummaryFilter filter, bool trackChanges)
    {
        IQueryable<WorkShift> query = null;

        if (trackChanges)
            query = _dbContext.WorkShifts.Include(x => x.Employee).AsNoTracking().AsQueryable();
        else
            query = _dbContext.WorkShifts.Include(x => x.Employee).AsQueryable();

        if (filter.PeriodStart != null)
        {
            query = query.Where(x => x.ShiftStartTime >= filter.PeriodStart);
        }

        if (filter.PeriodEnd != null) 
            query = query.Where(x => x.ShiftEndTime <=  filter.PeriodEnd);

        // Группируем данные по сотруднику
        var result = query
            .GroupBy(ws => ws.Employee)
            .Select(g => new EmployeeWorkSummary
            {
                EmployeeId = g.Key.Id,
                EmployeeName = $"{g.Key.Surname} {g.Key.Name} {g.Key.MiddleName}",
                WorkShiftCount = g.Count(),
                TotalIncome = g.Sum(ws => ws.Income),
                TotalEmployeeIncome = g.Sum(ws => ws.EmployeeIncome)
            }).ToList();

        return await Task.Run(() => {return PaginatedList<EmployeeWorkSummary>.Create(result, page, pageSize); });
    }
}

