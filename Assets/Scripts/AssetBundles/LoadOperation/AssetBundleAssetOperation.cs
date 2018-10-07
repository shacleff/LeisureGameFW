using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.AssetBundles
{
    /// <summary>
    /// 加载 Asset/Scene资源操作
    /// 具体类
    /// </summary>
    public class AssetBundleAssetOperation : BaseAssetBundleAssetOperation
    {
        protected string assetBundleName;
        protected string assetName;
        protected string downloadingError;
        protected System.Type type;
        protected AssetBundleRequest request=null;

        public AssetBundleAssetOperation(string _bundleName,string _assetName,System.Type _type)
        {
            this.assetBundleName = _bundleName;
            this.assetName = _assetName;
            this.type = _type;
        }

        public override T GetAsset<T>()
        {
            if (request != null && request.isDone)
                return request.asset as T;
            else
                return null;
        }

        /// <summary>
        /// downloadingError可能来自依赖项下载。
        /// </summary>
        /// <returns></returns>
        public override bool IsDone()
        {
            if(request==null && downloadingError!=null)
            {
                Debug.LogError(downloadingError);
                return true;
            }
            return request != null && request.isDone;
        }

        /// <summary>
        /// 如果需要更多Update调用，则返回true。
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {

            if (request != null) return false;
            AssetBundleRes assetBundleRes = AssetsBundleManager.GetLoadedAssetBundle(assetBundleName, out downloadingError);
            if(assetBundleRes!=null)
            {
                ///@TODO: 当资产包下载失败时，会抛出异常。
                request = assetBundleRes.assetbundle.LoadAssetAsync(assetName, this.type);
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
