using System;
using System.Linq;
using System.Text;
using MathDigitsNumerator.Business.Interfaces;
using MathDigitsNumerator.Business.Operations;
using MathDigitsNumerator.Business.Operations.Fibonacci;
using MathDigitsNumerator.Business.Operations.Sequence;
using MathDigitsNumerator.Parser;
using MathDigitsNumerator.Parser.Interfaces;
using MathDigitsNumerator.Validation.Implements;
using Liba.Logger.Implements;
using Liba.Logger.Interfaces;

namespace MathDigitsNumerator.Core
{
    public class AppEnvironment
    {
        public ILogger Logger { get; }

        public IParser[] InputDataParsers { get; }

        public IOperation[] MathOperations { get; }

        public AppEnvironment(
            string logPath = "application.log"
        )
        {
            Logger = new AggregatedLogger
            (
                new FileLogger(logPath),
                new ConsoleLogger()
            );

            InputDataParsers = new IParser[]
            {
                new SequenceParser(),
                new FibonacciParser()
            };

            MathOperations = new IOperation[]
            {
                new FibonacciOperation(),
                new SequenceOperation()
            };
        }

        public bool ShowHelpRequired(string[] args)
        {
            return !Validator.IsArgumentValid(args);
        }

        public void ShowHelp()
        {
            Logger.LogInformation(
                $"Input must be like <SequenceNumber>;{Environment.NewLine}" +
                $"<FibonacciStartIndex> <FibonacciEndIndex>"
            );
        }

        public IMathTask GetTask(string[] args)
        {
            var inputDataParser = InputDataParsers
                .FirstOrDefault(p => p.CanParse(args));

            var task = inputDataParser.Parse(args);

            return task;
        }

        public IOperationResult Calculate(IMathTask task)
        {
            var operation = MathOperations
                .FirstOrDefault(o => o.CanCalculate(task));

            if (operation == null)
                return MathOperationResult.Error($"Operation '{task}' is not supported.");

            return operation.Calculate(task);
        }

        public void LogResult(IOperationResult operationResult)
        {
            if (!string.IsNullOrEmpty(operationResult.ErrorMessage))
            {
                Logger.LogInformation(operationResult.ErrorMessage);
                return;
            }

            var stringBuilder = new StringBuilder();

            foreach (var str in operationResult.Result)
            {
                stringBuilder.Append($"{str} ");
            }

            Logger.LogInformation(stringBuilder.ToString().Trim());
        }
    }
}