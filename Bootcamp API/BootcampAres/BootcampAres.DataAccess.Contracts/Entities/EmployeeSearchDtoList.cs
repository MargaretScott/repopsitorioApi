namespace BootcampAres.DataAccess.Contracts.Entities
{
    public class EmployeeSearchDtoList
    {
        public List<EmployeeSearchDto> Results { get; set; }
        public int Total { get; set; }

        public EmployeeSearchDtoList()
        {
            Results = new List<EmployeeSearchDto>();
        }
    }
}
