using System.Collections;
using UnityEngine;
using Lasm.OdinSerializer;
using System;
using Ludiq;
using Bolt;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

namespace Lasm.BoltExtensions
{
    /// <summary>
    /// The underlying type of the Binary Save system. This is the type that will be saved and loaded with all the data you assigned.
    /// </summary>
    [Serializable][RenamedFrom("Lasm.BoltExtensions.IO.BinarySave")][IncludeInSettings(true)][Inspectable]
    public sealed class BinarySave
    {
        /// <summary>
        /// All the save variables.
        /// </summary>
        [RenamedFrom("Lasm.BoltExtensions.IO.BinarySave.saves")]
        [Inspectable][InspectorWide]
        public Dictionary<string, object> variables = new Dictionary<string, object>();

        /// <summary>
        /// The amount of saved variables in this save.
        /// </summary>
        public int Count => variables.Count;

        /// <summary>
        /// Load a binary save from a given path.
        /// </summary>
        /// <param name="path"></param>
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

        /// <summary>
        /// Save a binary save to a file path.
        /// </summary>
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

        /// <summary>
        /// Deletes a file if it exists.
        /// </summary>
        public static void Delete(string path)
        {
            if (File.Exists(path)) File.Delete(path);
        }


        /// <summary>
        /// Get a variable from this Binary Save.
        /// </summary>
        public object Get(string name)
        {
            return variables[name];
        }

        /// <summary>
        /// Checks if this Binary Save has a variable.
        /// </summary>
        public bool Has(string name)
        {
            return variables.ContainsKey(name);
        }

        /// <summary>
        /// Removes a variable from the Binary Save.
        /// </summary>
        public void Remove(string name)
        {
            variables.Remove(name);
        }

        /// <summary>
        /// Sets a value of a Binary Save variable.
        /// </summary>
        public void Set(string name, object value)
        {
            if (variables.ContainsKey(name))
            {
                variables[name] = value;
            }
            else
            {
                variables.Add(name, value);
            }
        }
    }
}

