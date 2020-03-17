using System;
using DigitSequence.Business.Interfaces;
using DigitSequence.Core;

namespace DigitSequence
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var env = new AppEnvironment();

            try
            {
                if (env.ShowHelpRequired(args))
                {
                    env.ShowHelp();
                    return;
                }

                var task = env.GetTask(args);

                IOperationResult operationResult = env.Calculate(task);

                env.LogResult(operationResult);
            }
            catch (Exception ex)
            {
                env.Logger.LogInformation(ex.Message);
            }
        }
    }
}