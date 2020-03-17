﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DigitSequence.Business.Interfaces;
using DigitSequence.Business.Operations;
using DigitSequence.Business.Operations.Fibonacci;
using DigitSequence.Business.Operations.Sequence;
using DigitSequence.Parser;
using DigitSequence.Parser.Interfaces;
using DigitSequence.Validation.Implements;
using Liba.Logger.Implements;
using Liba.Logger.Interfaces;

namespace DigitSequence.Core
{
    public class AppEnvironment
    {
        public ILogger Logger { get; }

        public IEnumerable<IParser> InputDataParsers { get; }

        public IEnumerable<IOperation> MathOperations { get; }

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

            Logger.LogInformation($"{stringBuilder}");
        }
    }
}