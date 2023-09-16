namespace UL.Factorial.App;


using Services;

public class App
{
    private readonly IValidationService _validationService;
    private readonly ICalculationService _calculationService;
    public App(IValidationService validationService, ICalculationService calculationService)
    {
        _validationService = validationService;
        _calculationService = calculationService;
    }
    public void Run(string[] args)
    {
        var userInput = GetUserInput();
        if (string.IsNullOrEmpty(userInput))
        {
            return;
        }

        var number = ulong.Parse(userInput);
        var result = _calculationService.CalculateFactorial(number);
        Console.WriteLine($"The calculated result is: {result}");
    }

    private string? GetUserInput()
    {
        Console.WriteLine("Please enter the number for which you want the factorial to be calculated. Type 'Exit' to terminate the application");
        
        string? userInput = null;
        var isValid = false;
        while (!isValid)
        {
            userInput = Console.ReadLine();
            if (string.Equals(userInput, "exit", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }
            var validationResult = _validationService.IsValid(userInput);
            if (!validationResult.IsValid)
            {
                Console.WriteLine(validationResult.ValidationErrorMessage);
                continue;
            }
            isValid = true;
        }
        return userInput;
    }
}
