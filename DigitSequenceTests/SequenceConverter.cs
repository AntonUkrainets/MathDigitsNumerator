using DigitSequence.Business.Implements;
using DigitSequence.Operations;
using Xunit;

namespace DigitSequenceTests
{
    public class SequenceConverter
    {
        [Theory]
        [InlineData(0, new int[] { })]
        [InlineData(1, new int[] { 0 })]
        [InlineData(4, new int[] { 0, 1 })]
        [InlineData(5, new int[] { 0, 1, 2 })]
        [InlineData(30, new int[] { 0, 1, 2, 3, 4, 5 })]
        [InlineData(100, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        public void ConvertToSequence(int number, int[] expectedValue)
        {
            // Arange
            var operation = new SequenceOperation { End = number };

            var sequenceNumerator = new SequenceGenerator();

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

            var sequenceNumerator = new SequenceGenerator();

            var operation = new SequenceOperation();

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

            var sequenceNumerator = new SequenceGenerator();

            var operation = new FibonacciOperation();

            // Act
            var actulValue = sequenceNumerator.CanCalculate(operation);

            // Assert
            Assert.Equal(expectedValue, actulValue);
        }
    }
}