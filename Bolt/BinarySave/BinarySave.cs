using System.Collections;
using UnityEngine;
using Lasm.OdinSerializer;
using System;
using Ludiq;
using Bolt;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

namespace Lasm.BoltExtensions.IO
{
    [Serializable]
    public class BinarySave
    {
        public Dictionary<string, object> saves = new Dictionary<string, object>();
        public int Count => saves.Count;

        public static BinarySave Load(string path)
        {
            if (File.Exists(path))
            {
                using (var fileStream = new FileStream(path, FileMode.Open))
                {
                    return SerializationUtility.DeserializeValue<BinarySave>(SerializationUtility.CreateReader(fileStream, new DeserializationContext(), DataFormat.Binary));
                }
            }

            return null;
        }

        public static void Save(string path, BinarySave binary)
        {
            string filelessPath = string.Empty;

            if (path.Contains("/")) {
                filelessPath = path.Remove(path.LastIndexOf("/"));
            }
            else
            {
                filelessPath = path.Remove(path.LastIndexOf(@"\"));
            }

            if (!Directory.Exists(filelessPath)) Directory.CreateDirectory(filelessPath);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                SerializationUtility.SerializeValue<BinarySave>(binary, SerializationUtility.CreateWriter(fileStream, new SerializationContext(), DataFormat.Binary));
            }
        }

        public static void Delete(string path)
        {
            File.Delete(path);
        }

        public object Get(string name)
        {
            return saves[name];
        }

        public bool Has(string name)
        {
            return saves.ContainsKey(name);
        }

        public void Remove(string name)
        {
            saves.Remove(name);
        }

        public void Set(string name, object value)
        {
            if (saves.ContainsKey(name))
            {
                saves[name] = value;
            }
            else
            {
                saves.Add(name, value);
            }
        }
    }
}

