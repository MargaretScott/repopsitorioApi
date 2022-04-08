namespace BootcampAres.BusinessModels.Models.Customer
{
    public class CustomerWithEmployeeResponse
    {
        public int CustomerNumber { get; set; }
        public string CustomerName { get; set; } = null!;
        public string ContactName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string EmployeeName { get; set; } = null!;
        public string EmployeeEmail { get; set; } = null!;
        public string OfficeTerritory { get; set; } = null!;
    }
}
