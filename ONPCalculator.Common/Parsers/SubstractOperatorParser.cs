using ONPCalculator.Common.Elements.Operators;

namespace ONPCalculator.Common.Parsers
{
    public class SubstractOperatorParser : BaseParser<SubstractOperator>, IParser<SubstractOperator>
    {
        public SubstractOperatorParser() : base(1)
        {
        }
    }
}
