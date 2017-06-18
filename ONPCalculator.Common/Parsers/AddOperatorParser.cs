using ONPCalculator.Common.Elements.Operators;

namespace ONPCalculator.Common.Parsers
{
    public class AddOperatorParser : BaseParser<AddOperator>, IParser<AddOperator>
    {
        public AddOperatorParser() : this(1)
        {
        }

        public AddOperatorParser(int i) : base(i)
        {

        }
    }
}
