using System;

namespace ONPCalculator.Common.Parsers
{
    public class BaseParser<T>: IParser<T> where T : BaseElement
    {
        public Type ElementType { get; }

        public int Priority { get; }

        public BaseParser(int priority)
        {
            Priority = priority;
            ElementType = typeof(T);
        }

        protected virtual bool IsCorrectValue(T element, string input)
        {
            return element.Value.Equals(input, StringComparison.InvariantCultureIgnoreCase);
        }

        public virtual T Parse(string input)
        {
            var element = (T)Activator.CreateInstance(typeof(T));

            if (IsCorrectValue(element, input))
            {
                return element;
            }

            return null;
        }
    }
}
