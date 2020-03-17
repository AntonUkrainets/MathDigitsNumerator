using DigitSequence.Business.Interfaces;

namespace DigitSequence.Parser.Interfaces
{
    public interface IParser
    {
        bool CanParse(string[] args);
        IMathTask Parse(string[] args);
    }
}