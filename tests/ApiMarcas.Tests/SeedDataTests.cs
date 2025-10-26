using ApiMarcas.Data;
using ApiMarcas.Services;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;

namespace ApiMarcas.Tests;

/// <summary>
/// Unit tests for SeedData service
/// </summary>
public class SeedDataTests : IDisposable
{
    private readonly MarcasContext _context;
    private readonly DbContextOptions<MarcasContext> _options;

    public SeedDataTests()
    {
        _options = new DbContextOptionsBuilder<MarcasContext>()
            .UseInMemoryDatabase(databaseName: $"TestDb_{Guid.NewGuid()}")
            .Options;

        _context = new MarcasContext(_options);
    }

    [Fact]
    public void Initialize_ShouldAddMarcas_WhenTableIsEmpty()
    {
        // Act
        SeedData.Initialize(_context);

        // Assert
        var marcas = _context.MarcasAutos.ToList();
        marcas.Should().HaveCount(3);
        marcas.Should().Contain(m => m.Nombre == "Toyota");
        marcas.Should().Contain(m => m.Nombre == "Ford");
        marcas.Should().Contain(m => m.Nombre == "BMW");
    }

    [Fact]
    public void Initialize_ShouldNotAddMarcas_WhenTableIsNotEmpty()
    {
        // Arrange - Add one marca manually first
        _context.MarcasAutos.Add(new Models.MarcaAuto { Nombre = "Custom Brand", PaisOrigen = "Unknown" });
        _context.SaveChanges();

        // Act
        SeedData.Initialize(_context);

        // Assert - Should still only have 1 marca
        var marcas = _context.MarcasAutos.ToList();
        marcas.Should().HaveCount(1);
        marcas.Should().Contain(m => m.Nombre == "Custom Brand");
    }

    [Fact]
    public void Initialize_ShouldAddCorrectMarcasData()
    {
        // Act
        SeedData.Initialize(_context);

        // Assert
        var toyota = _context.MarcasAutos.FirstOrDefault(m => m.Nombre == "Toyota");
        toyota.Should().NotBeNull();
        toyota!.PaisOrigen.Should().Be("Japón");

        var ford = _context.MarcasAutos.FirstOrDefault(m => m.Nombre == "Ford");
        ford.Should().NotBeNull();
        ford!.PaisOrigen.Should().Be("Estados Unidos");

        var bmw = _context.MarcasAutos.FirstOrDefault(m => m.Nombre == "BMW");
        bmw.Should().NotBeNull();
        bmw!.PaisOrigen.Should().Be("Alemania");
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

