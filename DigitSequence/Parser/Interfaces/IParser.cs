using DigitSequence.Model;

namespace DigitSequence.Parser.Interfaces
{
    public interface IParser
    {
        bool CanParse(int countArgs);
        IMathOperation Parse(string[] args);
    }
}