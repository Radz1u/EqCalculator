using ONPCalculator.Common.Evaluators;
using System.Collections.Generic;

namespace ONPCalculator.Common
{
    public abstract class BaseEquatationEvaluator<T>
    {
        protected IEnumerable<IEvaluator<BaseOperator>> evaluators;

        public BaseEquatationEvaluator(IEnumerable<IEvaluator<BaseOperator>> evaluators)
        {
            this.evaluators = evaluators;
        }

        public abstract string Evaluate(T interpreterResult);
    }
}
