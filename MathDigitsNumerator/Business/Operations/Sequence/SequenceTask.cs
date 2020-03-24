using MathDigitsNumerator.Business.Interfaces;

namespace MathDigitsNumerator.Business.Operations.Sequence
{
    public class SequenceTask : IMathTask
    {
        public int End { get; }

        public SequenceTask(int end)
        {
            End = end;
        }
    }
}