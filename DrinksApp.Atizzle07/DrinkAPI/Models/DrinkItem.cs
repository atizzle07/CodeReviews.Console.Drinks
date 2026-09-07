using Newtonsoft.Json;

namespace DrinksAPI.Models;

public class DrinkItem
{
    [JsonProperty("strDrink")]
    public string Name { get; set; } = "";
    [JsonProperty("idDrink")]
    public int Id { get; set; }
}
