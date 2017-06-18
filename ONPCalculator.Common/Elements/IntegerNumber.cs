namespace ONPCalculator.Common.Elements
{
    public class IntegerNumber : BaseNumber
    {
        public new int NumberValue => (int)numberValue;

        public IntegerNumber() : base(default(int).ToString())
        {

        }

        public IntegerNumber(int numberValue) : base(numberValue.ToString())
        {
        }
    }
}
