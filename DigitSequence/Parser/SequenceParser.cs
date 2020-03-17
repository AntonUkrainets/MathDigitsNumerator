using System;
using DigitSequence.Business.Interfaces;
using DigitSequence.Business.Operations.Sequence;
using DigitSequence.Parser.Interfaces;

namespace DigitSequence.Parser
{
    public class SequenceParser : IParser
    {
        public bool CanParse(string[] args)
        {
            return args.Length == 1;
        }

        public IMathTask Parse(string[] args)
        {
            if (!int.TryParse(args[0], out int endIndex))
                throw new FormatException($"End index '{endIndex}' has incorrect format");

            return new SequenceTask(endIndex);
        }
    }
}