namespace DigitSequence.Business.Interfaces
{
    public interface IOperationResult
    {
        int[] Result { get; }
        string ErrorMessage { get; }
    }
}