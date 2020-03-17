using DigitSequence.Model;

namespace DigitSequence.Business.Interfaces
{
    public interface IOperationGenerator
    {
        bool CanCalculate(IMathOperation operation);
        int[] Calculate(IMathOperation operation);
    }
}