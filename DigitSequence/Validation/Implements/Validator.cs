using DigitSequence.Validation.Interfaces;

namespace DigitSequence.Validation.Implements
{
    public class Validator : IValidator
    {
        public bool IsArgumentValid(string[] args)
        {
            return (args.Length == 1) || (args.Length == 2);
        }
    }
}