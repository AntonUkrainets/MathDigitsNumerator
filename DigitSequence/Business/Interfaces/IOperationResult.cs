namespace DigitSequence.Business.Interfaces
{
    public interface IOperationResult
    {//IEnumerable
        int[] Result { get; }
        string ErrorMessage { get; }
    }
}