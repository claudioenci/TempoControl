using Domain;
using System.Collections.Generic;

namespace Data.Repositories;

public interface IEmpleadoRepository
{
    void Add(Empleado e);
    Empleado? Get(int id);
    List<Empleado> GetAll();
    void Update(Empleado e);
    void Save();
}
