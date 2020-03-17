using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DigitSequence.Business.Implements;
using DigitSequence.Business.Interfaces;
using DigitSequence.Parser.Implements;
using DigitSequence.Parser.Interfaces;
using DigitSequence.Validation.Implements;
using Liba.Logger.Implements;
using Liba.Logger.Interfaces;

namespace DigitSequence
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logPath = "application.log";

            ILogger logger = new AggregatedLogger
            (
                new FileLogger(logPath),
                new ConsoleLogger()
            );

            try
            {
                var validator = new Validator();
                if (!validator.IsArgumentValid(args))
                {
                    logger.LogInformation(
                        $"Input must be like <SequenceNumber>;{Environment.NewLine}" +
                        $"<FibonacciStartIndex> <FibonacciEndIndex>");

                    return;
                }

                IEnumerable<IParser> inputDataParsers = new List<IParser>
                {
                    new SequenceParser(),
                    new FibonacciParser()
                };

                var inputDataParser = inputDataParsers
                        .FirstOrDefault(p => p.CanParse(args.Length));

                var operation = inputDataParser.Parse(args);

                var operationNumerators = new List<IOperationGenerator>
                {
                    new FibonacciGenerator(),
                    new SequenceGenerator()
                };

                var operationNumerator = operationNumerators
                        .FirstOrDefault(o => o.CanCalculate(operation));

                if (operationNumerator == null)
                    throw new NotSupportedException($"Operation '{operation}' is not supported.");

                var result = operationNumerator.Calculate(operation);

                StringBuilder stringBuilder = new StringBuilder();

                foreach (var str in result)
                {
                    stringBuilder.Append($"{res} ");
                }

                logger.LogInformation($"{stringBuilder}");
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
            }
        }
    }
}