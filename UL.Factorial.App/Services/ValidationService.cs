namespace UL.Factorial.App.Services;

using Models;

public class ValidationService : IValidationService
{
    ///<inheritdoc/>
    public ValidationResult IsValid(string? input)
    {
        if (!ulong.TryParse(input, out var number))
        {
            return new ValidationResult("Please enter valid positive number.");
        }
        
        // ulong can only store the data up to 65! so 65 is the limit. If bigger numbers needs to be calculated BigInteger type can be used
        const ulong threshold = 65;
        if (number > threshold)
        {
            return new ValidationResult($"Please enter a number less than {threshold}.");
        }
        return new ValidationResult();
    }
}
