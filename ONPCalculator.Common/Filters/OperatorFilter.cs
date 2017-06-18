using ONPCalculator.Common.Evaluators;
using System.Collections.Generic;
using System.Linq;

namespace ONPCalculator.Common.Filters
{
    public class OperatorFilter
    {
        private IEnumerable<IEvaluator<BaseOperator>> evaluators;

        public OperatorFilter(IEnumerable<IEvaluator<BaseOperator>> evaluators)
        {
            this.evaluators = evaluators;
        }

        public IEvaluator<BaseOperator> FilterOperatorEvaluator(BaseOperator baseOperator)
        {
            return this.evaluators.FirstOrDefault(x => x.OperatorType == baseOperator.GetType());
        }
    }
}
