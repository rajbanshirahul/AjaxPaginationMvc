namespace PaginationApp.Models.Pagination
{
    /// <summary>
    /// Paged list
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        protected int MaxPageSize = 100;
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="filteredCount">Filtered count</param>
        /// <param name="totalCount">Total count</param>
        public PagedList(IList<T> source, int pageIndex, int pageSize, int? filteredCount = null, int? totalCount = null)
        {
            // min allowed pageIndex is 1
            PageIndex = Math.Max(pageIndex, 1);

            //min allowed page size is 1
            pageSize = Math.Max(pageSize, 1);
            PageSize = Math.Min(pageSize, MaxPageSize);

            //FilteredCount = filteredCount;
            FilteredCount = filteredCount ?? source.Count;

            TotalPages = (int)Math.Ceiling((decimal)FilteredCount / PageSize);

            TotalCount = totalCount ?? FilteredCount;

            AddRange(filteredCount is not null ? source : source.Skip(PageIndex * PageSize).Take(PageSize));
        }

        /// <summary>
        /// Page index
        /// </summary>
        public int PageIndex { get; }

        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        /// Filtered count
        /// </summary>
        public int FilteredCount { get; }

        /// <summary>
        /// Total count
        /// </summary>
        public int TotalCount { get; }

        /// <summary>
        /// Total pages
        /// </summary>
        public int TotalPages { get; }

        /// <summary>
        /// Has previous page
        /// </summary>
        public bool HasPreviousPage => PageIndex > 1;

        /// <summary>
        /// Has next page
        /// </summary>
        public bool HasNextPage => PageIndex < TotalPages;
    }
}
