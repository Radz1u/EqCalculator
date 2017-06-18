using System;

namespace ONPCalculator.Common.Parsers
{
    public interface IParser<out T> where T:BaseElement
    {
        Type ElementType { get; }

        int Priority { get; }

        T Parse(string input);
    }
}
