using DatabaseTestSetManager.Lib.Models;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseTestSetManager.Lib.Helpers
{
    public static class TypedVariableHelper
    {
        public static IList<TypedVariable> Merge(IList<TypedVariable> global, IList<TypedVariable> local)
        {
            // If one of the two lists are not set, return the global one.
            if (global == null || global.Count == 0 || local == null || local.Count == 0)
                return global ?? new TypedVariable[0];

            var mergedList = new List<TypedVariable>(global.Count);
            foreach (var item in global)
            {
                var localItem = local.FirstOrDefault(l => l.Key == item.Key);
                mergedList.Add(localItem ?? item);
            }
            return mergedList;
        }
    }
}
