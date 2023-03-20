using PaginationApp.Models.Employees;
using PaginationApp.Models.Paging;

namespace PaginationApp.Services
{
    public interface IEmployeeService
    {
        Task<PagedResult<Employee>> GetEmployeesAsync(EmployeeListRequest request);
    }
}
