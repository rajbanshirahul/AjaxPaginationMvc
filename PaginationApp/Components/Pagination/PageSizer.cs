using Microsoft.AspNetCore.Mvc;
using PaginationApp.Models.Pagination;

namespace EMReports.Components.Pagination
{
    public class PageSizer : ViewComponent
    {
        public PageSizer()
        {
        }

        public IViewComponentResult Invoke(PageSizeDdl model)
        {
            return View(model);
        }
    }
}
