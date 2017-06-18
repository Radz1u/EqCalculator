using ONPCalculator.Common.Elements.Operators;

namespace ONPCalculator.Common.Parsers
{
    public class DivideByOperatorParser : BaseParser<DivideByOperator>, IParser<DivideByOperator>
    {
        public DivideByOperatorParser() : base(1)
        {
        }
    }
}
