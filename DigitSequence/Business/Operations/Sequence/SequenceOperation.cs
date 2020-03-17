using System.Collections.Generic;
using DigitSequence.Business.Interfaces;

namespace DigitSequence.Business.Operations.Sequence
{
    public class SequenceOperation : IOperation
    {
        public bool CanCalculate(IMathTask operation)
        {
            return operation is SequenceTask;
        }

        public IOperationResult Calculate(IMathTask operation)
        {
            var sequenceOperation = (SequenceTask)operation;

            return Calculate(sequenceOperation);
        }

        private IOperationResult Calculate(SequenceTask operation)
        {
            var sequence = new List<int>();

            for (int i = 0; i * i < operation.End; i++)
            {
                sequence.Add(i);
            }

            return MathOperationResult.SetResult(sequence.ToArray());
        }
    }
}