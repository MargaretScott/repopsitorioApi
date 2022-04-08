namespace BootcampAres.BusinessModels.Models.Customer
{
    public class CustomerWithEmployeeResponseList : BaseResponse
    {
        public List<CustomerWithEmployeeResponse> Results { get; set; }
        public int Total { get; set; }
        public int PageNumber { get; set; }
        public int ItemsPerPage { get; set; }

        public CustomerWithEmployeeResponseList()
        {
            Results = new List<CustomerWithEmployeeResponse>();
        }
    }
}
