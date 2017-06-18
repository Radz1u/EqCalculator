using ONPCalculator.Common;
using ONPCalculator.Common.Elements.Operators;
using ONPCalculator.Common.EquatationEvaluators;
using ONPCalculator.Common.EquatationInterpreters;
using ONPCalculator.Common.Evaluators;
using ONPCalculator.Common.Parsers;
using System;
using System.Collections.Generic;

namespace ONPCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var interpreter = new ONPEquatationInterpreter(ConfigureParsers());
            var interpreterResults = interpreter.Interpret(input);
            var evaluator = new ONPEquatationEvaluator(ConfigureEvaluators());
            var result = evaluator.Evaluate(interpreterResults);

            Console.WriteLine(result.ToString());
            Console.ReadLine();
            Console.ReadLine();
        }

        private static IEnumerable<IEvaluator<BaseOperator>> ConfigureEvaluators()
        {
            return new List<IEvaluator<BaseOperator>>
            {
                new AddOperatorEvaluator(),
                new SubstractOperatorEvaluator(),
                new MultiplyOperatorEvaluator(),
                new DivideByOperatorEvaluator()
            };
        }

        private static IEnumerable<IParser<BaseElement>> ConfigureParsers()
        {
            return new List<IParser<BaseElement>>()
            {
                new AddOperatorParser(),
                new DivideByOperatorParser(),
                new IntegerNumberParser(),
                new MultiplyOperatorParser(),
                new SubstractOperatorParser()
            };
        }
    }
}
