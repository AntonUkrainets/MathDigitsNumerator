using System;
using MathDigitsNumerator.Business.Interfaces;
using MathDigitsNumerator.Business.Operations.Sequence;
using MathDigitsNumerator.Parser.Interfaces;

namespace MathDigitsNumerator.Parser
{
    public class SequenceParser : IParser
    {
        public bool CanParse(string[] args)
        {
            return args.Length == 1;
        }

        public IMathTask Parse(string[] args)
        {
            TryParseToDigit(args[0], out int endIndex);
            IsPositiveNumber(endIndex);

            return new SequenceTask(endIndex);
        }

        private void TryParseToDigit(string inputString, out int index)
        {
            if (!int.TryParse(inputString, out index))
                throw new FormatException($"Start index '{index}' has incorrect format");
        }

        private void IsPositiveNumber(int number)
        {
            if (number < 0)
                throw new ArgumentException($"The number '{number}' must be greather or equals '0'");
        }
    }
}