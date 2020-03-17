using DigitSequence.Model;

namespace DigitSequence.Validation.Interfaces
{
    public interface IValidator
    {
        bool IsArgumentValid(string[] args);
    }
}