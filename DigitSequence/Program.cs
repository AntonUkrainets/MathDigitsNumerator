﻿using System;
using DigitSequence.Business.Interfaces;
using DigitSequence.Core;

namespace DigitSequence
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var environment = new AppEnvironment();

            try
            { 
                if (environment.ShowHelpRequired(args))
                {
                    environment.ShowHelp();
                    return;
                }

                var task = environment.GetTask(args);

                IOperationResult operationResult = environment.Calculate(task);

                environment.LogResult(operationResult);
            }
            catch (Exception ex)
            {
                environment.Logger.LogInformation(ex.Message);
            }
        }
    }
}