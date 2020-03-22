using System;
using DigitSequence.Business.Interfaces;
using DigitSequence.Business.Operations.Fibonacci;
using DigitSequence.Parser.Interfaces;

namespace DigitSequence.Parser
{
    public class FibonacciParser : IParser
    {
        public bool CanParse(string[] args)
        {
            return args.Length == 2;
        }

        public IMathTask Parse(string[] args)
        {
            TryParseToDigit(args[0], out int startIndex);
            IsPositiveNumber(startIndex);

            TryParseToDigit(args[1], out int endIndex);
            IsPositiveNumber(endIndex);

            return new FibonacciTask(startIndex, endIndex);
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