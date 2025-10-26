using ApiMarcas.Controllers;
using ApiMarcas.Data;
using ApiMarcas.Models;
using ApiMarcas.Services;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace ApiMarcas.Tests;

/// <summary>
/// Unit tests for MarcasAutosController
/// </summary>
public class MarcasControllerTests : IDisposable
{
    private readonly MarcasContext _context;
    private readonly MarcasAutosController _controller;
    private readonly DbContextOptions<MarcasContext> _options;

    public MarcasControllerTests()
    {
        // Use InMemory database for testing
        _options = new DbContextOptionsBuilder<MarcasContext>()
            .UseInMemoryDatabase(databaseName: $"TestDb_{Guid.NewGuid()}")
            .Options;

        _context = new MarcasContext(_options);
        
        // Seed test data
        SeedTestData();
        
        var logger = new Microsoft.Extensions.Logging.Abstractions.NullLogger<MarcasAutosController>();
        _controller = new MarcasAutosController(_context, logger);
    }

    private void SeedTestData()
    {
        _context.MarcasAutos.AddRange(new List<MarcaAuto>
        {
            new MarcaAuto { Id = 1, Nombre = "Toyota", PaisOrigen = "Japón" },
            new MarcaAuto { Id = 2, Nombre = "Ford", PaisOrigen = "Estados Unidos" },
            new MarcaAuto { Id = 3, Nombre = "BMW", PaisOrigen = "Alemania" }
        });
        _context.SaveChanges();
    }

    [Fact]
    public async Task GetMarcas_ShouldReturnAllMarcas()
    {
        // Act
        var result = await _controller.GetMarcas();

        // Assert
        result.Should().NotBeNull();
        var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        var marcas = okResult.Value.Should().BeAssignableTo<IEnumerable<MarcaAuto>>().Subject;
        
        marcas.Should().HaveCount(3);
        marcas.Should().Contain(m => m.Nombre == "Toyota");
        marcas.Should().Contain(m => m.Nombre == "Ford");
        marcas.Should().Contain(m => m.Nombre == "BMW");
    }

    [Fact]
    public async Task GetMarcas_ShouldReturnCorrectMarcaData()
    {
        // Act
        var result = await _controller.GetMarcas();

        // Assert
        var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        var marcas = okResult.Value.Should().BeAssignableTo<IEnumerable<MarcaAuto>>().Subject.ToList();
        
        var toyota = marcas.First(m => m.Nombre == "Toyota");
        toyota.Should().NotBeNull();
        toyota.Id.Should().Be(1);
        toyota.PaisOrigen.Should().Be("Japón");
    }

    [Fact]
    public async Task GetMarcas_ShouldReturnEmptyList_WhenNoMarcasExist()
    {
        // Arrange
        _context.MarcasAutos.RemoveRange(_context.MarcasAutos);
        _context.SaveChanges();

        // Act
        var result = await _controller.GetMarcas();

        // Assert
        var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        var marcas = okResult.Value.Should().BeAssignableTo<IEnumerable<MarcaAuto>>().Subject;
        marcas.Should().BeEmpty();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

