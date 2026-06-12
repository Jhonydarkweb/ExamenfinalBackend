using System.ComponentModel.DataAnnotations;

namespace LibraryService.WebAPI.DTO
{
    public class FraudForm
    {
        [Required(ErrorMessage = "ImpostorDetails es requerido")]
        [MinLength(1, ErrorMessage = "ImpostorDetails debe tener al menos 1 carácter")]
        public string ImpostorDetails { get; set; }

        [Required(ErrorMessage = "ContactInfo es requerido")]
        [MinLength(1, ErrorMessage = "ContactInfo debe tener al menos 1 carácter")]
        public string ContactInfo { get; set; }

        [Required(ErrorMessage = "Comments es requerido")]
        [MinLength(1, ErrorMessage = "Comments debe tener al menos 1 carácter")]
        public string Comments { get; set; }
    }
}
