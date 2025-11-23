using Domain;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Data;

public class TempoDbContext : DbContext
{
    public DbSet<Empleado> Empleados { get; set; } = null!;
    public DbSet<RegistroFichaje> Fichajes { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        
        var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "TempoControl.db");
        options.UseSqlite($"Data Source={dbPath}");
    }

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Empleado>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.NombreCompleto).IsRequired();
            e.Property(x => x.Departamento).IsRequired();
            e.Property(x => x.Posicion).IsRequired();
            e.HasMany(x => x.Fichajes).WithOne(f => f.Empleado).HasForeignKey(f => f.EmpleadoId);
        });

        model.Entity<RegistroFichaje>(r =>
        {
            r.HasKey(x => x.Id);
            r.Property(x => x.HoraEntrada).IsRequired();
        });
    }
}
