using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// 
/// </summary>
public class AssetBundleManager:MonoBehaviour
{

    private static AssetBundleManifest manifest = null;
    private static Dictionary<string, AssetBundle> PathToAssetBundles = new Dictionary<string, AssetBundle>();
    private Action _callback;


    void Start()
    {
        //LoadAsseFromAsset(LoadComplete);
        //StartCoroutine(LoadAsset());
    }

    private IEnumerator LoadAsset()
    {
        //yield return LoadAssetWithUnityWebRequest(LoadComplete);
        yield return LoadAssetFromMemoryAsync(LoadComplete);
        //yield return LoadAssetWithWWW(LoadComplete);
        
    }

    private void LoadComplete()
    {
        
    }

    /// <summary>
    /// 对于某种资源依赖次数很多的情况，这种方案就会比较耗时。所以我们可以把加载好的资源用字典存着，下次如果还需要加载这个依赖项就可以直接从字典里面读取。
    /// </summary>
    /// <param name="_path"></param>
    /// <returns></returns>
    public static AssetBundle LoadAssetBundle(string _path)
    {
        if (PathToAssetBundles.ContainsKey(_path)) return PathToAssetBundles[_path];
        if(manifest==null)
        {
            AssetBundle manifestAssetBundle = AssetBundle.LoadFromFile(AssetBundleConfig.ASSETBUNDLE_PATH + AssetBundleConfig.ASSETBUNDLE_FILENAM);
            manifest = (AssetBundleManifest)manifestAssetBundle.LoadAsset("AssetBundleManifest");
        }
        else
        {
            string[] depends = manifest.GetAllDependencies(_path);
            for (int i = 0; i < depends.Length; i++)
            {
                LoadAssetBundle(depends[i]);
            }
            PathToAssetBundles[_path] = AssetBundle.LoadFromFile(AssetBundleConfig.ASSETBUNDLE_PATH + _path);
            return PathToAssetBundles[_path];
        }
        return null;
    }

    public void LoadAsseFromAsset(Action _callback)
    {
        string _assetPath = AssetBundleConfig.ASSETBUNDLE_PATH + AssetBundleConfig.ASSETBUNDLE_FILENAM;
        AssetBundle ab = AssetBundle.LoadFromFile(_assetPath);
        AssetBundleManifest manifest = ab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        string[] _assetNames = manifest.GetAllAssetBundles();
        AssetBundle AB_A = AssetBundle.LoadFromFile(AssetBundleConfig.ASSETBUNDLE_PATH + "test/obj");
        AssetBundle mat = AssetBundle.LoadFromFile(AssetBundleConfig.ASSETBUNDLE_PATH + "test/mat");
        GameObject[] objList = AB_A.LoadAllAssets<GameObject>();
        for (int i = 0; i < objList.Length; i++)
        {
            Instantiate(objList[i]);
        }
        if (_callback != null)
            _callback();
    }

    public IEnumerator LoadAssetFromMemoryAsync(Action _callback)
    {
        string _assetPath = AssetBundleConfig.ASSETBUNDLE_PATH + AssetBundleConfig.ASSETBUNDLE_FILENAM;
        AssetBundleCreateRequest request = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(_assetPath));
        yield return request;
        AssetBundle ab = request.assetBundle;
        AssetBundleManifest manifest = ab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        string[] _assetNames = manifest.GetAllAssetBundles();
        if (_callback != null)
            _callback();
    }

    public IEnumerator LoadAssetWithUnityWebRequest(Action _callback)
    {
        
        string _assetPath = AssetBundleConfig.ASSETBUNDLE_PATH + AssetBundleConfig.ASSETBUNDLE_FILENAM;
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(_assetPath);
        //UnityWebRequest request = UnityWebRequest.GetAssetBundle(_assetPath);
        yield return request.SendWebRequest();
        AssetBundle ab = DownloadHandlerAssetBundle.GetContent(request);
        AssetBundleManifest manifest = ab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        string[] _assetNames = manifest.GetAllAssetBundles();
        if (_callback != null)
            _callback();
    }

    private IEnumerator LoadAssetWithWWW(Action _callback)
    {
        string ASSETBUNDLE_PATH_WINDOWNS = AssetBundleConfig.ASSETBUNDLE_STREAMINGASSET_PATH + "AssetBundle";
        WWW www = new WWW(ASSETBUNDLE_PATH_WINDOWNS);
        Debug.Log("加载AssetBundle 中");
        yield return www;
        Debug.Log("已加载完成 AssetBundle");
        AssetBundleManifest manifest = (AssetBundleManifest)www.assetBundle.LoadAsset("AssetBundleManifest");
        string[] _assetNames = manifest.GetAllAssetBundles();
        
        if (_callback != null)
            _callback();
    }

    private void LogAllAssetDepned(string[] _assetNames)
    {
       
        for (int i = 0; i < _assetNames.Length; i++)
        {
            Debug.Log(string.Format("---Asset name: {0}", _assetNames[i]));
            //获取所有AssetBundle中的依赖项
            string[] dependencies = manifest.GetAllDependencies(_assetNames[i]);
            for (int j = 0; j < dependencies.Length; j++)
            {
                Debug.Log(string.Format("---depends name: {0}", dependencies[j]));
            }
        }
    }
	

}
