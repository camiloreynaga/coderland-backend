using ApiMarcas.Data;
using ApiMarcas.Models;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;

namespace ApiMarcas.Tests;

/// <summary>
/// Unit tests for MarcasContext
/// </summary>
public class MarcasContextTests : IDisposable
{
    private readonly MarcasContext _context;
    private readonly DbContextOptions<MarcasContext> _options;

    public MarcasContextTests()
    {
        _options = new DbContextOptionsBuilder<MarcasContext>()
            .UseInMemoryDatabase(databaseName: $"TestDb_{Guid.NewGuid()}")
            .Options;

        _context = new MarcasContext(_options);
    }

    [Fact]
    public async Task AddMarca_ShouldSaveToDatabase()
    {
        // Arrange
        var marca = new MarcaAuto { Nombre = "Mercedes", PaisOrigen = "Alemania" };

        // Act
        _context.MarcasAutos.Add(marca);
        await _context.SaveChangesAsync();

        // Assert
        var savedMarca = await _context.MarcasAutos.FirstOrDefaultAsync(m => m.Nombre == "Mercedes");
        savedMarca.Should().NotBeNull();
        savedMarca!.Id.Should().BeGreaterThan(0);
        savedMarca.Nombre.Should().Be("Mercedes");
        savedMarca.PaisOrigen.Should().Be("Alemania");
    }

    [Fact]
    public async Task MarcasAutos_DbSet_ShouldExist()
    {
        // Assert
        _context.MarcasAutos.Should().NotBeNull();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

