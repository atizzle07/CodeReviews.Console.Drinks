using Newtonsoft.Json;

namespace DrinksAPI.Models;

public  class DrinkResponse
{
    [JsonProperty("drinks")]
    public List<DrinkItem> Drinks { get; set; } = new();
}