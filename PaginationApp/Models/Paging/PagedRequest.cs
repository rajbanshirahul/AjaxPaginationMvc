namespace PaginationApp.Models.Paging
{
    public class PagedRequest
    {
        public const int MaxPageSize = 500;
        public const int DefaultPageSize = 10;
        public const string DefaultSortOrder = "ASC";

        private string _search = string.Empty;
        private int _pageIndex = 1;
        private int _pageSize = DefaultPageSize;
        private string _sortBy = string.Empty;
        private string _sortOrder = DefaultSortOrder;

        public string Search { get => _search; set => _search = value ?? string.Empty; }
        public int PageIndex { get => _pageIndex; set => _pageIndex = Math.Max(value, 1); }
        public int PageSize { get => _pageSize; set => _pageSize = Math.Min(Math.Max(value, 1), MaxPageSize); }
        public string SortBy { get => _sortBy; set => _sortBy = value ?? string.Empty; }
        public string SortOrder
        {
            get => _sortOrder;
            set => _sortOrder = string.IsNullOrWhiteSpace(value) || !value.Equals("DESC", StringComparison.InvariantCultureIgnoreCase)
                ? DefaultSortOrder
                : "DESC";
        }
    }
}
