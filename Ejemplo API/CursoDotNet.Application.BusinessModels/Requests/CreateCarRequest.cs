namespace CursoDotNet.Application.BusinessModels.Requests
{
    public class CreateCarRequest
    {
       //añadir requerido de automapper
        public string Version { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

    }
}
