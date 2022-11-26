using System.ComponentModel.DataAnnotations;
using Validaciones.Request;

namespace Validaciones.Data.Models;

public class Ciudad
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Nombre { get; set; } = null!;

    public static Ciudad Crear(CiudadRequest datos)
    =>new Ciudad(){Nombre = datos.Nombre};

    public static Ciudad Crear(string nombre)
    =>new Ciudad(){Nombre = nombre};
}