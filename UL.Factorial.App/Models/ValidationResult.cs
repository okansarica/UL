namespace UL.Factorial.App.Models;

/// <summary>
/// The class is used to return validation message and status
/// </summary>
public class ValidationResult
{
    public ValidationResult()
    {
        IsValid = true;
    }

    public ValidationResult(string validationErrorMessage)
    {
        ValidationErrorMessage = validationErrorMessage;
        
    }
    public bool IsValid { get; }
    
    /// <summary>
    /// When the IsValid property is set to false the validation message must bu populated
    /// </summary>
    public string? ValidationErrorMessage { get; }
}
