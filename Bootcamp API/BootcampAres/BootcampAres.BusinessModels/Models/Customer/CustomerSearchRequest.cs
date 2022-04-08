namespace BootcampAres.BusinessModels.Models.Customer
{
    public class CustomerSearchRequest
    {
        public int PageNumber { get; set; }
        public int ItemsPerPage { get; set; }
        public string? CustomerName { get; set; }
        public string? ContactFirstName { get; set; }
        public string? City { get; set; }
        public string? Country{ get; set; }
        public string? EmployeeFirstName { get; set; }
    }
}
