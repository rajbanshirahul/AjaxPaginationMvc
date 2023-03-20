namespace PaginationApp.Models.Paging
{
    public class PagedResult<T> : PagingInfo
    {
        public IEnumerable<T> Items { get; set; }
    }
}
