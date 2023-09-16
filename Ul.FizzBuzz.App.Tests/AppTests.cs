namespace Ul.FizzBuzz.App.Tests;

using Moq;
using UL.FizzBuzz.App;
using UL.FizzBuzz.App.Services;

public class AppTests
{
    private readonly App _app;
    private readonly Mock<ICalculationService> _calculationServiceMock = new Mock<ICalculationService>();
    public AppTests()
    {
        _app = new App(_calculationServiceMock.Object);
    }

    [Fact]
    public void TerminatesWhenUserInputIsNotCaseSensitiveExit()
    {
        //Arrange
        _calculationServiceMock.Setup(p => p.CalculateFizzBuzz(It.IsAny<int>())).Returns((int input) => input.ToString());
        
        // Act
        _app.Run(Array.Empty<string>());
        
        // Assert
        _calculationServiceMock.Verify(cs => cs.CalculateFizzBuzz(It.IsAny<int>()), Times.Exactly(100));
    }

}
