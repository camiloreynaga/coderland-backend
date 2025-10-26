using ApiMarcas.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMarcas.Data;

/// <summary>
/// Database context for car brands
/// </summary>
public class MarcasContext : DbContext
{
    public MarcasContext(DbContextOptions<MarcasContext> options) : base(options)
    {
    }

    public DbSet<MarcaAuto> MarcasAutos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Configure table name
        modelBuilder.Entity<MarcaAuto>().ToTable("MarcasAutos");
    }
}

