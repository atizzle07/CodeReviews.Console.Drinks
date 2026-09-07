using DrinksAPI.Models;
using DrinksApp.Services;
using Spectre.Console;
using System.Reflection;

public class UI
{
    #region Menu Setups
    public static void WelcomeMessage()
    {
        Rule rule = new();
        rule.Border = BoxBorder.Heavy;
        var figlet = new FigletText("DRINKS LOOKUP")
        {
            Justification = Justify.Center,
            Color = Color.White,
        };

        AnsiConsole.Write(rule);
        AnsiConsole.Write(figlet);
        AnsiConsole.Write(rule);
        Console.WriteLine("\n\n");
        AnsiConsole.MarkupLine("[bold orange3]Press Enter to Continue...[/]");
        Console.ReadKey();
    }
    public static void AddSpace(int lines)
    {
        for (int i = 0; i < lines; i++)
        {
            Console.WriteLine();
        }
    }
    public static void GoBack() //TODO - need to implmeent for en of main loop to select which part you want to go back to
    {

    }

    public static async Task<string> GetCategoryChoice()
    {
        List<string> categoryMenu = await LoadCategories();

        Console.Clear();
        var userInput = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Please select a menu Option:")
            .AddChoices(categoryMenu));
        return userInput;
    }
    public static async Task<string> GetDrinkChoice(string category)
    {
        List<KeyValuePair<int, string>> drinksMenuWithId = await LoadDrinks(category);
        List<string> drinksMenu = new List<string>();
        foreach (var item in drinksMenuWithId)
        {
            drinksMenu.Add(item.Value);
        }

        Console.Clear();
        AnsiConsole.MarkupLine($"Category Selected: [bold italic orange3]{category.ToUpper()}[/]");
        var userInput = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Please select a drink to view recipe:")
            .AddChoices(drinksMenu)
            .EnableSearch()
            .SearchPlaceholderText("Type to search...")
            .PageSize(15));

        // Select and return Menu Item ID based on the user's input
        if (userInput.ToLower() != "back")
        {
            userInput = drinksMenuWithId.FirstOrDefault(kvp => kvp.Value == userInput).Key.ToString();
            return userInput;
        }
        else return "Back";

    }
    public static async Task DisplayRecipeBasic(string drinkChoiceId)
    {
        Console.Clear();

        // call API to get recipe from ID and load into object
        RecipeResponse recipe = await ApiHelper.GetRecipe(drinkChoiceId);

        // Print Table headers
        Console.WriteLine("Type\t\tValue");
        for (int i = 0; i < 20; i++)
        {
            Console.Write('=');
        }

        Console.WriteLine();

        foreach (var property in recipe.GetType().GetProperties())
        {
            Console.WriteLine($"{property.Name}\t\t{property.GetValue(recipe)}");
        }
        Console.ReadKey();
    }
    public static async Task DisplayRecipeTable(string drinkChoiceId)
    {
        Console.Clear();

        // call API to get recipe from ID and load into object
        RecipeResponse recipe = await ApiHelper.GetRecipe(drinkChoiceId);

        var table = new Table().HideHeaders();
        var ingredientsTable = new Table();

        table.Title("[bold orange3]Drink Information[/]");
        table.AddColumn("Type", col => col.RightAligned());
        table.AddColumn("Value", col => col.LeftAligned());

        foreach (PropertyInfo property in recipe.GetType().GetProperties())
        {
            if (property.Name == "IngredientList" || property.Name == "Id" || property.Name == "InstructionsText")
            {
                continue;
            }
            else
            {
                table.AddRow(
                    property.Name.ToString(),
                    property.GetValue(recipe)?.ToString() ?? "");
            }
        }

        ingredientsTable.Title("[bold orange3]Ingredient List[/]");
        ingredientsTable.AddColumn("Ingredient", col => col.LeftAligned());
        ingredientsTable.AddColumn("Amount", col => col.LeftAligned());

        foreach (var item in recipe.IngredientList)
        {
            if(string.IsNullOrEmpty(item.Ingredient))
            {
                continue;
            } else
            {
                ingredientsTable.AddRow(
                item.Ingredient ?? "",
                item.Measurement ?? "");
            }
        }

        AnsiConsole.Write(table);
        AddSpace(2);
        AnsiConsole.Write(ingredientsTable);
        AddSpace(3);
        AnsiConsole.WriteLine(recipe.InstructionsText);
        string userChoice;




    }
    #endregion
    #region LoadData
    public static async Task<List<string>> LoadCategories()
    {
        var _categoryMenu = new List<string>();
        if (_categoryMenu.Count == 0)
        {
            _categoryMenu!.AddRange(await ApiHelper.GetAllCategories());
            _categoryMenu.Add("Exit"); // Append an exit option to the list.
            return _categoryMenu;
        }
        else
        {
            return _categoryMenu;
        }
    }

    public static async Task<List<KeyValuePair<int, string>>> LoadDrinks(string category)
    {
        var _drinksMenu = new List<KeyValuePair<int, string>>();
        _drinksMenu.AddRange(await ApiHelper.GetDrinksList(category));
        _drinksMenu.Insert(0, new KeyValuePair<int, string>(_drinksMenu.Count, "Back"));
        return _drinksMenu;
    }



    #endregion
}