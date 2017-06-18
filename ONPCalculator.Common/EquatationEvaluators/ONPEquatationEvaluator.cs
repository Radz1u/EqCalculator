using ONPCalculator.Common.Elements;
using ONPCalculator.Common.Evaluators;
using ONPCalculator.Common.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ONPCalculator.Common.EquatationEvaluators
{
    public class ONPEquatationEvaluator : BaseEquatationEvaluator<ONPEquatationInterpreterResult>
    {
        public ONPEquatationEvaluator(IEnumerable<IEvaluator<BaseOperator>> evaluators) : base(evaluators)
        {
        }

        public override string Evaluate(ONPEquatationInterpreterResult interpreterResult)
        {
            Stack<BaseElement> elements = new Stack<BaseElement>();

            var filter = new OperatorFilter(evaluators);

            while (interpreterResult.OnpNotation.Any())
            {
                var currentElement = interpreterResult.OnpNotation.Dequeue();

                if (currentElement is BaseNumber)
                {
                    elements.Push(currentElement);
                }
                else if (currentElement is BaseOperator)
                {
                    var rightNumber = (BaseNumber)elements.Pop();
                    var leftNumber = (BaseNumber)elements.Pop();
                    var evaluator = filter.FilterOperatorEvaluator(currentElement as BaseOperator);
                    var result = evaluator.Evaluate(leftNumber, rightNumber);
                    elements.Push(result);
                }
            }

            if (elements.Count > 1)
            {
                throw new InvalidOperationException("The result of computation should contains only one item");
            }

            return elements.Pop().Value;            
        }
    }
}
