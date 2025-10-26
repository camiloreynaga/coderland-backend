using ApiMarcas.Data;
using ApiMarcas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMarcas.Controllers;

/// <summary>
/// API controller for car brands
/// </summary>
[ApiController]
[Route("api/marcas")]
public class MarcasAutosController : ControllerBase
{
    private readonly MarcasContext _context;
    private readonly ILogger<MarcasAutosController> _logger;

    public MarcasAutosController(MarcasContext context, ILogger<MarcasAutosController> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Gets all car brands
    /// GET: api/marcas
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MarcaAuto>>> GetMarcas()
    {
        _logger.LogInformation("Fetching all car brands");
        
        var marcas = await _context.MarcasAutos.ToListAsync();
        return Ok(marcas);
    }
}

