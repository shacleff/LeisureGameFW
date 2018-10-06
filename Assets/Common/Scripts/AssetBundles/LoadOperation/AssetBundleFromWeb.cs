using System;
using UnityEngine;
using UnityEngine.Networking;

namespace Game.AssetBundles
{
    /// <summary>
    /// 从Web通过WWW下载资源/场景
    /// </summary>
    public class AssetBundleFromWeb : AssetBundleDownloadOperation
    {
        private WWW mWww;
        private string mUrl;
        

        public AssetBundleFromWeb(string _assetBundleName, WWW _www) : base(_assetBundleName)
        {
            if (_www == null) throw new System.ArgumentNullException("www");
            this.mUrl = _www.url;
            this.mWww = _www;
        }
        /// <summary>
        /// 判断下载是否完成
        /// </summary>
        protected override bool downloadIsDone
        {
            get
            {
                return (mWww == null) || mWww.isDone;
            }
        }
        

        /// <summary>
        /// 下载完成后调用，实例化AssetBundleRes
        /// </summary>
        protected override void FinishDownload()
        {
            error = mWww.error;
            if (!string.IsNullOrEmpty(error)) return;
            AssetBundle _assetBundle = mWww.assetBundle;
            if (_assetBundle == null) error = string.Format("{0} 无效assetbundle资源", AssetbundleName);
            else assetBundleRes = new AssetBundleRes(mWww.assetBundle);
            mWww.Dispose();
            mWww = null;
        }

        public override string GetSourceURL()
        {
            return mUrl;
        }

    }
}
