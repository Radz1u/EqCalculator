using ONPCalculator.Common.Elements;
using System;
using System.Linq;

namespace ONPCalculator.Common.Parsers
{
    public class IntegerNumberParser : BaseParser<IntegerNumber>, IParser<IntegerNumber>
    {
        public IntegerNumberParser() : base(1)
        {
        }

        public override IntegerNumber Parse(string input)
        {
            if (IsCorrectValue(null, input))
            {
                var numberValue = Convert.ToInt32(input);
                return (IntegerNumber)Activator.CreateInstance(typeof(IntegerNumber), numberValue);
            }
            else
            {
                return null;
            }
        }

        protected override bool IsCorrectValue(IntegerNumber element, string input)
        {
            return input.All(x => char.IsDigit(x));
        }
    }
}
