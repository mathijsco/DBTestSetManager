using DatabaseTestSetManager.Lib.DataHandlers.DefaultDataProviders;
using DatabaseTestSetManager.Lib.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DatabaseTestSetManager.Win.IO
{
    internal class SavedFileRepository
    {
        private static InternalTypeRemappingSerializationBinder _serializationBinder;

        public FullTestSet Load(string path)
        {
            var jsonRaw = File.ReadAllText(path);
            var loadedFile = Deserialize(jsonRaw);

            if (loadedFile.Whiteboard != null)
                ApplicationState.Instance.Whiteboard = loadedFile.Whiteboard;
            else
                ApplicationState.Instance.Whiteboard.Clear();

            return loadedFile;
        }

        public void Save(string path, IList<TableSet> set)
        {
            var jsonRaw = Serialize(new FullTestSet
            {
                Whiteboard = ApplicationState.Instance.Whiteboard,
                Sets = set
            });

            if (File.Exists(path))
                File.Delete(path);
            File.WriteAllText(path, jsonRaw);
        }

        public FullTestSet Clone(FullTestSet fullDefinition)
        {
            var json = Serialize(fullDefinition);
            return Deserialize(json);
        }

        private string Serialize(FullTestSet fullDefinition)
        {
            LoadBinder();
            return JsonConvert.SerializeObject(fullDefinition, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                Binder = _serializationBinder,
                Converters = new List<JsonConverter>
                {
                    new StringEnumConverter()
                }
            });
        }

        private FullTestSet Deserialize(string jsonRaw)
        {
            LoadBinder();
            return JsonConvert.DeserializeObject<FullTestSet>(jsonRaw, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore,
                Binder = _serializationBinder,
                Converters = new List<JsonConverter>
                {
                    new StringEnumConverter()
                }
            });
        }

        private static void LoadBinder()
        {
            if (_serializationBinder != null) return;

            _serializationBinder = new InternalTypeRemappingSerializationBinder();

            var sampleType = typeof(FullTestSet);
            foreach (var type in sampleType.Assembly.GetExportedTypes().Where(t => t.Namespace == sampleType.Namespace))
                _serializationBinder.Map(type, type.Name);

            sampleType = typeof(IDefaultDataProvider);
            foreach (var type in sampleType.Assembly.GetExportedTypes().Where(t => t.Namespace == sampleType.Namespace))
                _serializationBinder.Map(type, type.Name);
        }
    }
}
