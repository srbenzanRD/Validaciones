using System.ComponentModel.DataAnnotations;

namespace Validaciones.Request;

public class CiudadRequest
{
    public CiudadRequest()
    {
        
    }
    public CiudadRequest(string nombre)
    {
        Nombre=nombre;
    }
    [Required(ErrorMessage = "El nombre de la ciudad es obligatorio.!"), MaxLength(100)]
    public string Nombre { get; set; } = null!;
}