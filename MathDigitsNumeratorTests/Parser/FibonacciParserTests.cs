using System;
using MathDigitsNumerator.Business.Operations.Fibonacci;
using MathDigitsNumerator.Parser;
using Xunit;

namespace MathDigitsNumeratorTests.Parser
{
    public class FibonacciParserTests
    {
        #region Private Members

        private readonly FibonacciParser fibonacciParser;

        #endregion

        public FibonacciParserTests()
        {
            fibonacciParser = new FibonacciParser();
        }

        [Theory]
        [InlineData("1", "2")]
        [InlineData("a", "b")]
        [InlineData("1", "a")]
        public void CanParse_Positive(params string[] args)
        {
            // Act
            var actualValue = fibonacciParser.CanParse(args);

            // Assert
            Assert.True(actualValue);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("a", "b", "c")]
        public void CanParse_Negative(params string[] args)
        {
            // Act
            var actualValue = fibonacciParser.CanParse(args);

            // Assert
            Assert.False(actualValue);
        }

        [Theory]
        [InlineData(1, 2, "1", "2")]
        [InlineData(3, 4, "3", "4")]
        public void Parse(
            int startIndex,
            int endIndex,
            params string[] args
        )
        {
            // Act
            var actualValue = (FibonacciTask)fibonacciParser.Parse(args);

            // Assert
            Assert.Equal(startIndex, actualValue.Start);
            Assert.Equal(endIndex, actualValue.End);
        }

        [Theory]
        [InlineData("a", "2")]
        [InlineData("3", "b")]
        [InlineData("a", "b")]
        public void Parse_TryParseToDigit(params string[] args)
        {
            // Assert
            Assert.Throws<FormatException>(() => fibonacciParser.Parse(args));
        }

        [Theory]
        [InlineData("-1", "1")]
        [InlineData("3", "-3")]
        [InlineData("-5", "0")]
        public void Parse_IsPositiveNumber(params string[] args)
        {
            // Assert
            Assert.Throws<ArgumentException>(() => fibonacciParser.Parse(args));
        }
    }
}