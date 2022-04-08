using System.ComponentModel.DataAnnotations;

namespace CursoDotNet.DataAccess.Contracts.Dtos
{
    public class CarDto
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Version { get; set; }
    }
}
