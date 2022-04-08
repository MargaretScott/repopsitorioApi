using System.ComponentModel.DataAnnotations;

namespace BootcampAres.BusinessModels.Models.Product
{
    public class ProductUpdateRequest
    {

        [Required(ErrorMessage = "El campo Name es obligatorio")]
        [MaxLength(70, ErrorMessage = "El campo Name tiene un tamaño máximo de 70")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "El campo Line es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo Line tiene un tamaño máximo de 50")]
        public string Line { get; set; } = null!;

        [Required(ErrorMessage = "El campo Scale es obligatorio")]
        [MaxLength(10, ErrorMessage = "El campo Scale tiene un tamaño máximo de 10")]
        public string Scale { get; set; } = null!;

        [Required(ErrorMessage = "El campo Vendor es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo Vendor tiene un tamaño máximo de 50")]
        public string Vendor { get; set; } = null!;

        [Required(ErrorMessage = "El campo Description es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo Description tiene un tamaño máximo de 100")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "El campo Stock es obligatorio")]
        public short Stock { get; set; }

        [Required(ErrorMessage = "El campo Price es obligatorio")]
        [Range(0, 9999999999.99)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "El campo Msrp es obligatorio")]
        [Range(0, 9999999999.99)]
        public decimal Msrp { get; set; }
    }
}
