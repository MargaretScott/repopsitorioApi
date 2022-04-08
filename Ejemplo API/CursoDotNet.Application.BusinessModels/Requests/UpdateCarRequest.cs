namespace CursoDotNet.Application.BusinessModels.Requests
{
    public class UpdateCarRequest
    {
        public int Id { get; set; }
        public string Version { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}
