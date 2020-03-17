using DigitSequence.Business.Interfaces;

namespace DigitSequence.Business.Operations.Fibonacci
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