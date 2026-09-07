namespace DrinksAPI.Services;

public static class Formatter
{
    public static string InstructionsFormat(string? instructions)
    {
        instructions = instructions ?? "";
        return instructions.Replace(".", ".\n");
    }
}
