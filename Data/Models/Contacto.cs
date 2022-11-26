using System.ComponentModel.DataAnnotations;
using Validaciones.Request;

namespace Validaciones.Data.Models;

public class Contacto
{
    [Key]//Clave primaria en la base de datos
    public int Id { get; set; }
    [Required, MaxLength(100)]//Campo obligatorio, máximo de caracteres 100.
    public string Nombre { get; set; } = null!;
    
    [Required,MaxLength(20)]//Campo obligatorio, máximo de caracteres 100.
    public string Telefono { get; set; } = null!;
    //Para crear una variable tipo contacto, se utiliza el request para recibir los datos.
    public int CiudadId { get; set; }
    public virtual Ciudad Ciudad {get; set;} = null!;
    
    public static Contacto Crear(ContactoRequest datos) =>
    new(){
        Nombre = datos.Nombre,
        Telefono = datos.Telefono,
        CiudadId=datos.CiudadId
    };

}