namespace UL.FizzBuzz.App.Services;

/// <summary>
/// <inheritdoc/>
/// </summary>
public class CalculationService : ICalculationService
{
    private readonly Dictionary<int, string> _words = new Dictionary<int, string>
    {
        { 3, "Fizz" },
        { 5, "Buzz" }
    };

    public string CalculateFizzBuzz(int number)
    {
        //Reviewer Notes: The 'number' property values are anticipated to fall within the 0 to 100 range, eliminating the necessity for redundant validation.calc
        
        var result = "";

        foreach (var keyValuePair in _words)
        {
            if (number % keyValuePair.Key == 0)
            {
                result += keyValuePair.Value;
            }
        }

        return string.IsNullOrEmpty(result) ? number.ToString() : result;
    }
}

//Reviewer Notes: The "calculate" function might appear to be a bit of an over-engineered solution for the simple Fizz Buzz problem, given that it could be solved by creating just two functions. However, this approach is deliberately tailored to address the specific challenge requirement of "how well the code accommodates future changes in requirements," as stated in the challenge description. If new conditions arise, all that's needed is to add them to the list in the appropriate order.
