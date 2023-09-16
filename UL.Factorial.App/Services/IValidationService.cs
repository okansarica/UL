namespace UL.Factorial.App.Services;

using Models;

public interface IValidationService
{
    /// <summary>
    /// Checks the given input and returns the validation result with an error message
    /// </summary>
    /// <param name="input">User input</param>
    /// <returns></returns>
    ValidationResult IsValid(string? input);
}
