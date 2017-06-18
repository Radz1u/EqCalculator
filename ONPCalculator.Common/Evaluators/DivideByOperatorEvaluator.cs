using ONPCalculator.Common.Elements;
using ONPCalculator.Common.Elements.Operators;
using System;

namespace ONPCalculator.Common.Evaluators
{
    public class DivideByOperatorEvaluator : BaseEvaluator<DivideByOperator>
    {
        public override BaseElement Evaluate(BaseElement leftElement, BaseElement rightElement)
        {
            if (leftElement is BaseNumber && rightElement is BaseNumber)
            {
                var leftNumber = leftElement as BaseNumber;
                var rightNumber = rightElement as BaseNumber;

                var result = leftNumber.NumberValue / rightNumber.NumberValue;

                return new BaseNumber(result);
            }
            else
            {
                throw new NotImplementedException($"There is no implementation for this type of element");
            }
        }
    }
}
