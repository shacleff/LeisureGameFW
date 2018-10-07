using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


namespace Game.AssetBundles
{
    /// <summary>
    /// 已加载的assetBundle包含可用于的引用计数
    /// 自动卸载依赖的assetsBundles。
    /// </summary>
    public class AssetBundleRes
    {
        public AssetBundle assetbundle { get; set; }
        public int mReferencedCount;

        internal event Action unload;

        internal void OnUnload()
        {
            assetbundle.Unload(false);
            if (unload != null) unload();
        }

        public AssetBundleRes(AssetBundle _assetBundle)
        {
            this.assetbundle = _assetBundle;
            mReferencedCount = 1;
        }

        /// <summary>
        /// 返回AssetBundle中的所有asset名称。
        /// </summary>
        /// <returns></returns>
        public string[] GetAssetName()
        {
            return assetbundle.GetAllAssetNames();
        }
    }
}
