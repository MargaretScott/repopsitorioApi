using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CursoDotNet.DataAccess.Contracts.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public int roleId { get; set; }

        [Required]
        public virtual Role role { get; set; }

        [Required]
        public virtual ICollection<Car> cars { get; set; }
    }
}
