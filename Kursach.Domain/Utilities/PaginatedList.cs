using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kursach.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kursach.Domain.Utilities
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex {  get; private set; }

        public int TotalPagesCount { get; private set; }

        public int PageSize { get; private set; }

        //Нумерация начинается с 1
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPagesCount;

        public PaginatedList(List<T> items, int pageInd, int pageSize, int totalItemsCount)
        {
            PageIndex = pageInd;
            TotalPagesCount = totalItemsCount;
            PageSize = pageSize;
            this.AddRange(items);
        }

        public static async Task<PaginatedList<T>> Create(IQueryable<T> source, int pageInd, int pageSize)
        {
            var count = source.Count();
            var items = await source.Order().Skip((pageInd - 1) * pageSize).Take(pageSize).ToListAsync();
            var countPages = (int)Math.Ceiling(count / (double)pageSize);
            return new PaginatedList<T>(items, pageInd, pageSize, countPages);
        }

        public static PaginatedList<T> Create(IEnumerable<T> items, int pageInd, int pageSize)
        {
            var result = items.Skip((pageInd - 1) * pageSize).Take(pageSize);
            var countPages = (int)Math.Ceiling(items.Count() / (double)pageSize);
            return new PaginatedList<T>(result.ToList(), pageInd, pageSize, countPages);
        }
    }
}
