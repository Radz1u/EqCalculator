using ONPCalculator.Common.Evaluators;
using System;

namespace ONPCalculator.Common
{
    public abstract class BaseEvaluator<T> : IEvaluator<T> where T : BaseOperator
    {
        public Type OperatorType { get; }

        public BaseEvaluator()
        {
            this.OperatorType = typeof(T);
        }

        public abstract BaseElement Evaluate(BaseElement leftElement, BaseElement rightElement);
    }
}
