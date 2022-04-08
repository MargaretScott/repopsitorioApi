namespace BootcampAres.BusinessModels.Models.Employee
{
    public class EmployeeResponse : BaseResponse
    {
        public int EmployeeNumber { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
    }
}
