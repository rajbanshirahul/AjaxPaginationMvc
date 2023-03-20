using Microsoft.AspNetCore.Mvc;
using PaginationApp.Models.Pagination;

namespace EMReports.Components.Pagination
{
    public class PaginationSummary : ViewComponent
    {
        public PaginationSummary()
        {
        }

        public IViewComponentResult Invoke(PaginationSummaryModel model)
        {
            return View(model);
        }
    }
}
