using PaginationApp.Models.Employees;
using PaginationApp.Models.Paging;
using System.Text.Json;

namespace PaginationApp.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public async Task<PagedResult<Employee>> GetEmployeesAsync(EmployeeListRequest request)
        {
            var employeesData = await File.ReadAllTextAsync("./Data/Json/employees.json");

            var employeesAll = JsonSerializer.Deserialize<IEnumerable<Employee>>(employeesData);
            var employees = employeesAll;

            // searching
            if (!string.IsNullOrEmpty(request.Search))
            {
                var search = request.Search.Trim();
                employees = employees.Where(
                    e => e.FirstName.Contains(search, StringComparison.InvariantCultureIgnoreCase)
                    || e.LastName.Contains(search, StringComparison.InvariantCultureIgnoreCase)
                    || e.Title.Contains(search, StringComparison.InvariantCultureIgnoreCase)
                    || e.City.Contains(search, StringComparison.InvariantCultureIgnoreCase)
                    || e.Department.Contains(search, StringComparison.InvariantCultureIgnoreCase)
                    || e.Email.Contains(search, StringComparison.InvariantCultureIgnoreCase)
                    || e.SocialSecurityNumber.Contains(search, StringComparison.InvariantCultureIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(request.FirstName))
                employees = employees.Where(e => e.FirstName.Equals(request.FirstName.Trim(), StringComparison.InvariantCultureIgnoreCase));

            if (!string.IsNullOrWhiteSpace(request.LastName))
                employees = employees.Where(e => e.LastName.Equals(request.LastName.Trim(), StringComparison.InvariantCultureIgnoreCase));

            if (!string.IsNullOrWhiteSpace(request.Department))
                employees = employees.Where(e => e.Department.Equals(request.Department.Trim(), StringComparison.InvariantCultureIgnoreCase));

            if (!string.IsNullOrWhiteSpace(request.Email))
                employees = employees.Where(e => e.Email.Equals(request.Email.Trim(), StringComparison.InvariantCultureIgnoreCase));

            if (!string.IsNullOrWhiteSpace(request.Title))
                employees = employees.Where(e => e.Title.Equals(request.Title.Trim(), StringComparison.InvariantCultureIgnoreCase));

            if (!string.IsNullOrWhiteSpace(request.City))
                employees = employees.Where(e => e.City.Equals(request.City.Trim(), StringComparison.InvariantCultureIgnoreCase));

            if (!string.IsNullOrWhiteSpace(request.SocialSecurityNumber))
                employees = employees.Where(e => e.SocialSecurityNumber.Equals(request.SocialSecurityNumber.Trim(), StringComparison.InvariantCultureIgnoreCase));

            if (request.Salary.HasValue)
                employees = employees.Where(e => e.Salary == request.Salary);

            // ordering
            employees = request.SortOrder.Equals("ASC", StringComparison.InvariantCultureIgnoreCase)
                ? request.SortBy switch
                {
                    nameof(Employee.FirstName) => employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName),
                    nameof(Employee.LastName) => employees.OrderBy(e => e.LastName),
                    nameof(Employee.Salary) => employees.OrderBy(e => e.Salary),
                    nameof(Employee.Department) => employees.OrderBy(e => e.Department),
                    nameof(Employee.Title) => employees.OrderBy(e => e.Title),
                    nameof(Employee.SocialSecurityNumber) => employees.OrderBy(e => e.SocialSecurityNumber),
                    nameof(Employee.City) => employees.OrderBy(e => e.City),
                    nameof(Employee.Email) => employees.OrderBy(e => e.Email),
                    _ => employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName)
                }
                : request.SortBy switch
                {
                    nameof(Employee.FirstName) => employees.OrderByDescending(e => e.FirstName).ThenByDescending(e => e.LastName),
                    nameof(Employee.LastName) => employees.OrderByDescending(e => e.LastName).ThenByDescending(e => e.FirstName),
                    nameof(Employee.Salary) => employees.OrderByDescending(e => e.Salary),
                    nameof(Employee.Department) => employees.OrderByDescending(e => e.Department),
                    nameof(Employee.Title) => employees.OrderByDescending(e => e.Title),
                    nameof(Employee.SocialSecurityNumber) => employees.OrderByDescending(e => e.SocialSecurityNumber),
                    nameof(Employee.City) => employees.OrderByDescending(e => e.City),
                    nameof(Employee.Email) => employees.OrderByDescending(e => e.Email),
                    _ => employees.OrderByDescending(e => e.FirstName).ThenByDescending(e => e.LastName)
                };

            var filteredCount = employees.Count();
            var totalPages = (int)Math.Ceiling((decimal)filteredCount / request.PageSize);
            var pageIndex = request.PageIndex > totalPages ? totalPages : request.PageIndex;

            // paging
            employees = employees
                .Skip((pageIndex - 1) * request.PageSize)
                .Take(request.PageSize);

            return new PagedResult<Employee>
            {
                Items = employees,
                FilteredCount = filteredCount,
                TotalCount = employeesAll.Count(),
                PageSize = request.PageSize,
                PageIndex = pageIndex,
                TotalPages = totalPages
            };
        }
    }
}
