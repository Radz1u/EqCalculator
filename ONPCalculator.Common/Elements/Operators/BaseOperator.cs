using ONPCalculator.Common.Elements.Operators;

namespace ONPCalculator.Common
{
    public class BaseOperator : BaseElement
    {
        public Associativity Associativity { get; }

        public int Priority { get; }

        public BaseOperator(string sign, int priority, Associativity associativity = Associativity.Left) : base(sign)
        {
            this.Priority = priority;
            this.Associativity = associativity;
        }
    }
}
