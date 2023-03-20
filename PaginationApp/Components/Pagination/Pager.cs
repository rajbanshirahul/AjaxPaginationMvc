using Microsoft.AspNetCore.Mvc;
using PaginationApp.Models.Pagination;

namespace EMReports.Components.Pagination
{
    public class Pager : ViewComponent
    {
        public Pager()
        {
        }

        public IViewComponentResult Invoke(PagerModel model)
        {
            return View(model);
        }
    }
}
