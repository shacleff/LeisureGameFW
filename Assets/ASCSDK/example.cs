using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class example : ASCSDKCallback
{
	//演示使用
	bool isOn = false;
    //演示使用
    bool isEn = false;
	void Awake(){

	}
    void Start()
    {
		//初始化
#if UNITY_EDITOR

#elif UNITY_ANDROID
		ASCSDKInterface.Instance.Init();

		//视频回调事件
		ASCSDKInterface.Instance.OnVideoCallBack = delegate (CallBackStatus status)
        {
            if (status == CallBackStatus.SUCCEED)
            {
                //视频播放成功(Play video Succeed)
            }
            else
            {
                //视频播放失败(Play video Defeated)
            }
        };

		//礼包回调事件
		ASCSDKInterface.Instance.OnGetGiftInfo = delegate (int propNumber, string msg, string type)
		{
			//propNumber为下发的道具数量（若为0，则道具下发失败），msg为状态信息,type 是道具类型（金币（Golds），钻石（Diamonds），或者其他自定义）
		};
#endif
		var bntarr = transform.GetComponentsInChildren<Button>();
		foreach (var item in bntarr)
		{
			item.onClick.AddListener(() => OnBtnClick(item));
		}
	}

   public void OnBtnClick(Button Btn)
    {
		Debug.Log(Btn.name);
        switch (Btn.name)
        {
            case "gift_exchange":
                ASCSDKInterface.Instance.ExchangeGift("0");
                break;
            case "show_inters":
                if (ASCSDKInterface.Instance.GetIntersFlag())
                {
                    ASCSDKInterface.Instance.ShowInters();
                }
                break;
            case "show_splash":
                if (ASCSDKInterface.Instance.GetSplashFlag())
                {
                    ASCSDKInterface.Instance.ShowSplash();
                }
                break;
            case "show_video":
                if (ASCSDKInterface.Instance.GetVideoFlag())
                {
                    ASCSDKInterface.Instance.ShowVideo();
                }
                break;
            case "banner":
                if (isOn)
                {
                    isOn = false;
                    Btn.GetComponentsInChildren<Text>()[0].text = isEn ? "HIDE BANNER" : "隐藏横幅";
                    ASCSDKInterface.Instance.ShowBanner();//展示广告（show ads）
                }
                else
                {
                    isOn = true;
                    Btn.GetComponentsInChildren<Text>()[0].text = isEn? "SHOW BANNER":"展示横幅";
                    ASCSDKInterface.Instance.HideBanner();//隐藏广告(Hide ads)
                }
                break;
            case "rate":
				if (ASCSDKInterface.Instance.GetRateFlag())
				{
					ASCSDKInterface.Instance.Evaluation();
				}
				break;
            case "show_elect":
                if (ASCSDKInterface.Instance.GetElectFlag())
                {
                    //finished : Play through completion
                    //start : The game starts to pop up automatically
                    //click : Game more game active click
                    ASCSDKInterface.Instance.ShowElect("click");
                    //gif elect
	                //position x,y
                    //ASCSDKInterface.Instance.ShowElectGif(0.5f, 0.5f);
                }
                break;
            case "translation":
                if (isEn)
                {
                    isEn = false;
                    Btn.GetComponentInChildren<Text>().text = "English";
                    GameObject.Find("gift_exchange").GetComponentsInChildren<Text>()[0].text = "礼包兑换";
                    GameObject.Find("show_inters").GetComponentsInChildren<Text>()[0].text = "插屏";
                    GameObject.Find("show_splash").GetComponentsInChildren<Text>()[0].text = "开屏";
                    GameObject.Find("show_video").GetComponentsInChildren<Text>()[0].text = "视频";
                    if (isOn)
                    {
                        GameObject.Find("banner").GetComponentsInChildren<Text>()[0].text = "展示横幅";
                    }
                    else
                    {
                        GameObject.Find("banner").GetComponentsInChildren<Text>()[0].text = "隐藏横幅";
                    }
                    GameObject.Find("rate").GetComponentsInChildren<Text>()[0].text = "评价";
                    GameObject.Find("show_elect").GetComponentsInChildren<Text>()[0].text = "展示互推";
                }
                else {
                    isEn = true;
                    Btn.GetComponentInChildren<Text>().text = "Chinese";
                    GameObject.Find("gift_exchange").GetComponentsInChildren<Text>()[0].text = "GIFT EXCHANGE";
                    GameObject.Find("show_inters").GetComponentsInChildren<Text>()[0].text = "SHOW INTERS";
                    GameObject.Find("show_splash").GetComponentsInChildren<Text>()[0].text = "SHOW SPLASH";
                    GameObject.Find("show_video").GetComponentsInChildren<Text>()[0].text = "SHOW VIDEO";
                    if (isOn)
                    {
                        GameObject.Find("banner").GetComponentsInChildren<Text>()[0].text = "SHOW BANNER";
                    }
                    else {
                        GameObject.Find("banner").GetComponentsInChildren<Text>()[0].text = "HIDE BANNER";
                    }
                    GameObject.Find("rate").GetComponentsInChildren<Text>()[0].text = "RATE APP";
                    GameObject.Find("show_elect").GetComponentsInChildren<Text>()[0].text = "SHOW ELECT";
                }
                break;
		}
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            //调用渠道的退出确认框,返回false，说明SDK不支持，游戏需要使用自己的退出框
            if (ASCSDKInterface.Instance.IsSupportExit())
            {
                //退出
                ASCSDKInterface.Instance.SDKExit();
            }
            else
            {
                //调用自己的退出界面
                //Call your exit interface
            }
        }
	}
}
