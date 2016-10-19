using System;

namespace DatabaseTestSetManager.Lib.DataHandlers.DataValidators
{
    public class TimeSpanDataValidator : IDataValidator
    {
        public bool Validate(string input)
        {
            TimeSpan n;
            return input == null || TimeSpan.TryParse(input, out n);
        }

        public object Parse(string input)
        {
            if (input == null) return null;
            return TimeSpan.Parse(input);
        }
    }
}
