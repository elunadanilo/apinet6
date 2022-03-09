using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.ApplicationCore.CustomEntities
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }


        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
        public int? NextPageNumber => HasNextPage ? CurrentPage + 1 : (int?)null;
        public int? PreviousPageNumber => HasPreviousPage ? CurrentPage - 1 : (int?)null;

        public PagedList(List<T> items, int count, int pagenumber, int pagesize)
        {
            TotalCount = count;
            PageSize = pagesize;
            CurrentPage = pagenumber;
            TotalPages = (int)Math.Ceiling(count / (double)pagesize);
            AddRange(items);
        }

        public static PagedList<T> Create(IEnumerable<T> source, int pagenumber, int pagesize)
        {
            var count = source.Count();
            var items = source.Skip((pagenumber - 1) * pagesize).Take(pagesize).ToList();

            return new PagedList<T>(items, count, pagenumber, pagesize);
        }
    }
}
