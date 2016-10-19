using Newtonsoft.Json;
using System.IO;

namespace DatabaseTestSetManager.Win.IO
{
    public abstract class AssemblyConfigRepository<T> where T : AssemblyConfigRepository<T>, new()
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            //DefaultValueHandling = DefaultValueHandling.Ignore,
            TypeNameHandling = TypeNameHandling.Auto,
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            ContractResolver = new InternalContractResolver()
        };

        private static T _instance;
        private static readonly object SyncRoot = new object();

        /// <summary>
        /// Value indicating whether this settings has been loaded from file or is the default.
        /// </summary>
        public bool IsDefault { get; private set; }

        protected AssemblyConfigRepository()
        {
            this.IsDefault = true;
        }

        /// <summary>
        /// Loads the settings from the persistant storage.
        /// </summary>
        /// <returns>The loaded settings.</returns>
        public static T Load()
        {
            if (_instance != null)
                return _instance;

            T instance = null;
            lock (SyncRoot)
            {
                if (_instance != null)
                    return _instance;

                var path = GetPath();
                if (File.Exists(path))
                {
                    var text = File.ReadAllText(path);
                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        instance = JsonConvert.DeserializeObject<T>(text, Settings);
                        instance.IsDefault = false;
                    }
                }

                _instance = (instance = instance ?? new T());
            }

            return instance;
        }

        /// <summary>
        /// Unload the setting cache, to reload it from file with the Load() function.
        /// </summary>
        public static void Unload()
        {
            _instance = null;
        }

        private static string GetPath()
        {
            var fullPath = typeof(T).Assembly.Location;
            return Path.ChangeExtension(fullPath, "jconfig");
        }

        /// <summary>
        /// Saves the settings to a persistant storage.
        /// </summary>
        public void Save()
        {
            var serialized = JsonConvert.SerializeObject(this, Settings);

            var path = GetPath();
            if (File.Exists(path))
                File.Delete(path);
            File.WriteAllText(path, serialized);
            this.IsDefault = false;
        }
    }
}
