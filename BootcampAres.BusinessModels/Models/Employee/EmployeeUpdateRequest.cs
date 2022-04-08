namespace BootcampAres.BusinessModels.Models.Employee
{
    public class EmployeeUpdateRequest
    {
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Extension { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string OfficeCode { get; set; } = null!;
        public int? ReportsTo { get; set; }
        public string JobTitle { get; set; } = null!;
    }
}
