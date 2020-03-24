using MathDigitsNumerator.Business.Operations.Fibonacci;
using Xunit;

namespace MathDigitsNumeratorTests.Business.Operations.Fibonacci
{
    public class FibonacciTaskTests
    {
        [Theory]
        [InlineData(1, 2)]
        [InlineData(3, 4)]
        [InlineData(5, 6)]
        public void Ctor(int startIndex, int endIndex)
        {
            // Act
            var actualValue = new FibonacciTask(startIndex, endIndex);

            // Assert
            Assert.Equal(startIndex, actualValue.Start);
            Assert.Equal(endIndex, actualValue.End);
        }
    }
}