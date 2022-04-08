using System.ComponentModel.DataAnnotations;

namespace BootcampAres.BusinessModels.Models.Employee
{
    public class EmployeeRequest
    {
        public int EmployeeNumber { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Extension { get; set; } = null!;
        [Required(ErrorMessage = "El campo email es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo email tiene un tamaño maximo de 100")]
        [EmailAddress(ErrorMessage = "E-mail no es valido")]
        public string Email { get; set; } = null!;
        public string OfficeCode { get; set; } = null!;
        public int? ReportsTo { get; set; }
        public string JobTitle { get; set; } = null!;
        public string DNI { get; set; }
    }
}
