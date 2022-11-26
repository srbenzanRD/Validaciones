using System.ComponentModel.DataAnnotations;

namespace Validaciones.Request;
///Elemento se utilizara para las peticiones de registro de contactos.
public class ContactoRequest
{
    public ContactoRequest()
    {
        
    }
    public ContactoRequest(string nombre, string telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
    }
    [Required(ErrorMessage = "El nombre del contacto es obligatorio.!"), MaxLength(100)]
    public string Nombre { get; set; } = null!;
    
    [Required(ErrorMessage = "El teléfono del contacto es obligatorio.!"),MinLength(10, ErrorMessage ="El teléfono no es válido!") ,MaxLength(20)]
    public string Telefono { get; set; } = null!;

    public int CiudadId { get; set; } = 1;
}