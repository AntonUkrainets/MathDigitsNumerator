using MathDigitsNumerator.Business.Interfaces;

namespace MathDigitsNumerator.Parser.Interfaces
{
    public interface IParser
    {
        bool CanParse(string[] args);
        IMathTask Parse(string[] args);
    }
}