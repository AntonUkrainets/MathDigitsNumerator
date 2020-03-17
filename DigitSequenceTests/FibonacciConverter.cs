using DigitSequence.Business.Implements;
using DigitSequence.Operations;
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
            var operation = new FibonacciOperation 
            { 
                Start = startIndex,
                End = endIndex
            };

            var sequenceNumerator = new FibonacciGenerator();

            // Act
            var actualValue = sequenceNumerator.Calculate(operation);

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void CanCalculate_Positive()
        {
            // Arange
            var expectedValue = true;

            var sequenceNumerator = new FibonacciGenerator();

            var operation = new FibonacciOperation();

            // Act
            var actulValue = sequenceNumerator.CanCalculate(operation);

            // Assert
            Assert.Equal(expectedValue, actulValue);
        }

        [Fact]
        public void CanCalculate_Negative()
        {
            // Arange
            var expectedValue = false;

            var sequenceNumerator = new FibonacciGenerator();

            var operation = new SequenceOperation();

            // Act
            var actulValue = sequenceNumerator.CanCalculate(operation);

            // Assert
            Assert.Equal(expectedValue, actulValue);
        }
    }
}