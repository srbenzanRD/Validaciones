using Microsoft.EntityFrameworkCore;
using Validaciones.Data.Context;
using Validaciones.Data.Models;
using Validaciones.Request;
using Validaciones.Response;

namespace Validaciones.Data.Services;

public interface IContactoService
{
    Task<Result<List<ContactoRecord>>> Consultar(string filtro);
    Task<Result<int>> Registrar(ContactoRequest datos);
    Task<Result<List<CiudadRecord>>> GetCiudades();
}

public class ContactoService : IContactoService
{
    private IMyDbContext _database;
    public ContactoService(IMyDbContext database)
    {
        _database = database;
    }
    //Tarea para registrar un contacto nuevo en la base de datos...
    public async Task<Result<int>> Registrar(ContactoRequest datos)
    {
        try
        {
            var contacto = Contacto.Crear(datos);

            _database.Contactos.Add(contacto);
            await _database.SaveChangesAsync(new());

            return Result<int>.Success(contacto.Id);
        }
        catch (Exception E)
        {
            return Result<int>.Fail(E.Message);
        }
    }
    //Tarea para consultar los contactos en la base de datos...
    public async Task<Result<List<ContactoRecord>>> Consultar(string filtro)
    {
        try
        {
            //Se consulta en la base de datos segun el nombre del contacto y el telefono.
            var contactosDB =
            await _database.Contactos.Where(contacto =>
                (!string.IsNullOrEmpty(filtro) && (contacto.Nombre.ToLower().Contains(filtro.ToLower())) || contacto.Telefono.Contains(filtro))
            )
            .Include(contacto=>contacto.Ciudad
            
            )
            .ToListAsync(new());
            //Se convierten los datos para poder devolverlos.
            var contactosMapeados = contactosDB.Select(c => new ContactoRecord() { 
                Id = c.Id, 
                Nombre = c.Nombre, 
                Telefono = c.Telefono,
                Ciudad = new CiudadRecord(){ Id = c.Ciudad!.Id, Nombre = c.Ciudad!.Nombre} })
                .ToList();
            //Se devuelven los datos convertidos al tipo de dato esperado.
            return Result<List<ContactoRecord>>.Success(contactosMapeados);
        }
        catch (Exception E)
        {
            return Result<List<ContactoRecord>>.Fail(E.Message);
        }
    }

    public async Task<Result<List<CiudadRecord>>> GetCiudades(){
                try
        {
            //Se consulta en la base de datos segun el nombre del contacto y el telefono.
            var ciudadesDB =
            await _database.Ciudades
            .ToListAsync(new());
            //Se convierten los datos para poder devolverlos.
            var ciuadesDTO = ciudadesDB.Select(c=> new CiudadRecord(){
                Id = c.Id,
                Nombre = c.Nombre
                }).ToList();
            //Se devuelven los datos convertidos al tipo de dato esperado.
            return Result<List<CiudadRecord>>.Success(ciuadesDTO);
        }
        catch (Exception E)
        {
            return Result<List<CiudadRecord>>.Fail(E.Message);
        }
    }
}