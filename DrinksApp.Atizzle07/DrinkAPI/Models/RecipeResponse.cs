using Newtonsoft.Json;
using System.Diagnostics.Metrics;

namespace DrinksAPI.Models;

public class RecipeResponse
{
    public int Id { get; set; }

    public string? DrinkName { get; set; }

    public string? Category { get; set; }

    public string? Glass { get; set; }

    public string? InstructionsText { get; set; }

    public List<IngredientMeasurement>? IngredientList { get; set; }
}