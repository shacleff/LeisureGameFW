using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidNativeShockDemo : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        if(Application.platform==RuntimePlatform.Android)
        {
            //"com.unity3d.player.UnityPlayer" 是需要调用的接口所在的 Activity 所在的包名，
            //如果是 unity 主 Activity ，就可以直接使用 "com.unity3d.player.UnityPlayer"，
            //如果是其他插件包，就使用那个包的包名。
            AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
            int num= jo.Call<int>("Add", 2, 3);
            //string message = "this is my title";
            //string body = "this is my content";
            //jo.Call("showDialog", message,body);
            Debug.Log("unity call android num: " + num);
            long[] shock = new long[] { 0, 200 };
            jo.Call("StartShock", shock,-1);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
