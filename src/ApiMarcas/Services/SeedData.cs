using ApiMarcas.Data;

namespace ApiMarcas.Services;

/// <summary>
/// Seeds initial data into the database
/// </summary>
public static class SeedData
{
    public static void Initialize(MarcasContext context)
    {
        // Only seed if the table is empty
        if (context.MarcasAutos.Any())
        {
            return;
        }

        var marcas = new[]
        {
            new Models.MarcaAuto { Nombre = "Toyota", PaisOrigen = "Japón" },
            new Models.MarcaAuto { Nombre = "Ford", PaisOrigen = "Estados Unidos" },
            new Models.MarcaAuto { Nombre = "BMW", PaisOrigen = "Alemania" }
        };

        context.MarcasAutos.AddRange(marcas);
        context.SaveChanges();
    }
}

