using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using FlipGun;

namespace Utility
{
    public static class GameObjectHelper
    {
        private static Dictionary<string, Sprite> _SpriteUIDictionary;

        private static GameObject _uiTipsPanelObj;

        /// <summary>
        /// Instantiate预制物体
        /// </summary>
        /// <param name="prefab"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static GameObject InstantiateObjectByPrefab(GameObject prefab, Transform parent=null)
        {
            GameObject go = GameObject.Instantiate(prefab) as GameObject;
            go.name = prefab.name;
            if (parent != null)
                go.transform.SetParent(parent);
            go.transform.Reset();
            return go;
        }

        public static GameObject CreatePrefab(GameObject _prefab,Transform _parent=null)
        {
            GameObject go = GameObject.Instantiate(_prefab) as GameObject;
            go.name = _parent.name;
            if (_parent != null)
                go.transform.SetParent(_parent);
            go.transform.Reset();
            return go;
        }

        /// <summary>
        /// 获取单个组件
        /// </summary>
        /// <returns>The component by name.</returns>
        /// <param name="go">Go.</param>
        /// <param name="name">Name.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T GetComponentByName<T>(GameObject go, string name)
            where T : Component
        {
            T[] buffer = go.GetComponentsInChildren<T>(true);
            foreach (var o in buffer)
            {
                if (o != null && o.name == name)
                {
                    return o;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取某个节点下的所有相同的组件
        /// </summary>
        /// <returns>The components by name.</returns>
        /// <param name="go">Go.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T[] GetComponentsByName<T>(GameObject go)
            where T : Component
        {
            T[] buffer = go.GetComponentsInChildren<T>(true);
            return buffer;
        }

        /// <summary>
        /// 获取单个GameObject
        /// </summary>
        /// <returns>The game object by name.</returns>
        /// <param name="go">Go: 一般是所寻找对象的父层级</param>
        /// <param name="findName">Find name.</param>
        public static GameObject GetGameObjectByName(GameObject go, string findName)
        {
            GameObject obj = null;
            Transform[] objChildren = go.GetComponentsInChildren<Transform>(true);
            for (int i = 0; i < objChildren.Length; ++i)
            {
                if (objChildren[i].name == findName)
                {
                    obj = objChildren[i].gameObject;
                    break;
                }
            }
            
            return obj;
        }

        /// <summary>
        /// 获取单个GameObject
        /// </summary>
        /// <returns>The game object by name.</returns>
        /// <param name="go">Go: 一般是所寻找对象的父层级</param>
        /// <param name="findName">Find name.</param>
        public static Transform GetGameObjectByName(Transform go, string findName)
        {
            Transform obj = null;
            Transform[] objChildren = go.GetComponentsInChildren<Transform>(true);
            for (int i = 0; i < objChildren.Length; ++i)
            {
                if (objChildren[i].name == findName)
                {
                    obj = objChildren[i];
                    break;
                }
            }
            return obj;
        }

        /// <summary>
        /// 获取多个GameObject
        /// </summary>
        /// <returns>The game objects by name.</returns>
        /// <param name="go">Go: 一般是所寻找对象的父层级</param>
        /// <param name="findName">Find name.</param>
        public static List<GameObject> GetGameObjectsByName(GameObject go, string findName)
        {
            List<GameObject> objs = new List<GameObject>();
            Transform[] objChildren = go.GetComponentsInChildren<Transform>(true);
            for (int i = 0; i < objChildren.Length; ++i)
            {
                if (objChildren[i].name.Contains(findName))
                {
                    objs.Add(objChildren[i].gameObject);
                }
            }
            return objs;
        }


        public static T FindInParents<T>(GameObject go) where T : Component
        {
            if (go == null) return null;
            var comp = go.GetComponent<T>();

            if (comp != null)
                return comp;

            Transform t = go.transform.parent;
            while (t != null && comp == null)
            {
                comp = t.gameObject.GetComponent<T>();
                t = t.parent;
            }
            return comp;
        }
        
        public static void SetSpriteFromName(this GameObject _obj, string _assetName)
        {
            Sprite _sprite = GetSpriteFromName(_assetName);
            _obj.GetComponent<Image>().sprite = _sprite;
        }

        public static Sprite GetSpriteFromName(string _assetName)
        {
            return null;
        }

        /// <summary>
        /// 通过图片名字获取Sprite对象
        /// </summary>
        /// <returns>The sprite U.</returns>
        /// <param name="uiName">User interface name.</param>
        /*public static Sprite GetSpriteUI(String uiName)
        {
            if (_SpriteUIDictionary == null) 
            {
                _SpriteUIDictionary = new Dictionary<string, Sprite> ();
                //这里图片存储路径写死了，后面再优化
                DirectoryInfo rootDirInfo = new DirectoryInfo (Application.dataPath + "/Textures");
                foreach (DirectoryInfo dir in rootDirInfo.get) 
                {

                    foreach (FileInfo file in dir.GetFiles("*.png",SearchOption.AllDirectories)) 
                    {
                        string allPath = file.FullName;
                        string assetPath = allPath.Substring (allPath.IndexOf ("Assets"));
                        //MMDebug.Error(assetPath);
                        Sprite sprite;
    #if UNITY_EDITOR
                        sprite = UnityEditor.AssetDatabase.LoadAssetAtPath<Sprite> (assetPath);
    #else
                        sprite=Resources.Load<Sprite>(assetPath);
    #endif
                        Sprite outSprite;
                        if (!_SpriteUIDictionary.TryGetValue (sprite.name, out outSprite))
                        {
                            _SpriteUIDictionary.Add (sprite.name, sprite);
                        }
                    }
                }
            }
            if (_SpriteUIDictionary.ContainsKey (uiName))
                return _SpriteUIDictionary [uiName];
            else
                return null;
        }*/

        /// <summary>
        /// 获取时间
        /// </summary>
        /// <returns>返回转换后的时间</returns>
        /// <param name="seconds">总共的秒数</param>
        public static string GetTimeString(int seconds, bool showSeconds = true)
        {
            System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(seconds);
            string ret = "";

            if (timeSpan.Days > 0)
            {
                ret += timeSpan.Days + "天";
            }

            if (timeSpan.Hours > 0)
            {
                ret += timeSpan.Hours + "小时";
            }

            if (timeSpan.Minutes > 0)
            {
                ret += timeSpan.Minutes + "分钟";
            }

            if (showSeconds && timeSpan.Seconds > 0)
            {
                ret += timeSpan.Seconds + "秒";
            }

            return ret;
        }

        /// <summary>
        /// 获取时间
        /// </summary>
        /// <returns>返回转换后的时间</returns>
        /// <param name="seconds">总共的秒数</param>
        public static string GetTimeStringType2(int seconds)
        {
            System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(seconds);
            string ret = "";

            if (timeSpan.Hours > 0)
            {
                ret += timeSpan.Days * 24 + timeSpan.Hours + ":";
            }

            if (timeSpan.Minutes > 0)
            {

                ret += (timeSpan.Minutes >= 10) ? (timeSpan.Minutes + ":") : ("0" + timeSpan.Minutes + ":");
            }

            if (timeSpan.Seconds >= 0)
            {
                ret += (timeSpan.Seconds >= 10) ? (timeSpan.Seconds + "") : ("0" + timeSpan.Seconds);
            }
            return ret;
        }

        public static void ShowDialogTips(string value)
        {
            //UIManager.Instance.OpenUI (EUIPanel.UITipsDialog).Refresh (value);
        }

        public static void ShowTextTips(string value)
        {
            /*UITextTipsView view = UIManager.Instance.CreateUIView<UITextTipsView> ("UITips/UITextTipsPanel");
            UISceneView.Instance.UITopRoot.AddSubView(view);
            view.gameObject.Refresh (value, true);
            view.Open ();*/
        }

        public static void ShowPopupTextTips(string value)
        {
            /*UITextTipsView view = UIManager.Instance.CreateUIView<UITextTipsView> ("UITips/UITextTipsPanel");
            UISceneView.Instance.UITopRoot.AddSubView(view);

            var from = new Vector3(Screen.width * 0.5f, Screen.height * 0.25f);
            var to = new Vector3(Screen.width * 0.5f, Screen.height * 0.75f);

            RectTransformUtility.ScreenPointToWorldPointInRectangle(view.transform as RectTransform, from, ioo.UICamera, out from);
            RectTransformUtility.ScreenPointToWorldPointInRectangle(view.transform as RectTransform, to, ioo.UICamera, out to);

            view.gameObject.Refresh (value, false, from, to, Ease.Linear, 4f);

            view.Open ();*/
        }
    }


}


