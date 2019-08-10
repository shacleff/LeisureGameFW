using System;
using UnityEngine;
using System.Collections;

public class AdManager : MonoSingleton<AdManager>
{

    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    public void ShowRewardedAds(Action<ShowResult> resultHandler, bool isSkipMission = false)
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
                //ASCSDKInterface.Instance.OnVideoCallBack = delegate (CallBackStatus status)
                //{

                //    if (status == CallBackStatus.SUCCEED)
                //    {
                //        // Succeed
                //        resultHandler(ShowResult.Finished);
                //        OnFinishAds(adkey, isSkipMission);
                //    }
                //    else
                //    {
                //        resultHandler(ShowResult.Failed);
                //        OnFinishAds(adkey, isSkipMission);
                //    }
                //};
            }
            
        }



    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            //调用SDK的退出确认框,返回false，说明SDK不支持退出框，游戏需要使用自己的退出框
            //ASCSDKInterface.Instance.SDKExit();
        }
    }
}

public enum ShowResult
{
    Failed = 0,
    Skipped = 1,
    Finished = 2
}
