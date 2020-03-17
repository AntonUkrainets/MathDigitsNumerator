using DigitSequence.Business.Operations.Fibonacci;
using DigitSequence.Core;
using Xunit;

namespace DigitSequenceTests
{
    public class FibonacciConverter
    {
        [Theory]
        [InlineData(0, 5, new int[] { 0, 1, 1, 2, 3, 5})]
        [InlineData(1, 1, new int[] { 1, 1 })]
        [InlineData(4, 2, new int[] { })]
        [InlineData(10, 0, new int[] { })]
        [InlineData(0, 10, new int[] { 0, 1, 1, 2, 3, 5, 8 })]
        public void ConvertToFibonacci(int startIndex, int endIndex, int[] expectedValue)
        {
            // Arange
            var env = new AppEnvironment();
            var task = new FibonacciTask(startIndex, endIndex);

            // Act
            var actualValue = env.Calculate(task);

            // Assert
            Assert.Equal(expectedValue, actualValue.Result);
        }
    }
}