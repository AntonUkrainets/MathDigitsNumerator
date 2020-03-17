using System.Collections.Generic;
using DigitSequence.Business.Interfaces;
using DigitSequence.Model;
using DigitSequence.Operations;

namespace DigitSequence.Business.Implements
{
    public class SequenceGenerator : IOperationGenerator
    {
        public bool CanCalculate(IMathOperation operation)
        {
            return operation is SequenceOperation;
        }

        public int[] Calculate(IMathOperation operation)
        {
            var sequenceOperation = (SequenceOperation)operation;

            return Calculate(sequenceOperation);
        }

        private int[] Calculate(SequenceOperation operation)
        {
            var sequence = new List<int>();

            for (int i = 0; i * i < operation.End; i++)
            {
                sequence.Add(i);
            }

            return sequence.ToArray();
        }
    }
}