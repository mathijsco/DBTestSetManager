using DatabaseTestSetManager.Lib.Models;
using System.Collections.Generic;

namespace DatabaseTestSetManager.Lib.DataHandlers.DataValidators
{
    public static class DataValidatorFactory
    {
        private static readonly IDictionary<FieldType, IDataValidator> LookupDictionary = 
            new Dictionary<FieldType, IDataValidator>()
            {
                { FieldType.String, new StringDataValidator() },
                { FieldType.Number, new NumberDataValidator() },
                { FieldType.DataTimeOffset, new DateTimeOffsetDataValidator() },
                { FieldType.TimeSpan, new TimeSpanDataValidator() },
                { FieldType.Guid, new GuidDataValidator() },
                { FieldType.Raw, new StringDataValidator() }
            };

        public static IDataValidator Create(FieldType fieldType)
        {
            IDataValidator result;
            LookupDictionary.TryGetValue(fieldType, out result);
            return result;
        }
    }
}
