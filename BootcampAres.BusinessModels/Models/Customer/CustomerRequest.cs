namespace BootcampAres.BusinessModels.Models.Customer
{
    public class CustomerRequest
    {
        public int Number { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string AddressLine1 { get; set; } = null!;
        public string? AddressLine2 { get; set; }
        public string City { get; set; } = null!;
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string Country { get; set; } = null!;
        public int? SalesRepEmployeeNumber { get; set; }
        public decimal? CreditLimit { get; set; }
    }
}
