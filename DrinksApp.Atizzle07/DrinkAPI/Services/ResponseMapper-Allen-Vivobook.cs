using DrinksAPI.Models;

namespace DrinksAPI.Services;

public class ResponseMapper
{
    public static RecipeResponse ReturnRecipeData(RecipeDTO dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException(nameof(dto));
        }
        else
        {
            RecipeResponse response = new RecipeResponse();
            response.Id = dto.Id;
            response.DrinkName = dto.DrinkName;
            response.Category = dto.Category;
            response.Glass = dto.Glass;
            response.InstructionsText = dto.InstructionsText ?? "";


            var ingredients = new[]
            {
                dto.Ingredient1,
                dto.Ingredient2,
                dto.Ingredient3,
                dto.Ingredient4,
                dto.Ingredient5,
                dto.Ingredient6,
                dto.Ingredient7,
                dto.Ingredient8,
                dto.Ingredient9,
                dto.Ingredient10,
                dto.Ingredient11,
                dto.Ingredient12,
                dto.Ingredient13,
                dto.Ingredient14,
                dto.Ingredient15,
            };

            var measurements = new[]
            {
                dto.Measure1,
                dto.Measure2,
                dto.Measure3,
                dto.Measure4,
                dto.Measure5,
                dto.Measure6,
                dto.Measure7,
                dto.Measure8,
                dto.Measure9,
                dto.Measure10,
                dto.Measure11,
                dto.Measure12,
                dto.Measure13,
                dto.Measure14,
                dto.Measure15,
            };

            List<IngredientMeasurement> ingredientMeasurements = new();

            for (int i = 0; i < ingredients.Length; i++)
            {
                string ingredient = ingredients[i] ?? "";
                string measurement = measurements[i] ?? "";

                ingredientMeasurements.Add(
                new IngredientMeasurement
                {
                    Ingredient = ingredient,
                    Measurement = measurement
                });

            }
            response.IngredientList = ingredientMeasurements;

            return response;
        }
    }
}
