using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.AssetBundles
{
    /// <summary>
    /// 模拟Asset/Scene 加载操作
    /// </summary>
    public class AssetBundleAssetSimulationOperation : BaseAssetBundleAssetOperation
    {
        private Object mSimulationObject;

        public AssetBundleAssetSimulationOperation(Object _simulatedObject)
        {
            this.mSimulationObject = _simulatedObject;
        }

        public override T GetAsset<T>()
        {
            return mSimulationObject as T;
        }

        public override bool IsDone()
        {
            return true;
        }

        public override bool Update()
        {
            return false;
        }
    }
}
