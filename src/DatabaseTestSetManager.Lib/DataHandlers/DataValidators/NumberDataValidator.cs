using System.Globalization;

namespace DatabaseTestSetManager.Lib.DataHandlers.DataValidators
{
    public class NumberDataValidator : IDataValidator
    {
        public bool Validate(string input)
        {
            double n;
            return input == null || double.TryParse(input, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out n);
        }

        public object Parse(string input)
        {
            if (input == null) return null;
            return double.Parse(input, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture);
        }
    }
}
