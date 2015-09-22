using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions.Pager
{
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public PagedList(IEnumerable<T> source, int index, int pageSize, int totalCount)
        : this(source.AsQueryable(), index, pageSize, totalCount) { }

        public PagedList(IEnumerable<T> source)
        {
            AddRange(source);
        }

        public PagedList(IQueryable<T> source, int index, int pageSize, int totalCount)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), "Value can not be below 0.");
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(nameof(pageSize), "Value can not be less than 1.");

            if (source == null)
                source = new List<T>().AsQueryable();

            var realTotalCount = source.Count();

            PageSize = pageSize;
            PageIndex = index;
            TotalItemCount = totalCount;
            PageCount = TotalItemCount > 0 ? (int)Math.Ceiling(TotalItemCount / (double)PageSize) : 0;

            HasPreviousPage = (PageIndex > 0);
            HasNextPage = (PageIndex < (PageCount - 1));
            IsFirstPage = (PageIndex <= 0);
            IsLastPage = (PageIndex >= (PageCount - 1));

            ItemStart = PageIndex * PageSize + 1;
            ItemEnd = Math.Min(PageIndex * PageSize + PageSize, TotalItemCount);

            if (TotalItemCount <= 0)
                return;

            var realTotalPages = (int)Math.Ceiling(realTotalCount / (double)PageSize);

            if (realTotalCount < TotalItemCount && realTotalPages <= PageIndex)
                AddRange(source.Skip((realTotalPages - 1) * PageSize).Take(PageSize));
            else
                AddRange(source);
        }

        #region IPagedList Members

        public int PageCount { get; }
        public int TotalItemCount { get; }
        public int PageIndex { get; }
        public int PageNumber => PageIndex + 1;

        public int PageSize { get; }
        public int ItemStart { get; }
        public int ItemEnd { get; }
        public bool HasPreviousPage { get; }
        public bool HasNextPage { get; }
        public bool IsFirstPage { get; }
        public bool IsLastPage { get; }

        #endregion
    }
}