using PaginationApp.Models.Paging;

namespace PaginationApp.Models.Employees
{
    public class EmployeeListRequest : PagedRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public double? Salary { get; set; }
    }
}
