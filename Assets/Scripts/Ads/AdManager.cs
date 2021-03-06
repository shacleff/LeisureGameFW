﻿using System;
using UnityEngine;
using System.Collections;

public class AdManager : MonoSingleton<AdManager>
{
    public bool IsInterFlag
    {
        get
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                return ASCSDKInterface.Instance.GetIntersFlag();
            }
            else
                return UnityEngine.Random.value <= 0.5f ? true : false;

        }
    }
    public bool IsVideoFlag
    {
        get
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                return ASCSDKInterface.Instance.GetVideoFlag();
            }
            else
                return true;
        }
    }

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
        if (IsVideoFlag)
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

    public void ShowInter()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (IsInterFlag)
            {
                Log("show inter success...");
                ASCSDKInterface.Instance.ShowInters();
            }
            else
            {
                Log("show inter is fail... the flag is false");
            }
        }
        else
        {
            Log("pc show inter ");
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
            Log("打点——自定义事件: " + eventName);
            ASCSDKInterface.Instance.UserCustomEvent(eventName);
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            Log("打点——自定义事件: " + eventName);
        }
        else
        {
        }

    }

    private void Log(string message)
    {
        if(Application.platform==RuntimePlatform.Android)
        {
            AdvertisingLog.Log(message);
            ASCSDKInterface.Instance.NativeLog(message);
        }
        else
        {
            AdvertisingLog.Log(message);
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

/// <summary>
/// 一个广告专用的log日志管理类
/// </summary>
public class AdvertisingLog
{

    public static void Log(string format,params object[] args)
    {
        Debug.LogFormat("game ad log:"+format, args);
    }

    public static void LogError(string format, params object[] args)
    {
        Debug.LogFormat(format, args);
    }
}


public enum ShowResult
{
    Failed = 0,
    Skipped = 1,
    Finished = 2
}
