using System;

namespace ONPCalculator.Common.Evaluators
{
    public interface IEvaluator<out T> where T: BaseOperator
    {
        Type OperatorType { get; }

        BaseElement Evaluate(BaseElement leftElement, BaseElement rightElement);
    }
}
