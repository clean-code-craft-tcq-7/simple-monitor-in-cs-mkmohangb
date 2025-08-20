using Xunit;
using Moq;

public class CheckerTests
{
    [Fact]
    public void NotOkWhenAnyVitalIsOffRange()
    {
        var mockDisplay = new Mock<ICheckerDisplay>();
        var checker = new Checker(mockDisplay.Object);

        Assert.False(checker.VitalsOk(99f, 102, 70));
        mockDisplay.Verify(d => d.DisplayVitalsAlert("Pulse rate is out of range!"), Times.Once);

        // Reset mock for the next assertion
        mockDisplay = new Mock<ICheckerDisplay>();
        checker = new Checker(mockDisplay.Object);
        Assert.True(checker.VitalsOk(98.1f, 70, 98));
        mockDisplay.Verify(d => d.DisplayVitalsAlert(It.IsAny<string>()), Times.Never);
    }
}