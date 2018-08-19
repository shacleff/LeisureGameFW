using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;


public class AssetBundleHelper :Editor
{
    /// <summary>
    /// 自动设置该文件夹所有资源的AssetBunldName。 
    /// </summary>
    [MenuItem("AssetBundles/AssetBundleHelper/SetAssetbundleName")]
	public static void SetAssetBundleName()
    {
        Object[] selectAssets = Selection.GetFiltered(typeof(Object), SelectionMode.Assets | SelectionMode.ExcludePrefab);
        string[] FileSuffixName = new string[] {".prefab",".mat",".shader",".jpg",".png",".dds" };
        if (selectAssets.Length != 1) return;
        string fullPath = AssetBundleConfig.PROJECT_PATH+AssetDatabase.GetAssetPath(selectAssets[0]);
        AssetImporter _assetImporter=null;
        if (Directory.Exists(fullPath))
        {
            DirectoryInfo DirInfos = new DirectoryInfo(fullPath);
            FileInfo[] fileInfos = DirInfos.GetFiles("*", System.IO.SearchOption.AllDirectories);
            for (int i = 0; i < fileInfos.Length; i++)
            {
                var _fileInfo = fileInfos[i];
                for (int j = 0; j < FileSuffixName.Length; j++)
                {
                    string _suffixName = FileSuffixName[j];
                    if(_fileInfo.Name.EndsWith(FileSuffixName[j]))
                    {
                        string _path = _fileInfo.FullName.Replace("\\", "/").Substring(AssetBundleConfig.PROJECT_PATH.Length);
                        _assetImporter = AssetImporter.GetAtPath(_path);
                        if(_assetImporter!=null)
                        {
                            string _assetbundleName = _path.Substring(fullPath.Substring(AssetBundleConfig.PROJECT_PATH.Length).Length + 1);
                            _assetImporter.assetBundleName = _assetbundleName.Substring(0,_assetbundleName.LastIndexOf('.'))+AssetBundleConfig.SUFFIX;
                        }
                    }
                }
                
            }
            AssetDatabase.RemoveUnusedAssetBundleNames();
        }

    }

    /// <summary>
    /// 控制台输出所有设置过AssetBundleName的资源的Name。 
    /// </summary>
    [MenuItem("AssetBundles/AssetBundleHelper/GetAllBundleNames")]
    public static void GetAllAssetBundleNames()
    {
        string[] _allAssetBundleNames = AssetDatabase.GetAllAssetBundleNames();
        for (int i = 0; i < _allAssetBundleNames.Length; i++)
        {
            Debug.Log(_allAssetBundleNames[i]);
        }
    }

    /// <summary>
    /// 清除该文件夹所有资源的AssetBunldName。 
    /// </summary>
    [MenuItem("AssetBundles/AssetBundleHelper/ClearAssetBundleName")]
    public static void ClearAssetBundleName()
    {
        Object[] selectAssets = Selection.GetFiltered(typeof(Object), SelectionMode.Assets | SelectionMode.ExcludePrefab);
        string[] FileSuffixName = new string[] { ".prefab", ".mat", ".shader", ".jpg", ".png", ".dds" };
        if (selectAssets.Length != 1) return;
        string fullPath = AssetBundleConfig.PROJECT_PATH + AssetDatabase.GetAssetPath(selectAssets[0]);
        AssetImporter _assetImporter = null;
        if (Directory.Exists(fullPath))
        {
            DirectoryInfo DirInfos = new DirectoryInfo(fullPath);
            FileInfo[] fileInfos = DirInfos.GetFiles("*", System.IO.SearchOption.AllDirectories);
            for (int i = 0; i < fileInfos.Length; i++)
            {
                var _fileInfo = fileInfos[i];
                for (int j = 0; j < FileSuffixName.Length; j++)
                {
                    string _suffixName = FileSuffixName[j];
                    if (_fileInfo.Name.EndsWith(FileSuffixName[j]))
                    {
                        string _path = _fileInfo.FullName.Replace("\\", "/").Substring(AssetBundleConfig.PROJECT_PATH.Length);
                        _assetImporter = AssetImporter.GetAtPath(_path);
                        if (_assetImporter != null)
                        {
                            _assetImporter.assetBundleName = null;
                        }
                    }
                }
                
            }
            AssetDatabase.RemoveUnusedAssetBundleNames();
        }
    }

    [MenuItem("AssetBundles/AssetBundleHelper/CheckTheAssetDependencies")]
    public static void CheckDependencies()
    {
        GameObject selectAssets = Selection.activeObject as GameObject;
        Object[] roots = new GameObject[] { selectAssets};
        Object[] objs = EditorUtility.CollectDependencies(roots);
        Selection.objects= EditorUtility.CollectDependencies(roots);    
        for (int i = 0; i < objs.Length; i++)
        {
            if(objs[i] is MonoBehaviour)
            {
                //Debug.Log(string.Format("root obj :{0},dependece obj:{1}", roots[0], objs[i]));
            }
            
        }

    }


}
