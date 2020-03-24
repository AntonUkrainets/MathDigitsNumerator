using System.Collections.Generic;

namespace MathDigitsNumerator.Business.Interfaces
{
    public interface IOperationResult
    {
        IEnumerable<int> Result { get; }
        string ErrorMessage { get; }
    }
}