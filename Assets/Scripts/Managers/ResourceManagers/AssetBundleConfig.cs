using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetBundleConfig 
{
    //AssetBundle打包路径
    public static string ASSETBUNDLE_PATH = Application.dataPath + "/StreamingAssets/AssetBundle/";

    public static string ASSETBUNDLE_STREAMINGASSET_PATH = "file://"+Application.streamingAssetsPath + "/AssetBundle/";

    //资源地址
    public static string APPLICATION_PATH = Application.dataPath + "/";

    //工程地址
    public static string PROJECT_PATH = APPLICATION_PATH.Substring(0, APPLICATION_PATH.Length - 7);

    //AssetBundle名
    public static string ASSETBUNDLE_FILENAM = "AssetBundle";

    //AssetBundle打包的后缀名
    public static string SUFFIX = ".dts";

}
