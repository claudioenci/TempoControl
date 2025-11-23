using Data.Repositories;
using Domain;
using System.Collections.Generic;

namespace Business;

public class EmpleadoService
{
    private readonly IEmpleadoRepository _repo;

    public EmpleadoService(IEmpleadoRepository repo)
    {
        _repo = repo;
    }

    public void CrearEmpleado(string nombre, string dept, string pos)
    {
        var emp = new Empleado
        {
            NombreCompleto = nombre ?? string.Empty,
            Departamento = dept ?? string.Empty,
            Posicion = pos ?? string.Empty
        };
        _repo.Add(emp);
        _repo.Save();
    }

    public List<Empleado> Listar() => _repo.GetAll();
}
