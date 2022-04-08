namespace BootcampAres.DataAccess.Contracts.Entities
{
    public class CustomerWithEmployeeDtoList
    {
        public List<CustomerWithEmployeeDto> Results { get; set; }
        public int Total { get; set; }

        public CustomerWithEmployeeDtoList()
        {
            Results = new List<CustomerWithEmployeeDto>();
        }
    }
}
