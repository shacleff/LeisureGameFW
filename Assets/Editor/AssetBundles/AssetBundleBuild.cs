using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AssetBundleBuild
{
    [MenuItem("AssetBundles/BuildAssetBundle")]
    public static void BuildAssetBundle()
    {
        string _outputPath = AssetBundleConfig.ASSETBUNDLE_PATH.Substring(AssetBundleConfig.PROJECT_PATH.Length);
        if (!System.IO.Directory.Exists(_outputPath))
            System.IO.Directory.CreateDirectory(_outputPath);
        BuildPipeline.BuildAssetBundles(_outputPath,BuildAssetBundleOptions.UncompressedAssetBundle | BuildAssetBundleOptions.DeterministicAssetBundle, BuildTarget.StandaloneWindows64);
        Debug.Log("AssetBundle Build success!");

    }
	
}
