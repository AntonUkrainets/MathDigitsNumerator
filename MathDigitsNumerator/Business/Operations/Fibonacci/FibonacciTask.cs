using MathDigitsNumerator.Business.Interfaces;

namespace MathDigitsNumerator.Business.Operations.Fibonacci
{
    public class FibonacciTask : IMathTask
    {
        public int Start { get; }
        public int End { get; }

        public FibonacciTask(int start, int end)
        {
            Start = start;
            End = end;
        }
    }
}