using System.Collections.Generic;
using MathDigitsNumerator.Business.Interfaces;

namespace MathDigitsNumerator.Business.Operations
{
    public class MathOperationResult : IOperationResult
    {
        public IEnumerable<int> Result { get; }

        public string ErrorMessage { get; }

        private MathOperationResult(int[] result)
        {
            Result = result;
        }

        private MathOperationResult(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public static MathOperationResult SetResult(int[] result)
        {
            return new MathOperationResult(result);
        }

        public static MathOperationResult Error(string errorMessage)
        {
            return new MathOperationResult(errorMessage);
        }
    }
}