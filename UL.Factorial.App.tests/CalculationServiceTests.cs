namespace UL.Factorial.App.Tests;

using FluentAssertions;
using Services;

public class CalculationServiceTests
{
    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(5, 120)]
    public void ReturnsCalculatedFactorialValue(ulong number, ulong result)
    {
        //arrange
        var calculationService = new CalculationService();
        
        //act
        var calculatedResult = calculationService.CalculateFactorial(number);
        
        //assert
        calculatedResult.Should().Be(result);

    }
}
