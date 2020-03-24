using MathDigitsNumerator.Business.Operations.Sequence;
using Xunit;

namespace MathDigitsNumeratorTests.Business.Operations.Sequence
{
    public class SequenceTaskTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        public void Ctor(int endIndex)
        {
            // Act
            var actualValue = new SequenceTask(endIndex);

            // Assert
            Assert.Equal(endIndex, actualValue.End);
        }
    }
}