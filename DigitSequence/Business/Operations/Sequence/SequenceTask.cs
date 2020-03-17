using DigitSequence.Business.Interfaces;

namespace DigitSequence.Business.Operations.Sequence
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