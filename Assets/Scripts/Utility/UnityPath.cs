
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityPath 
{
    public static readonly string DATA_PATH = Application.dataPath;
    public static string STREAMING_ASSETS_PATH
    {
        get
        {
            string path = "";
#if UNITY_EDITOR
                        path = Application.dataPath + "/StreamingAssets/";
#elif UNITY_ANDROID
                        path= "jar:file://" + Application.dataPath + "!/assets/";
#else
                        path=Application.dataPath +"/Raw/";
#endif
            return path;
        }
    }


}

public class UIPath
{
    public static string OFFLINE_POPUP = "UI/Popups/OfflinePopup";

}

