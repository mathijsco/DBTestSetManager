using System.Threading.Tasks;

namespace DatabaseTestSetManager.Lib.DataHandlers.DefaultDataProviders
{
    public interface IDefaultDataProvider
    {
        string Generate();

        Task<string> GenerateAsync();
    }
}
