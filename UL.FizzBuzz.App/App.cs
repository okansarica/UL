namespace UL.FizzBuzz.App;

using Services;

public class App
{
    private readonly ICalculationService _calculationService;
    public App(ICalculationService calculationService)
    {
        _calculationService = calculationService;
    }
    public void Run(string[] args)
    {
        for (int i = 1; i <= 100; i++)
        {
            Console.WriteLine(_calculationService.CalculateFizzBuzz(i));
        }
    }
}
