using System.ComponentModel.DataAnnotations;

namespace CursoDotNet.DataAccess.Contracts.Entities
{
    public class Car : BaseEntity
    {

        [Required]
        public int id { get; set; }

        [Required]
        public string brand { get; set; }

        [Required]
        public string model { get; set; }

        public string Version { get; set; }
    }
}
