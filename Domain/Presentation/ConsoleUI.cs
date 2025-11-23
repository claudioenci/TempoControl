
using Business;
using Data;
using Data.Repositories;
using System;

namespace Presentation;

public static class ConsoleUI
{
    public static void Run()
    {
        using var db = new TempoDbContext();
        db.Database.EnsureCreated();

        var repo = new EmpleadoRepository(db);
        var service = new EmpleadoService(repo);

        bool salir = false;
        while(!salir)
        {
            Console.WriteLine("\n=== TEMPOCONTROL ===");
            Console.WriteLine("1. Crear Empleado");
            Console.WriteLine("2. Listar Empleados");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");
            var op = Console.ReadLine();

            switch(op)
            {
                case "1":
                    Console.Write("Nombre: ");
                    var n = Console.ReadLine();
                    Console.Write("Dept: ");
                    var d = Console.ReadLine();
                    Console.Write("Posición: ");
                    var p = Console.ReadLine();
                    service.CrearEmpleado(n,d,p);
                    Console.WriteLine("Empleado creado.");
                    break;

                case "2":
                    var lista = service.Listar();
                    foreach(var e in lista)
                        Console.WriteLine($"{e.Id} - {e.NombreCompleto} - {e.Departamento} - Activo:{e.Activo}");
                    break;

                case "0": salir = true; break;
                default: Console.WriteLine("Opción inválida."); break;
            }
        }
    }
}