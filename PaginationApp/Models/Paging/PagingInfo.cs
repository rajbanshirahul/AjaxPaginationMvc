namespace PaginationApp.Models.Paging
{
    public class PagingInfo
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int FilteredCount { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
}
