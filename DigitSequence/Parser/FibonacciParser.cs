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
            if (!int.TryParse(args[0], out int startIndex))
                throw new FormatException($"Start index '{startIndex}' has incorrect format");

            if (!int.TryParse(args[1], out int endIndex))
                throw new FormatException($"End index '{endIndex}' has incorrect format");

            return new FibonacciTask(startIndex, endIndex);
        }
    }
}