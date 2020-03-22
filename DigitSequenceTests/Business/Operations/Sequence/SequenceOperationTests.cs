using DigitSequence.Business.Operations;
using DigitSequence.Business.Operations.Fibonacci;
using DigitSequence.Business.Operations.Sequence;
using Xunit;

namespace MathDigitsNumeratorTests.Business.Operations.Sequence
{
    public class SequenceOperationTests
    {
        #region Private Members

        private readonly SequenceOperation sequenceOperation;

        #endregion

        public SequenceOperationTests()
        {
            sequenceOperation = new SequenceOperation();
        }

        [Fact]
        public void CanCalculate_Positive()
        {
            // Arrange
            var operation = new SequenceTask(0);

            // Act
            var actualValue = sequenceOperation.CanCalculate(operation);

            // Assert
            Assert.True(actualValue);
        }

        [Fact]
        public void CanCalculate_Negative()
        {
            // Arrange
            var operation = new FibonacciTask(0, 0);

            // Act
            var actualValue = sequenceOperation.CanCalculate(operation);

            // Assert
            Assert.False(actualValue);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1, 0)]
        [InlineData(15, 0, 1, 2, 3)]
        [InlineData(26, 0, 1, 2, 3, 4, 5)]
        public void Calculate_Positive(int endIndex, params int[] args)
        {
            // Arrange
            var operation = new SequenceTask(endIndex);

            // Act
            var actualValue = (MathOperationResult)sequenceOperation.Calculate(operation);

            // Assert
            Assert.Equal(args, actualValue.Result);
        }
    }
}