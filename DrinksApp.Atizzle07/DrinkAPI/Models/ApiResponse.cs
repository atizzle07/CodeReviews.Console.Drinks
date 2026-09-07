using Newtonsoft.Json;

namespace DrinksAPI.Models;

public class ApiResponse
{
    [JsonProperty("drinks")] public List<RecipeDTO>? Drinks { get; set; }
}
