using Microsoft.EntityFrameworkCore;
using Validaciones.Data.Models;

namespace Validaciones.Data.Context;

public class MyDbContext : DbContext, IMyDbContext
{
    #region Constructor
    public MyDbContext(DbContextOptions options) : base(options)
    {

    }
    #endregion
    #region Tablas
    public DbSet<Ciudad> Ciudades => Set<Ciudad>();
    public DbSet<Contacto> Contactos => Set<Contacto>();
    #endregion
    #region Funciones
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
    #endregion
}

