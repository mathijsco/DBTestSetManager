using System.Threading.Tasks;

namespace DatabaseTestSetManager.Lib.DataHandlers.DefaultDataProviders
{
    public class StaticDataProvider : IDefaultDataProvider
    {
        public string Value
        {
            get; set;
        }

        public string Generate()
        {
            return this.Value;
        }

        public Task<string> GenerateAsync()
        {
            return Task.FromResult(Generate());
        }
    }
}
