using DigitSequence.Business.Operations;
using DigitSequence.Business.Operations.Fibonacci;
using DigitSequence.Business.Operations.Sequence;
using Xunit;

namespace MathDigitsNumeratorTests.Business.Operations.Fibonacci
{
    public class FibonacciOperationTests
    {
        #region Private Members

        private readonly FibonacciOperation fibonacciOperation;

        #endregion

        public FibonacciOperationTests()
        {
            fibonacciOperation = new FibonacciOperation();
        }

        [Fact]
        public void CanCalculate_Positive()
        {
            // Arrange
            var operation = new FibonacciTask(0, 0);

            // Act
            var actualValue = fibonacciOperation.CanCalculate(operation);

            // Assert
            Assert.True(actualValue);
        }

        [Fact]
        public void CanCalculate_Negative()
        {
            // Arrange
            var operation = new SequenceTask(0);

            // Act
            var actualValue = fibonacciOperation.CanCalculate(operation);

            // Assert
            Assert.False(actualValue);
        }

        [Theory]
        [InlineData(0, 3, 0, 1, 1, 2, 3)]
        [InlineData(1, 3, 1, 1, 2, 3)]
        [InlineData(1, 5, 1, 1, 2, 3, 5)]
        [InlineData(1, 13, 1, 1, 2, 3, 5, 8, 13)]
        public void Calculate_Positive(
            int startIndex,
            int endIndex,
            params int[] args
        )
        {
            // Arrange
            var operation = new FibonacciTask(startIndex, endIndex);

            // Act
            var actualValue = (MathOperationResult)fibonacciOperation.Calculate(operation);

            // Assert
            Assert.Equal(args, actualValue.Result);
        }
    }
}