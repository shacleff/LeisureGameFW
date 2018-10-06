using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.AssetBundles
{
    /// <summary>
    /// 读取Asset/Scene 资源操作基类
    /// </summary>
    public abstract class BaseAssetBundleAssetOperation : AssetBundleOperation
    {
        /// <summary>
        /// 获取Asset/Scene资源
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public abstract T GetAsset<T>() where T : UnityEngine.Object;
        
    }
}
