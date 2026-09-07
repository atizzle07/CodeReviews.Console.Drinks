using Newtonsoft.Json;

namespace DrinksApp.Models;

public class CategoryResponse
{
    [JsonProperty("drinks")]
    public List<CategoryItem> Drinks { get; set; } = new();
}

public class CategoryItem
{
    [JsonProperty("strCategory")]
    public string Name { get; set; } = "";
}
