using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace Game.AssetBundles
{
    public class AssetBundleSceneOperation : AssetBundleOperation
    {
        protected string assetBundleName;
        protected string sceneName;
        protected string downloadingError;
        protected bool isAdditive;
        protected AsyncOperation operation;
        

        public AssetBundleSceneOperation(string _assetBundleName,string _SceneName,bool _isAdditive)
        {
            this.assetBundleName = _assetBundleName;
            this.sceneName = _SceneName;
            this.isAdditive = _isAdditive;
        }

        public override bool IsDone()
        {
            if(operation == null && downloadingError != null)
            {
                Debug.LogError(downloadingError);
                return true;
            }
            return operation != null && operation.isDone;
        }

        public override bool Update()
        {
            if (operation != null) return false;

            AssetBundleRes bundle = AssetsBundleManager.GetLoadedAssetBundle(assetBundleName, out downloadingError);
            if(bundle!=null)
            {
                if (isAdditive) operation = SceneManager.LoadSceneAsync(sceneName);
                else operation = SceneManager.LoadSceneAsync(sceneName);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
