using ONPCalculator.Common.Elements.Operators;

namespace ONPCalculator.Common.Parsers
{
    public class MultiplyOperatorParser : BaseParser<MultiplyOperator>, IParser<MultiplyOperator>
    {
        public MultiplyOperatorParser() : base(1)
        {
        }
    }
}
