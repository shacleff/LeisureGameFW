using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.AssetBundles
{
    /// <summary>
    ///  AssetBundle 下载读取操作抽象类
    /// </summary>
    public abstract class AssetBundleDownloadOperation:AssetBundleOperation
    {
        /// <summary>
        /// 是否完成
        /// </summary>
        private bool isDone;

        protected AssetBundleDownloadOperation(string _assetBundleName)
        {
            this.AssetbundleName = _assetBundleName;
        }

        public AssetBundleRes assetBundleRes { get; protected set; }
        public string AssetbundleName { get; private set; }
        public string error { get; protected set; }

        /// <summary>
        /// 是否下载完成
        /// </summary>
        protected abstract bool downloadIsDone { get; }

        public override bool IsDone()
        {
            return isDone;
        }

        /// <summary>
        /// 更新下载，完成后调用下载完成事件
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {

            if (!isDone && downloadIsDone)
            {
                FinishDownload();
                isDone = true;
            }
            return !isDone;
        }

        /// <summary>
        /// 完成下载后的操作
        /// </summary>
        protected abstract void FinishDownload();

        public abstract string GetSourceURL();
        

    }
}
