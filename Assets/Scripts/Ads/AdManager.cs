using System;
using UnityEngine;
using System.Collections;

public class AdManager : MonoSingleton<AdManager>
{

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        if(Application.platform==RuntimePlatform.Android)
            ASCSDKInterface.Instance.Init();
    }

    public void ShowRewardedAds(Action<ShowResult> resultHandler)
    {
        bool isVideoReady = true;
        if (isVideoReady)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                resultHandler(ShowResult.Finished);
                
            }
            else
            {
                ASCSDKInterface.Instance.OnVideoCallBack = delegate (CallBackStatus status)
                {

                    if (status == CallBackStatus.SUCCEED)
                    {
                        // Succeed
                        Log("Video CallBack,resultHandler--ShowResult.Finished");
                        resultHandler(ShowResult.Finished);
                    }
                    else
                    {
                        Log("Video CallBack,resultHandler--ShowResult.Failed");
                        resultHandler(ShowResult.Failed);
                    }
                };
            }
            
        }

    }

    void OnVideoClick()
    {
        Log("展示视频");
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {

        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            ASCSDKInterface.Instance.ShowVideo();
        }
        else
        {
        }

    }

    /// <summary>
    /// 打点
    /// </summary>
    /// <param name="eventName"></param>
    public void UserCustomEvent(string eventName)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Debug.Log("打点——自定义事件: " + eventName);
            ASCSDKInterface.Instance.UserCustomEvent(eventName);
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            Debug.Log("打点——自定义事件: " + eventName);
        }
        else
        {
        }

    }

    private void Log(string message)
    {
        if(Application.platform==RuntimePlatform.Android)
        {
            Debug.Log(message);
            ASCSDKInterface.Instance.NativeLog(message);
        }
        else
        {
            Debug.Log(message);
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            //调用SDK的退出确认框,返回false，说明SDK不支持退出框，游戏需要使用自己的退出框
            ASCSDKInterface.Instance.SDKExit();
        }
    }
}

public enum ShowResult
{
    Failed = 0,
    Skipped = 1,
    Finished = 2
}
