using System;

namespace DatabaseTestSetManager.Lib.DataHandlers.DataValidators
{
    public class DateTimeOffsetDataValidator : IDataValidator
    {
        public bool Validate(string input)
        {
            DateTimeOffset n;
            return input == null || DateTimeOffset.TryParse(input, out n);
        }

        public object Parse(string input)
        {
            if (input == null) return null;
            return DateTimeOffset.Parse(input);
        }
    }
}
