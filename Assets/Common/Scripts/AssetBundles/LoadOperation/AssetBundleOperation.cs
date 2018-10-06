using UnityEngine;
using System;
using System.Collections;

namespace Game.AssetBundles
{
    /// <summary>
    /// AssetBundle 下载读取操作抽象类
    /// 继承IEnumerator，形成迭代器
    /// </summary>
    public abstract class AssetBundleOperation:IEnumerator
    {
        /// <summary>
        /// 当前
        /// </summary>
        public object Current
        {
            get { return null; }
        }

        /// <summary>
        /// 跳转到下一个
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            return !IsDone();
        }

        public void Reset()
        {

        }

        public abstract bool Update();

        /// <summary>
        /// 操作完成，继续下一个迭代
        /// </summary>
        /// <returns></returns>
        public abstract bool IsDone();
    }
    
}
