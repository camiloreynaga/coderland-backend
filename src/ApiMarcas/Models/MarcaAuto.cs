namespace ApiMarcas.Models;

/// <summary>
/// Represents a car brand (marca de auto)
/// </summary>
public class MarcaAuto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? PaisOrigen { get; set; }
}

