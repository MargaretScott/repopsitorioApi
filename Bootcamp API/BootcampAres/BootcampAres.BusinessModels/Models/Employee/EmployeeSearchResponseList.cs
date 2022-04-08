namespace BootcampAres.BusinessModels.Models.Employee
{
    public class EmployeeSearchResponseList : BaseResponse
    {
        public List<EmployeeSearchResponse> Results { get; set; }
        public int Total { get; set; }
        public int PageNumber { get; set; }
        public int ItemsPerPage { get; set; }

        public EmployeeSearchResponseList()
        {
            Results = new List<EmployeeSearchResponse>();
        }
    }
}
