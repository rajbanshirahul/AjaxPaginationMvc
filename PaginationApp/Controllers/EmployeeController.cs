using Microsoft.AspNetCore.Mvc;
using PaginationApp.Core;
using PaginationApp.Models.Employees;
using PaginationApp.Services;

namespace PaginationApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index([FromQuery]EmployeeListRequest request)
        {
            var employees = await _employeeService.GetEmployeesAsync(request);

            if (WebHelper.IsAjaxRequest(Request))
                return PartialView("_List", employees);

            return View(employees);
        }

        [HttpPost]
        public async Task<IActionResult> Indexx([FromBody] EmployeeListRequest request)
        {
            var employees = await _employeeService.GetEmployeesAsync(request);

            if (WebHelper.IsAjaxRequest(Request))
                return PartialView("_List", employees);

            return View(employees);
        }
    }
}
