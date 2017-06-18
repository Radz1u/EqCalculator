using ONPCalculator.Common.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ONPCalculator.Common.EquatationInterpreters
{
    public abstract class BaseEquatationInterpreter<T>
    {
        protected IEnumerable<IParser<BaseElement>> parsers;

        public BaseEquatationInterpreter(IEnumerable<IParser<BaseElement>> parsers)
        {
            this.parsers = parsers;
        }

        public abstract T Interpret(string equatation);

        protected IEnumerable<string> SplitNumberAndOperators(string equatation)
        {
            var operatorParsers = parsers.Where(x => x is IParser<BaseOperator>);

            if (operatorParsers.Any())
            {
                var operatorParserSigns = operatorParsers.Select(x => ((BaseOperator)Activator.CreateInstance(x.ElementType)).Value);
                var operatorSigns = string.Join("", operatorParserSigns);

                return Regex.Split(equatation, $@"\s*([{operatorSigns}])\s*").Where(n => !string.IsNullOrEmpty(n));
            }

            return equatation.ToCharArray().Select(x => x.ToString());
        }
    }
}
