using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Game.AssetBundles
{
    public class AssetBundleMaifestOperation : AssetBundleAssetOperation
    {

        public AssetBundleMaifestOperation(string _bundleName, string _assetName, Type _type) : base(_bundleName, _assetName, _type)
        {
        }

        public override bool Update()
        {
            base.Update();
            if (request != null && request.isDone)
            {
                AssetsBundleManager.AssetBundleManifestObject = GetAsset<AssetBundleManifest>();

                return false;
            }
            else return true;
        }
    }
}
