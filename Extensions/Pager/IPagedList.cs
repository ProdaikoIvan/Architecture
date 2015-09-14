using System.Collections.Generic;

namespace Extensions.Pager
{
    public interface IPagedList
    {
        int PageCount { get; }
        int TotalItemCount { get; }
        int PageIndex { get; }
        int PageNumber { get; }
        int PageSize { get; }
        int ItemStart { get; }
        int ItemEnd { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
        bool IsFirstPage { get; }
        bool IsLastPage { get; }
    }

    public interface IPagedList<out T> : IPagedList, IEnumerable<T>
    {
    }
}