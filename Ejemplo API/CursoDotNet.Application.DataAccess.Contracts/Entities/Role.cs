using System.ComponentModel.DataAnnotations;

namespace CursoDotNet.DataAccess.Contracts.Entities
{
    public class Role : BaseEntity
    {
        [Required]
        public int id { get; set; }

        [Required]
        public string description { get; set; }
    }
}
