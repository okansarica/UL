namespace UL.Factorial.App.Services;

public class CalculationService:ICalculationService
{
    public ulong CalculateFactorial(ulong number)
    {
        ulong result = 1;
        for (ulong i = 2; i <= number; i++)
        {
            result *= i;
        }
        return result;
    }
}
