﻿namespace DigitSequence.Business.Interfaces
{
    public interface IOperation
    {
        bool CanCalculate(IMathTask task);
        IOperationResult Calculate(IMathTask task);
    }
}