namespace Validaciones.Response;

public class ContactoRecord
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Telefono { get; set; } = null!;

    public CiudadRecord? Ciudad { get; set; }
}
