namespace BootcampAres.BusinessModels.Models.Employee
{
    public class EmployeeSearchRequest
    {
        public int PageNumber { get; set; }
        public int ItemsPerPage { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

    }
}
