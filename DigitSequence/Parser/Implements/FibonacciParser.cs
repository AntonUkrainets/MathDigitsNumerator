using System;
using DigitSequence.Model;
using DigitSequence.Operations;
using DigitSequence.Parser.Interfaces;

namespace DigitSequence.Parser.Implements
{
    public class FibonacciParser : IParser
    {
        public bool CanParse(int countArgs)
        {
            return countArgs == 2;
        }

        public IMathOperation Parse(string[] args)
        {
            if (!int.TryParse(args[0], out int startIndex))
                throw new FormatException();

            if (!int.TryParse(args[1], out int endIndex))
                throw new FormatException();

            return new FibonacciOperation
            {
                Start = startIndex,
                End = endIndex
            };
        }
    }
}