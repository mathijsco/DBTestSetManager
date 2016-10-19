using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseTestSetManager.Lib.DataHandlers.DefaultDataProviders
{
    public class ListDataProvider : IDefaultDataProvider
    {
        private static readonly Random Random = new Random();

        public IList<string> Values { get; set; }

        public string Generate()
        {
            if (this.Values == null)
                return null;

            return this.Values[Random.Next(this.Values.Count)];
        }

        public Task<string> GenerateAsync()
        {
            return Task.FromResult(Generate());
        }
    }
}
