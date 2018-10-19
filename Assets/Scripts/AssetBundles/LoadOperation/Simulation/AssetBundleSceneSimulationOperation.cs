using System;
using UnityEngine;
using UnityEngine.Networking;
#if UNITY_EDITOR
using UnityEditor;
#endif


namespace Game.AssetBundles
{
    public class AssetBundleSceneSimulationOperation : AssetBundleOperation
    {
        private AsyncOperation mOperation;


        public AssetBundleSceneSimulationOperation(string _assetBundleName,string _sceneName,bool _isAdditive)
        {

#if UNITY_EDITOR
            string[] scenePaths = AssetDatabase.GetAssetPathsFromAssetBundleAndAssetName(_assetBundleName, _sceneName);
            if (scenePaths.Length == 0)
            {
                Debug.LogError(string.Format("没有这个名字的场景： {0}, 在assetbundle:{1}", _sceneName, _assetBundleName));
                return;
            }
            if (_isAdditive)
            {
                mOperation = EditorApplication.LoadLevelAdditiveAsyncInPlayMode(scenePaths[0]);
            }
            else
            {
                mOperation = EditorApplication.LoadLevelAdditiveAsyncInPlayMode(scenePaths[0]);
            }
#endif


        }

        public override bool IsDone()
        {
            return mOperation == null || mOperation.isDone;
        }

        public override bool Update()
        {
            return false;
        }
    }
}
