using Lasm.OdinSerializer;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Lasm.BoltExtensions.Humility
{
    public static partial class HUMIO_Children
    {
        /// <summary>
        /// When saving, also do an accompanied action.
        /// </summary>
        public static HUMIO.Data.And And(this HUMIO.Data.Save saveData)
        {
            return new HUMIO.Data.And();
        }

        public static string EndSlash(this HUMIO.Data.Remove remove)
        {
            var lastIndexString = remove.path[remove.path.Length - 1].ToString();

            return (lastIndexString == "/" || lastIndexString == @"\") ? remove.path.Remove(remove.path.Length - 1, 1) : remove.path;
        }

        /// <summary>
        /// Sets the save to be in the persistant data path.
        /// </summary>
        public static HUMIO.Data.Persistant Persistant(this HUMIO.Data.Save saveData, string fileName)
        {
            var path = HUMIO.PersistantPath();

            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            return new HUMIO.Data.Persistant(path, saveData, new HUMIO.Data.Load());
        }

        /// <summary>
        /// Sets the save to be in a custom folder.
        /// </summary>
        public static HUMIO.Data.Custom Custom(this HUMIO.Data.Save saveData, string filePath, string fileName)
        {
            if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);

            return new HUMIO.Data.Custom(filePath + fileName, saveData, new HUMIO.Data.Load());
        }


        /// <summary>
        /// Deletes a file in the persistant data path.
        /// </summary>
        public static void Persistant(this HUMIO.Data.Delete deleteData, string fileName)
        {
            var path = HUMIO.PersistantPath(fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// Deletes a file in a custom folder.
        /// </summary>
        public static void Custom(this HUMIO.Data.Delete deleteData, string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        /// <summary>
        /// Copies a file from the persistant data path, into the persistant data path, with a new file name;
        /// </summary>
        public static void Persistant(this HUMIO.Data.Copy copyData, string fileName, string newFileName)
        {
            var path = HUMIO.PersistantPath(fileName);
            var newPath = HUMIO.PersistantPath(newFileName);

            if (File.Exists(path))
            {
                File.Copy(path, newPath);
            }
        }

        /// <summary>
        /// Copies a file from a custom folder, into another custom folder.
        /// </summary>
        public static void Custom(this HUMIO.Data.Copy copyData, string filePath, string newFilePath)
        {
            if (File.Exists(filePath))
            {
                File.Copy(filePath, newFilePath);
            }
        }

        /// <summary>
        /// Sets the save type as being a Binary Encrypted file.
        /// </summary>
        public static void Encrypted(this HUMIO.Data.Persistant persistantData)
        {
            using (var fileStream = new FileStream(persistantData.path, FileMode.Create))
            {
                SerializationUtility.SerializeValue<object>(persistantData.save.value, SerializationUtility.CreateWriter(fileStream, new SerializationContext(), DataFormat.Binary));
            }
        }

        /// <summary>
        /// Saves a text file to the persistant data path.
        /// </summary>
        public static void Text(this HUMIO.Data.Persistant persistantData)
        {
            using (var fileStream = new FileStream(persistantData.path, FileMode.Create))
            {
                StreamWriter writer = new StreamWriter(fileStream);
                writer.Write(persistantData.save.value.ToString());
            }
        }

        /// <summary>
        /// Saves a text file to a custom folder. If we are in the editor, the editor will attempt a save and refresh.
        /// </summary>
        public static void Text(this HUMIO.Data.Custom customData)
        {
            using (var fileStream = new FileStream(customData.path, FileMode.Create))
            {
                StreamWriter writer = new StreamWriter(fileStream);
                writer.Write(customData.save.value.ToString());
                writer.Close();
            }

#if UNITY_EDITOR
            UnityEditor.AssetDatabase.SaveAssets();
            UnityEditor.AssetDatabase.Refresh();
#endif
        }

        /// <summary>
        /// Ensures this path will exist if it does not already.
        /// </summary>
        public static void Path(this HUMIO.Data.Ensure ensure)
        {
            var legalPath = !ensure.path.Contains(".") ? ensure.path : ensure.path.Remove(ensure.path.LastIndexOf("/") + 1, (ensure.path.Length - 1) - ensure.path.LastIndexOf("/"));

            if (!Directory.Exists(legalPath))
            {
                Directory.CreateDirectory(legalPath);
            }
        }

        /// <summary>
        /// Begins the operation of deleting a file or folder.
        /// </summary>
        public static HUMIO.Data.Delete Delete()
        {
            return new HUMIO.Data.Delete();
        }
    }
}
