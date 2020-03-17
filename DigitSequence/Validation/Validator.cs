namespace DigitSequence.Validation.Implements
{
    public static class Validator
    {
        public static bool IsArgumentValid(string[] args)
        {
            return (args.Length == 1) || (args.Length == 2);
        }
    }
}