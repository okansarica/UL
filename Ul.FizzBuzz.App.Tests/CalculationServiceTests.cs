namespace Ul.FizzBuzz.App.Tests;

using FluentAssertions;
using UL.FizzBuzz.App.Services;

public class CalculationServiceTests
{
    private readonly ICalculationService _calculationService = new CalculationService();
    
    [Theory]
    [InlineData(3, "Fizz")]
    [InlineData(5, "Buzz")]
    [InlineData(15, "FizzBuzz")]
    [InlineData(36, "Fizz")]
    [InlineData(65, "Buzz")]
    [InlineData(75, "FizzBuzz")]
    public void ReturnsFizzBuzzForValuesWhichCanBeDividedByFiveOrThree(int number, string result)
    {
        //arrange
        
        //act
        var calculatedResult = _calculationService.CalculateFizzBuzz(number);
        
        //assert
        calculatedResult.Should().Be(result);

    }

    [Theory]
    [InlineData(1, "1")]
    [InlineData(19, "19")]
    [InlineData(64, "64")]
    public void ReturnsGivenNumbersForValuesWhichCanNotBeDividedByFiveOrThree(int number, string result)
    {
        //arrange
        
        //act
        var calculatedResult = _calculationService.CalculateFizzBuzz(number);
        
        //assert
        calculatedResult.Should().Be(result);
    }
}
