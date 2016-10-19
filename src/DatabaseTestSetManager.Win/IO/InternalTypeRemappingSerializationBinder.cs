using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DatabaseTestSetManager.Win.IO
{
    public class InternalTypeRemappingSerializationBinder : SerializationBinder
    {
        private readonly Dictionary<Type, string> typeToName = new Dictionary<Type, string>();
        private readonly Dictionary<string, Type> nameToType = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);

        public void Map(Type type, string name)
        {
            this.typeToName.Add(type, name);
            this.nameToType.Add(name, type);

            this.typeToName.Add(typeof(List<>).MakeGenericType(type), name + ".List");
            this.nameToType.Add(name + ".List", typeof(List<>).MakeGenericType(type));
        }

        public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            string name;
            if (typeToName.TryGetValue(serializedType, out name))
            {
                assemblyName = null;
                typeName = name;
            }
            else
            {
                assemblyName = serializedType.Assembly.FullName;
                typeName = serializedType.FullName;
            }
        }

        public override Type BindToType(string assemblyName, string typeName)
        {
            if (assemblyName == null)
            {
                Type type;
                if (this.nameToType.TryGetValue(typeName, out type))
                    return type;
            }
            return Type.GetType(string.Format("{0}, {1}", typeName, assemblyName), true);
        }
    }
}
