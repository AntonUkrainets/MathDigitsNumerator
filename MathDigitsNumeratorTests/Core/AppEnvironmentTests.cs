using MathDigitsNumerator.Business.Operations;
using MathDigitsNumerator.Business.Operations.Fibonacci;
using MathDigitsNumerator.Business.Operations.Sequence;
using MathDigitsNumerator.Core;
using Xunit;

namespace MathDigitsNumeratorTests.Core
{
    public class AppEnvironmentTests
    {
        #region Private Members

        private readonly AppEnvironment appEnvironment;

        #endregion

        public AppEnvironmentTests()
        {
            appEnvironment = new AppEnvironment();
        }

        [Theory]
        [InlineData("1")]
        [InlineData("a")]
        [InlineData("1", "2")]
        [InlineData("a", "b")]
        public void ShowHelpRequired_Positive(params string[] args)
        {
            // Act
            var actualValue = appEnvironment.ShowHelpRequired(args);

            // Assert
            Assert.False(actualValue);
        }

        [Theory]
        [InlineData("1", "2", "3")]
        [InlineData("a", "b", "c", "d")]
        public void ShowHelpRequired_Negative(params string[] args)
        {
            // Act
            var actualValue = appEnvironment.ShowHelpRequired(args);

            // Assert
            Assert.True(actualValue);
        }

        [Theory]
        [InlineData(1, 2, "1", "2")]
        [InlineData(3, 4, "3", "4")]
        public void GetTask_Fibonacci(
            int startIndex,
            int endIndex,
            params string[] args
        )
        {
            // Act
            var actualValue = (FibonacciTask)appEnvironment.GetTask(args);

            // Assert
            Assert.Equal(startIndex, actualValue.Start);
            Assert.Equal(endIndex, actualValue.End);
        }

        [Theory]
        [InlineData(1, "1")]
        [InlineData(3, "3")]
        public void GetTask_Sequence(int endIndex, params string[] args)
        {
            // Act
            var actualValue = (SequenceTask)appEnvironment.GetTask(args);

            // Assert
            Assert.Equal(endIndex, actualValue.End);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 0, 1, 1)]
        [InlineData(1, 3, 1, 1, 2, 3)]
        [InlineData(0, 13, 0, 1, 1, 2, 3, 5, 8, 13)]
        public void Calculate_Fibonacci(
            int startIndex,
            int endIndex,
            params int[] result
        )
        {
            // Arrange
            var fibonacciTask = new FibonacciTask(startIndex, endIndex);

            // Act
            var actualValue = (MathOperationResult)appEnvironment.Calculate(fibonacciTask);

            // Assert
            Assert.Equal(result, actualValue.Result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1, 0)]
        [InlineData(5, 0, 1, 2)]
        [InlineData(26, 0, 1, 2, 3, 4, 5)]
        public void Calculate_Sequence(int endIndex, params int[] result)
        {
            // Arrange
            var sequenceTask = new SequenceTask(endIndex);

            // Act
            var actualValue = (MathOperationResult)appEnvironment.Calculate(sequenceTask);

            // Assert
            Assert.Equal(result, actualValue.Result);
        }
    }
}