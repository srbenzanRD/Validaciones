using Validaciones.Data.Models;

namespace Validaciones.Data.Context;

public class MyDbContextSeeder
{
    public static async void Inicializar(IMyDbContext database)
    {
        //Si la tabla de la base de datos no posee registros, registramos las ciudades pre-iniciales.
        if(!database.Ciudades.Any())
        {
            var ciudades = new List<Ciudad>(){
                Ciudad.Crear("No definido"),
                Ciudad.Crear("Cotuí"),
                Ciudad.Crear("La mata"),
                Ciudad.Crear("Angelina"),
                Ciudad.Crear("Fantino"),
                Ciudad.Crear("Cevicos"),
                Ciudad.Crear("Zambrana"),
                Ciudad.Crear("Platanal"),
                Ciudad.Crear("Pueblo nuevo"),
            };
            database.Ciudades.AddRange(ciudades);
            await database.SaveChangesAsync();
        }
    }
}