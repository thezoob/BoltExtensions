using System;
using System.IO;
using UnityEngine;

namespace Lasm.BoltExtensions.Humility
{
    public static partial class HUMIO
    {
        /// <summary>
        /// Quick building of a file path, based on the persistant data path.
        /// </summary>
        internal static string PersistantPath(string fileName)
        {
            return Application.persistentDataPath + "/data/" + fileName;
        }

        /// <summary>
        /// Quick building of a path, based on the persistant data path.
        /// </summary>
        public static string PersistantPath()
        {
            return Application.persistentDataPath + "/data/";
        }

        /// <summary>
        /// Starts the saving operation of this value.
        /// </summary>
        public static Data.Save Save(this object value)
        {
            return new Data.Save(value);
        }

        /// <summary>
        /// Starts a loading process.
        /// </summary>
        public static Data.Load Load()
        {
            return new Data.Load();
        }

        public static Data.Remove Remove(this string path)
        {
            return new Data.Remove(path);
        }

#if UNITY_EDITOR
        /// <summary>
        /// Searches for a filename in the editor project, and returns its path.
        /// </summary>
        public static string PathOf(string fileName)
        {
            var files = UnityEditor.AssetDatabase.FindAssets(fileName);
            if (files.Length == 0) return string.Empty;
            var assetPath = UnityEditor.AssetDatabase.GUIDToAssetPath(files[0]).Replace(fileName, string.Empty);
            return assetPath;
        }
#endif

        /// <summary>
        /// Deletes a folder.
        /// </summary>
        public static void Delete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// Begins a Copy operation.
        /// </summary>
        public static Data.Copy Copy()
        {
            return new Data.Copy();
        }

        /// <summary>
        /// Begins an operation to ensure the path has, is, or does something.
        /// </summary>
        public static Data.Ensure Ensure(this string path)
        {
            return new Data.Ensure(path);
        }
    }
}
