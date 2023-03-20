using Microsoft.AspNetCore.Mvc;
using PaginationApp.Models.Pagination;

namespace EMReports.Components.Pagination
{
    public class SortOrderViewComponent : ViewComponent
    {
        public SortOrderViewComponent()
        {

        }

        public IViewComponentResult Invoke(SortOrderModel sortOrderModel)
        {
            return View(sortOrderModel);
        }
    }
}
