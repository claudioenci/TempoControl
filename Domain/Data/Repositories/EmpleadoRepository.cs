using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories;

public class EmpleadoRepository : IEmpleadoRepository
{
    private readonly TempoDbContext _db;

    public EmpleadoRepository(TempoDbContext db)
    {
        _db = db;
    }

    public void Add(Empleado e)
    {
        _db.Empleados.Add(e);
    }

    public Empleado? Get(int id)
    {
        return _db.Empleados.FirstOrDefault(x => x.Id == id);
    }

    public List<Empleado> GetAll()
    {
        return _db.Empleados.ToList();
    }

    public void Update(Empleado e)
    {
        _db.Empleados.Update(e);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}
