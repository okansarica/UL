namespace UL.FizzBuzz.App.Services;

/// <summary>
/// Provides calculation for fizz buzz problem
/// </summary>
public interface ICalculationService
{
    /// <summary>
    /// Calculates and returns the associated word(s) for a given number.
    /// </summary>
    /// <param name="number">The positive integer to be evaluated.</param>
    /// <returns>A string containing the related word(s) or the number itself if not divisible by any custom numbers</returns>
    string CalculateFizzBuzz(int number);
}
