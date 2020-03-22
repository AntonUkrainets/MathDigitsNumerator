using System;
using DigitSequence.Business.Operations.Sequence;
using DigitSequence.Parser;
using Xunit;

namespace MathDigitsNumeratorTests.Parser
{
    public class SequenceParserTests
    {
        #region Private Members

        private readonly SequenceParser sequenceParser;

        #endregion

        public SequenceParserTests()
        {
            sequenceParser = new SequenceParser();
        }

        [Theory]
        [InlineData("1")]
        [InlineData("-1")]
        [InlineData("a")]
        public void CanParse_Positive(params string[] args)
        {
            // Act
            var actualValue = sequenceParser.CanParse(args);

            // Assert
            Assert.True(actualValue);
        }

        [Theory]
        [InlineData("1", "b")]
        [InlineData("a", "b", "c")]
        public void CanParse_Negative(params string[] args)
        {
            // Act
            var actualValue = sequenceParser.CanParse(args);

            // Assert
            Assert.False(actualValue);
        }

        [Theory]
        [InlineData(1, "1")]
        [InlineData(3, "3")]
        public void Parse(int endIndex, params string[] args
        )
        {
            // Act
            var actualValue = (SequenceTask)sequenceParser.Parse(args);

            // Assert
            Assert.Equal(endIndex, actualValue.End);
        }

        [Theory]
        [InlineData("a")]
        public void Parse_TryParseToDigit(
            params string[] args
        )
        {
            // Assert
            Assert.Throws<FormatException>(() => sequenceParser.Parse(args));
        }

        [Theory]
        [InlineData("-5")]
        public void Parse_IsPositiveNumber(
            params string[] args
        )
        {
            // Assert
            Assert.Throws<ArgumentException>(() => sequenceParser.Parse(args));
        }
    }
}