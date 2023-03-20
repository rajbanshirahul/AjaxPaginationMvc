using Microsoft.AspNetCore.Mvc;
using PaginationApp.Models.Pagination;

namespace EMReports.Components.Pagination
{
    public class SortByViewComponent : ViewComponent
    {
        public SortByViewComponent()
        {

        }

        public IViewComponentResult Invoke(SortByModel model)
        {
            return View(model);
        }
    }
}
