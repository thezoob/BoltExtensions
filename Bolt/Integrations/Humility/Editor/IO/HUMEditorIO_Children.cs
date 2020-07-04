using UnityEditor;
using UnityEngine;

namespace Lasm.BoltExtensions.Humility
{
    public static partial class HUMEditorIO_Children
    {
        /// <summary>
        /// Saves an asset at path. Optionally you can immediately refresh the database after saving.
        /// </summary>
        public static void Asset(this HUMIO.Data.Save saveData, string path, bool refresh = false)
        {
            if (saveData.value.GetType() == typeof(GameObject))
            {
                UnityEditor.PrefabUtility.SaveAsPrefabAsset(saveData.value as GameObject, path);
            }
            else
            {
                UnityEditor.AssetDatabase.CreateAsset(saveData.value as UnityEngine.Object, path);
            }

            if (refresh) saveData.And().Refresh();
        }

        /// <summary>
        /// Saves a new asset instance at path if it doesn't already exist. Optionally you can immediately refresh the database after saving.
        /// </summary>
        public static T Asset<T>(this HUMIO.Data.Ensure ensure, string filename, bool ensurePath = false, bool refresh = false)
            where T : ScriptableObject
        {
            if (ensurePath) ensure.Path();
            var asset = AssetDatabase.LoadAssetAtPath<T>(ensure.path + filename);
            if (asset == null)
            {
                asset = ScriptableObject.CreateInstance<T>();
                asset.Save().Asset(ensure.path.Remove().EndSlash() + "/" + filename, refresh);
            }
            return asset;
        }

        /// <summary>
        /// Saves and refreshes the asset database.
        /// </summary>
        public static void Refresh(this HUMIO.Data.And andData)
        {
            UnityEditor.AssetDatabase.SaveAssets();
            UnityEditor.AssetDatabase.Refresh();
        }

        /// <summary>
        /// Saves the file, and then saves and refreshes the asset database.
        /// </summary>
        public static void Refresh()
        {
            UnityEditor.AssetDatabase.SaveAssets();
            UnityEditor.AssetDatabase.Refresh();
        }
    }
}
