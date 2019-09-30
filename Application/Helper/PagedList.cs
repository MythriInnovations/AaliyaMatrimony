using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helper
{
    public class PagedList<T>:List<T>
    {
        private int _pageSize = 5;
        private int MaxPageSize = 50;

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (MaxPageSize > 50 ? 50 : value);
            }
        }
        public int TotalCount { get; set; }

        public bool HasPreviousPage
        {
            get
            {
                return (CurrentPage > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (CurrentPage < TotalPages && TotalCount > 5*PageSize);
            }
        }

        public PagedList(List<T> items,int count,int pageNumber,int pageSize)
        {
            TotalCount = count;
            CurrentPage = pageNumber;
            PageSize = pageSize;
            TotalPages = Convert.ToInt32(System.Math.Ceiling(TotalCount /(double) pageSize));
            this.AddRange(items);
        }

        public static async Task<PagedList<T>> CreatePagedList(IQueryable<T> source,int pageNumber,int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
