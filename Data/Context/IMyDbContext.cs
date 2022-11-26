using Microsoft.EntityFrameworkCore;
using Validaciones.Data.Models;

namespace Validaciones.Data.Context;

public interface IMyDbContext
{
    DbSet<Ciudad> Ciudades { get; }
    DbSet<Contacto> Contactos { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

