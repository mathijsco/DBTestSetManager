namespace DatabaseTestSetManager.Lib.DataHandlers.DataValidators
{
    public interface IDataValidator
    {
        bool Validate(string input);

        object Parse(string input);
    }
}
