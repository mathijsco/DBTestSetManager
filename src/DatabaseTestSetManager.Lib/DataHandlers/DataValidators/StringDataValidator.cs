namespace DatabaseTestSetManager.Lib.DataHandlers.DataValidators
{
    public class StringDataValidator : IDataValidator
    {
        public bool Validate(string input)
        {
            return true;
        }

        public object Parse(string input)
        {
            return input;
        }
    }
}
