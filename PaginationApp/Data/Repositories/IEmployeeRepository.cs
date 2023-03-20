using PaginationApp.Models.Employees;
using PaginationApp.Models.Paging;

namespace PaginationApp.Data.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<PagedResult<Employee>> GetEmployeesAsync(EmployeeListRequest request);
    }
}
