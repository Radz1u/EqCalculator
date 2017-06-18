using System;

namespace ONPCalculator.Common.Elements
{
    public class BaseNumber : BaseElement
    {
        protected double numberValue;

        public double NumberValue => numberValue;

        public BaseNumber(double number):this(number.ToString())
        {
            numberValue = number;
        }

        public BaseNumber(string input) : base(input)
        {
            numberValue = Convert.ToDouble(input);
        }
    }
}
