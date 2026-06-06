using System.ComponentModel.DataAnnotations;

namespace ContactosApi.DTOs
{
    public record CrearContactoDto(
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        string Nombre,

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El teléfono solo debe contener números.")]
        string Telefono
    );
}