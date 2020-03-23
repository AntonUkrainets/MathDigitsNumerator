using System.Collections.Generic;
using DigitSequence.Business.Interfaces;

namespace DigitSequence.Business.Operations.Fibonacci
{
    public class FibonacciOperation : IOperation
    {
        public bool CanCalculate(IMathTask operation)
        {
            return operation is FibonacciTask;
        }

        public IOperationResult Calculate(IMathTask operation)
        {
            var fibonacciOperation = (FibonacciTask)operation;

            return CalculateFibonacci(fibonacciOperation);
        }

        private IOperationResult CalculateFibonacci(FibonacciTask operation)
        {
            var a = operation.Start;
            var b = 1;

            var numbersFibonacci = new List<int>();

            for (
                int index = operation.Start;
                a <= operation.End;
                index++
            ) 
            {
                numbersFibonacci.Add(a);

                var temp = a;
                a = b;
                b = temp + b;
            }

            return MathOperationResult.SetResult(numbersFibonacci.ToArray());
        }
    }
}