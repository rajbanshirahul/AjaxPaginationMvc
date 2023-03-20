using PaginationApp.Data.Repositories;
using PaginationApp.Models.Employees;
using PaginationApp.Models.Paging;

namespace PaginationApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<PagedResult<Employee>> GetEmployeesAsync(EmployeeListRequest request)
        {
            return await _employeeRepository.GetEmployeesAsync(request);
        }
    }
}
