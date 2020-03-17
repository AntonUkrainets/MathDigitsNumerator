using System.Collections.Generic;
using DigitSequence.Business.Interfaces;
using DigitSequence.Model;
using DigitSequence.Operations;

namespace DigitSequence.Business.Implements
{
    public class FibonacciGenerator : IOperationGenerator
    {
        public bool CanCalculate(IMathOperation operation)
        {
            return operation is FibonacciOperation;
        }

        public int[] Calculate(IMathOperation operation)
        {
            var fibonacciOperation = (FibonacciOperation)operation;

            return Calculate(fibonacciOperation);
        }

        private int[] Calculate(FibonacciOperation operation)
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

            return numbersFibonacci.ToArray();
        }
    }
}