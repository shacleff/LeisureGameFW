
using System.Collections.Generic;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif


namespace Game.AssetBundles
{
    public class AssetsBundleManager:MonoBehaviour
    {
        public delegate string OverrideBaseDownloadingURLDelegate(string _assetbundleName);
        /// <summary>
        /// 实现每个bundle的基本下载URL覆盖。,订阅者必须为未知的包名返回空值;
        /// </summary>
        public static event OverrideBaseDownloadingURLDelegate overrideBaseDownloadingURL;

        private static string mBaseDownloadingURL = "";
        /// <summary>
        /// 用于生成完整的基本下载URL,使用assetBundle名称下载url。
        /// </summary>
        public static string BaseDownloadingURL
        {
            get { return mBaseDownloadingURL; }
            set { mBaseDownloadingURL = value; }
        }
        private static string[] mActivevariants = { };
        private static AssetBundleManifest mAssetBundleManifest = null;
        /// <summary>
        ///  AssetBundleManifest对象，可用于加载依赖项
        ///  并检查合适的assetsBundle变体。
        /// </summary>
        public static AssetBundleManifest AssetBundleManifestObject
        {
            set
            {
                mAssetBundleManifest = value;
            }
        }

        private static Dictionary<string, AssetBundleRes> mLoadedAssetBundles = new Dictionary<string, AssetBundleRes>();
        /// <summary>
        /// 
        /// </summary>
        public static Dictionary<string,AssetBundleRes> GetLoadedAssetBundles
        {
            get
            {
                return mLoadedAssetBundles;
            }
        }
        private static Dictionary<string, string> mDownloadingErrors = new Dictionary<string, string>();
        private static List<string> mDownloadingBundles = new List<string>();
        public static List<string> GetDownloadingBundles
        {
            get
            {
                return mDownloadingBundles;
            }
        }
        private static List<AssetBundleOperation> mProgressOperations = new List<AssetBundleOperation>();
        private static Dictionary<string, string[]> mDependencies = new Dictionary<string, string[]>();
        public static Dictionary<string,string[]> GetDependencies
        {
            get
            {
                return mDependencies;
            }
        }

#if UNITY_EDITOR
        private static int mSimulateAssetBundleInEditor = -1;
        /// <summary>
        /// 标记以指示我们是否要在编辑器中模拟assetBundles而不实际构建它们。
        /// </summary>
        public static bool SimulateAssetBundleInEditor
        {
            get
            {
                if (mSimulateAssetBundleInEditor == -1)
                    mSimulateAssetBundleInEditor = EditorPrefs.GetBool(K_SIMULATE_ASSETBUNDLES, true) ? 1 : 0;
                return mSimulateAssetBundleInEditor != 0;
            }
            set
            {
                int _value = value ? 1 : 0;
                if(_value!=mSimulateAssetBundleInEditor)
                {
                    mSimulateAssetBundleInEditor = _value;
                    EditorPrefs.SetBool(K_SIMULATE_ASSETBUNDLES, value);
                }
            }
        }
        private const string K_SIMULATE_ASSETBUNDLES = "simulate_asset_bundles";
#endif

        /// <summary>
        /// 初始化assetbundle manager并开始下载清单资产包。返回清单资产包downolad操作对象。
        /// </summary>
        public static AssetBundleMaifestOperation Initialize()
        {
            return Initialize("AssetBundle");
        }

        /// <summary>
        /// 初始化assetbundle manager并开始下载清单资产包。返回清单资产包downolad操作对象。
        /// </summary>
        /// <param name="_path"></param>
        public static AssetBundleMaifestOperation Initialize(string _manifestAssetBundleName)
        {
            var go = new GameObject("AssetBundleManager",typeof(AssetsBundleManager));
            //go.AddComponent<AssetsBundleManager>();
            UnityEngine.Object.DontDestroyOnLoad(go);
            if(Application.platform==RuntimePlatform.WindowsEditor)
            {
                if (SimulateAssetBundleInEditor) return null;
            }
            LoadAssetBundle(_manifestAssetBundleName, true);
            var operation = new AssetBundleMaifestOperation(_manifestAssetBundleName, "AssetBundleManifest", typeof(AssetBundleManifest));
            //Debug.Log(string.Format("{0},{1}", mAssetBundleManifest, mAssetBundleManifest.name));
            mProgressOperations.Add(operation);
            return operation;
        }

        /// <summary>
        /// 从给定资产包开始资产的加载操作。
        /// </summary>
        public static BaseAssetBundleAssetOperation LoadAssetAsync(string _assetBundleName,string _assetName,System.Type _type)
        {
            BaseAssetBundleAssetOperation operation =null;
            if(Application.platform==RuntimePlatform.WindowsEditor && SimulateAssetBundleInEditor)
            {
                //获取标有assetBundleName且命名为assetName的所有资产的资产路径。
                string[] _assetPaths = AssetDatabase.GetAssetPathsFromAssetBundleAndAssetName(_assetBundleName, _assetName);
                //现在我们只从第一个资产中获取主要对象。 还应该考虑类型。
                UnityEngine.Object _obj = AssetDatabase.LoadMainAssetAtPath(_assetPaths[0]);
                operation = new AssetBundleAssetSimulationOperation(_obj);
            }
            else
            {
                LoadAssetBundle(_assetBundleName);
                operation = new AssetBundleAssetOperation(_assetBundleName,_assetName,_type);
                mProgressOperations.Add(operation);
            }
            return operation;
        }

        /// <summary>
        /// 从给定资产包开始一个场景的加载操作。
        /// </summary>
        public static AssetBundleOperation LoadSceneAsync(string _assetbundleName,string _sceneName,bool _isAdditive)
        {
            AssetBundleOperation operation = null;

            if(Application.platform==RuntimePlatform.WindowsEditor)
            {
                if(SimulateAssetBundleInEditor)
                {
                    operation = new AssetBundleSceneSimulationOperation(_assetbundleName, _sceneName, _isAdditive);
                }
            }
            else
            {
                LoadAssetBundle(_assetbundleName);
                operation = new AssetBundleSceneOperation(_assetbundleName, _sceneName, _isAdditive);
                mProgressOperations.Add(operation);
            }

            return operation;
        }

        public static void LoadAssetBundle(string _assetbundleName)
        {
            LoadAssetBundle(_assetbundleName, false);
        }

        /// <summary>
        /// 开始下载由给定名称标识的资产包以及此资产包所依赖的资产包。
        /// </summary>
        public static void LoadAssetBundle(string _assetbundleName,bool _isLoadingmanifest)
        {
            if(Application.platform==RuntimePlatform.WindowsEditor)
            {
                if (SimulateAssetBundleInEditor) return;
            }

            if(!_isLoadingmanifest)
            {
                if (mAssetBundleManifest == null) return;
            }
            //查看assetbundle是否已经在进程上
            bool isAlreadyProcessed = LoadAssetBundleInternal(_assetbundleName, _isLoadingmanifest);
            if (!isAlreadyProcessed && !_isLoadingmanifest) LoadDependencies(_assetbundleName);
        }

        /// <summary>
        /// 我们获取所有依赖项并将其全部加载。
        /// </summary>
        public static void LoadDependencies(string _assetbundleName)
        {
            if (mAssetBundleManifest == null) return;
            string[] dependencies = mAssetBundleManifest.GetAllDependencies(_assetbundleName);
            if (dependencies.Length == 0) return;

            mDependencies.Add(_assetbundleName, dependencies);
            for (int i = 0; i < dependencies.Length; i++)
            {
                Debuger.Log("dependenies: {0}", dependencies[i]);
                LoadAssetBundleInternal(dependencies[i], false);
            }
        }

        /// <summary>
        /// 如果尚未下载，则设置给定资产包的下载操作。
        /// </summary>
        protected static bool LoadAssetBundleInternal(string _assetbundleName,bool _isLoadingManifest)
        {
            AssetBundleRes asset = null;
            mLoadedAssetBundles.TryGetValue(_assetbundleName, out asset);
            if(asset!=null)
            {
                asset.mReferencedCount++;
                return true;
            }
            //我们是否需要考虑引用的WWW数量？
            //在演示中，我们永远不会有重复的WWW，因为我们在调用另一个LoadAssetAsync（）/ LoadLevelAsync（）之前等待LoadAssetAsync（）/ LoadLevelAsync（）完成。
            //但在实际情况中，用户可以多次调用LoadAssetAsync（）/ LoadLevelAsync（），然后等待它们完成，这可能有重复的WWW。
            if (mDownloadingBundles.Contains(_assetbundleName)) return true;
            string assetBaseDownloadingURL = GetAssetBundleBaseDownloadingURL(_assetbundleName);
            if(assetBaseDownloadingURL.ToLower().StartsWith("odr://"))
            {
                new ApplicationException("Can't load bundle " + _assetbundleName + " through ODR: this Unity version or build target doesn't support it.");
            }
            else if(assetBaseDownloadingURL.ToLower().StartsWith("res://"))
            {
                new ApplicationException("Can't load bundle " + _assetbundleName + " through asset catalog: this Unity version or build target doesn't support it.");
            }
            else
            {
                WWW download = null;
                if (!assetBaseDownloadingURL.EndsWith("/"))
                    assetBaseDownloadingURL += "/";
                string url = assetBaseDownloadingURL + _assetbundleName;
                //对于manifest assetbundle，总是下载它，因为我们没有哈希值。
                if (_isLoadingManifest)
                    download = new WWW(url);
                else
                    download = WWW.LoadFromCacheOrDownload(url, mAssetBundleManifest.GetAssetBundleHash(_assetbundleName), 0);

                mProgressOperations.Add(new AssetBundleFromWeb(_assetbundleName,download));
            }
            mDownloadingBundles.Add(_assetbundleName);
            return false;
        }

        void Update()
        {
            // Update all in progress operations
            for (int i = 0; i < mProgressOperations.Count;)
            {
                var operation = mProgressOperations[i];
                if (operation.Update())
                {
                    i++;
                }
                else
                {
                    mProgressOperations.RemoveAt(i);
                    ProcessFinishedOperation(operation);
                }
            }
        }

        void ProcessFinishedOperation(AssetBundleOperation operation)
        {
            AssetBundleDownloadOperation download = operation as AssetBundleDownloadOperation;
            if (download == null)
                return;

            if (string.IsNullOrEmpty(download.error))
                mLoadedAssetBundles.Add(download.AssetbundleName, download.assetBundleRes);
            else
            {
                string msg = string.Format("Failed downloading bundle {0} from {1}: {2}",
                        download.AssetbundleName, download.GetSourceURL(), download.error);
                mDownloadingErrors.Add(download.AssetbundleName, msg);
            }

            mDownloadingBundles.Remove(download.AssetbundleName);
        }

        /// <summary>
        /// 检索先前通过LoadAssetBundle请求的资产包。
        /// 如果尚未下载资产包或其中一个依赖项，则返回null。
        /// </summary>
        /// <param name="_assetbundleName"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static AssetBundleRes GetLoadedAssetBundle(string _assetbundleName,out string error)
        {
            if (mDownloadingErrors.TryGetValue(_assetbundleName, out error)) return null;

            AssetBundleRes loadedAB = null;
            mLoadedAssetBundles.TryGetValue(_assetbundleName, out loadedAB);
            if (loadedAB == null) return null;

            string[] dependcies = null;
            if (!mDependencies.TryGetValue(_assetbundleName, out dependcies)) return loadedAB;

            //确保加载所有依赖项
            foreach (string dependcie in dependcies)
            {
                if (mDownloadingErrors.TryGetValue(dependcie, out error)) return null;
                //等待所有依赖的assetsBundle被加载。
                AssetBundleRes dependentBundle;
                mLoadedAssetBundles.TryGetValue(dependcie, out dependentBundle);
                if (dependentBundle == null) return null;
            }
            return loadedAB;
        }

        /// <summary>
        /// 获取所有AssetBundle 名称
        /// </summary>
        /// <returns></returns>
        public static string[] GetAllAssetBundles()
        {
            if (mAssetBundleManifest != null)
                return mAssetBundleManifest.GetAllAssetBundles();
            else
                throw new Exception("the mAssetBundleManifest is null");
        }

        /// <summary>
        /// 如果已下载某个资产包而未检查是否已加载依赖项，则返回true。
        /// </summary>
        /// <param name="_assetBundleName"></param>
        /// <returns></returns>
        public static bool IsAssetBundleDownloaded(string _assetBundleName)
        {
            return mLoadedAssetBundles.ContainsKey(_assetBundleName);
        }

        /// <summary>
        /// 返回给定资产包的基本下载URL。可以通过overrideBaseDownloadingURL事件在每个包的基础上覆盖此URL。
        /// </summary>
        /// <param name="_bundleName"></param>
        /// <returns></returns>
        protected static string GetAssetBundleBaseDownloadingURL(string _bundleName)
        {
            if(overrideBaseDownloadingURL!=null)
            {
                foreach (OverrideBaseDownloadingURLDelegate method in overrideBaseDownloadingURL.GetInvocationList())
                {
                    string _res = method(_bundleName);
                    if (_res != null) return _res;
                }
            }
            return mBaseDownloadingURL;
        }

        /// <summary>
        /// 将基本下载URL设置为本地开发服务器URL。
        /// </summary>
        public static void SetAssetBundleServer()
        {
            if(Application.platform==RuntimePlatform.WindowsEditor)
            {
                if (SimulateAssetBundleInEditor) return;
            }
            TextAsset _urlFile = Resources.Load("AssetBundleServerURL") as TextAsset;
            string url = (_urlFile != null) ? _urlFile.text.Trim() : null;
            if(url==null || url.Length==0)
            {

            }
            else
            {
                SetSourceAssetBundleURL(url);
            }
        }

        /// <summary>
        /// 将基本下载URL设置为Web URL。 此URL指向的目录
        /// 在Web服务器上应该具有与演示项目根目录中的AssetBundles目录相同的结构。
        /// 例如，AssetBundles/iOS/xyz-scene必须映射到absolutePath/iOS/xyz-scene。
        /// </summary>
        /// <param name="_absolutePath"></param>
        public static void SetSourceAssetBundleURL(string _absolutePath)
        {
            if (!_absolutePath.EndsWith("/"))
                _absolutePath += "/";
            BaseDownloadingURL = _absolutePath + AssetBundlePath.GetPlatformName() + "/";
        }
    }
}
