using System;
using DigitSequence.Model;
using DigitSequence.Operations;
using DigitSequence.Parser.Interfaces;

namespace DigitSequence.Parser.Implements
{
    public class SequenceParser : IParser
    {
        public bool CanParse(int countArgs)
        {
            return countArgs == 1;
        }

        public IMathOperation Parse(string[] args)
        {
            if (!int.TryParse(args[0], out int endIndex))
                throw new FormatException();

            return new SequenceOperation
            {
                End = endIndex
            };
        }
    }
}