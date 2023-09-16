namespace UL.Factorial.App.Tests;

using FluentAssertions;
using Services;

public class ValidationServiceTests
{
    private readonly IValidationService _validationService = new ValidationService();

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("abc")]
    [InlineData("123a")]
    [InlineData("z12")]
    [InlineData("a123f")]
    [InlineData("12xc34")]
    [InlineData("12.234")]
    [InlineData("12,234")]
    
    public void ReturnsNotValidResultWhenInputNotANumber(string input)
    {
        //act
        var validationResult = _validationService.IsValid(input);

        //assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.ValidationErrorMessage.Should().Be("Please enter valid positive number.");
    }
    
    [Theory]
    [InlineData("80")]
    [InlineData("66")]
    public void ReturnsNotValidResultWhenInputIsGreaterThan65(string input)
    {
        //act
        var validationResult = _validationService.IsValid(input);

        //assert
        validationResult.IsValid.Should().BeFalse();
        validationResult.ValidationErrorMessage.Should().Be("Please enter a number less than 65.");
    }

    [Theory]
    [InlineData("0")]
    [InlineData("1")]
    [InlineData("40")]
    [InlineData("65")]
    
    public void ReturnsValidResultWhenInputIsNumber(string input)
    {
        //act
        var validationResult = _validationService.IsValid(input);

        //assert
        validationResult.IsValid.Should().BeTrue();
    }
}
