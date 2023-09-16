namespace UL.Factorial.App.Tests;

using FluentAssertions;
using Models;
using Moq;
using Services;

public class AppTests
{
    private readonly App _app;
    private readonly Mock<IValidationService> _validationServiceMock = new Mock<IValidationService>();
    private readonly Mock<ICalculationService> _calculationServiceMock = new Mock<ICalculationService>();
    private readonly StringWriter _consoleOutput;
    public AppTests()
    {
        _app = new App(_validationServiceMock.Object, _calculationServiceMock.Object);
        _consoleOutput = new StringWriter();
        Console.SetOut(_consoleOutput);
    }

    [Theory]
    [InlineData("exit")]
    [InlineData("Exit")]
    [InlineData("exIT")]
    public void TerminatesWhenUserInputIsNotCaseSensitiveExit(string input)
    {
        //Arrange
        Console.SetIn(new StringReader(input));
        
        // Act
        _app.Run(Array.Empty<string>());
        
        // Assert
        _calculationServiceMock.Verify(cs => cs.CalculateFactorial(It.IsAny<ulong>()), Times.Never);
        _validationServiceMock.Verify(cs => cs.IsValid(It.IsAny<string>()), Times.Never);
        _consoleOutput.ToString().Should().Contain("Please enter the number for which you want the factorial to be calculated. Type 'Exit' to terminate the application");
    }

    [Fact]
    public void PrintValidationMessageUntilInputIsValid()
    {
        //Arrange
        Console.SetIn(new StringReader("input1\ninput2\nexit\n"));
        _validationServiceMock.Setup(p => p.IsValid(It.IsAny<string?>())).Returns(new ValidationResult("Please enter valid positive number."));
        
        // Act
        _app.Run(Array.Empty<string>());
        
        // Assert
        _calculationServiceMock.Verify(cs => cs.CalculateFactorial(It.IsAny<ulong>()), Times.Never);
        _validationServiceMock.Verify(cs => cs.IsValid(It.IsAny<string>()), Times.Exactly(2));
        _consoleOutput.ToString().Should().Contain("Please enter valid positive number.");
    }

    [Fact]
    public void CalculateFactorialWhenInputIsValid()
    {
        //Arrange
        Console.SetIn(new StringReader("5"));
        _validationServiceMock.Setup(p => p.IsValid(It.IsAny<string?>())).Returns(new ValidationResult());
        _calculationServiceMock.Setup(p => p.CalculateFactorial(5)).Returns(120);
        
        // Act
        _app.Run(Array.Empty<string>());
        
        //Assert
        _calculationServiceMock.Verify(cs => cs.CalculateFactorial(It.IsAny<ulong>()), Times.Once);
        _validationServiceMock.Verify(cs => cs.IsValid(It.IsAny<string>()), Times.Once);
        _consoleOutput.ToString().Should().Contain($"The calculated result is: 120");
    }
}
