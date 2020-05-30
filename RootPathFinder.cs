#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Lasm
{
    public class RootPathFinder
    {
        private static string _rootPath;
        public static string rootPath
        {
            get
            {
                if (_rootPath == null) _rootPath = FindRootPath();
                return _rootPath;
            }
        }

        public static string FindRootPath()
        {
            var files = AssetDatabase.FindAssets("lasm_root_folder");
            var guid = AssetDatabase.GUIDToAssetPath(files[0]).Replace("lasm_root_folder", string.Empty);
            return guid;
        }
    }
}
#endif