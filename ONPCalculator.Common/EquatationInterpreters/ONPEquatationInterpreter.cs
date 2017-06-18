using ONPCalculator.Common.Elements;
using ONPCalculator.Common.Elements.Operators;
using ONPCalculator.Common.Filters;
using ONPCalculator.Common.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ONPCalculator.Common.EquatationInterpreters
{
    /// <summary>
    /// ONP interpreter using Edsgar Dijkstra algorithm
    /// </summary>
    public class ONPEquatationInterpreter : BaseEquatationInterpreter<ONPEquatationInterpreterResult>
    {
        public ONPEquatationInterpreter(IEnumerable<IParser<BaseElement>> parsers):base(parsers)
        {
        }

        public override ONPEquatationInterpreterResult Interpret(string equatation)
        {
            Stack<BaseOperator> operators = new Stack<BaseOperator>();
            Queue<BaseElement> output = new Queue<BaseElement>();

            var splittedEquatation = this.SplitNumberAndOperators(equatation);

            foreach (var element in splittedEquatation)
            { 
                var equatationElement =parsers.OrderByDescending(x => x.Priority)
                    .Select(x => x.Parse(element.ToString()))
                    .Where(x => x != null)
                    .FirstOrDefault();

                if (equatationElement == null)
                {
                    throw new NotImplementedException("The element is null");
                }
                else if (equatationElement is BaseNumber)
                {
                    output.Enqueue(equatationElement);
                }
                else if (equatationElement is BaseOperator)
                {
                    var currentOperator = equatationElement as BaseOperator;

                    if (operators.Any())
                    {
                        BaseOperator topOperator = operators.Peek();

                        bool hasLowerPriority = true;
                        while (hasLowerPriority)
                        {
                            if (topOperator == null)
                            {
                                break;
                            }

                            hasLowerPriority = ((currentOperator.Associativity == Associativity.Left && topOperator.Priority >= currentOperator.Priority)
                                                || (topOperator.Associativity == Associativity.Right && topOperator.Priority > currentOperator.Priority));

                            if (hasLowerPriority)
                            {
                                output.Enqueue(operators.Pop());
                            }

                            topOperator = operators.Any() ? operators.Peek() : null;
                        }
                    }

                    operators.Push(currentOperator);
                }
                else
                {
                    throw new NotImplementedException("The element is not supported");
                }
            }

            while (operators.Any())
            {
                output.Enqueue(operators.Pop());
            }

            return new ONPEquatationInterpreterResult() { OnpNotation = output };
        }
    }
}
