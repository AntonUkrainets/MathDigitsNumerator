using DigitSequence.Business.Operations.Sequence;
using DigitSequence.Core;
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
            var env = new AppEnvironment();
            var task = new SequenceTask(number);

            // Act
            var actualValue = env.Calculate(task);

            // Assert
            Assert.Equal(expectedValue, actualValue.Result);
        }
    }
}