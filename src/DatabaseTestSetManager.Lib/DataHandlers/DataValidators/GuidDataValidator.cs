using System;

namespace DatabaseTestSetManager.Lib.DataHandlers.DataValidators
{
    public class GuidDataValidator : IDataValidator
    {
        public bool Validate(string input)
        {
            Guid n;
            return input == null || Guid.TryParse(input, out n);
        }

        public object Parse(string input)
        {
            if (input == null) return null;
            return Guid.Parse(input);
        }
    }
}
