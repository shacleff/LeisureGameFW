//#if UNITY_ANDROID

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


/// <summary>
/// ASCSDK Android平台接口的调用
/// </summary>
public class SDKInterfaceAndroid : ASCSDKInterface
{

    private AndroidJavaObject jo;

    public SDKInterfaceAndroid()
    {
        using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
        }
    }

    private T SDKCall<T>(string method, params object[] param)
    {
		try
		{
			return jo.Call<T>(method, param);
		}
		catch (Exception e)
		{
			Debug.LogError(e);
		}
		return default(T);
	}

    private void SDKCall(string method, params object[] param)
    {
        try
        {
            jo.Call(method, param);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    public override void Login()
    {
        SDKCall("login");
    }

    //安卓打印日志
    public override void NativeLog(string str)
    {
#if UNITY_EDITOR
		Debug.Log(str);
#elif UNITY_ANDROID
		SDKCall("nativeLog", str);
#endif
	}

    public override void Evaluation()
    {
        SDKCall("OnRate");
    }

    //展示横幅
    public override void ShowBanner()
    {
        SDKCall("showBanner");
    }

    //隐藏横幅
    public override void HideBanner()
    {
        SDKCall("hideBanner"); 
    }

    //展示插屏
    public override void ShowInters()
    {
        SDKCall("showInters");
    }

    //展示开屏
    public override void ShowSplash()
    {
        SDKCall("showSplash");
    }

    //展示视频
    public override void ShowVideo()
    {
        SDKCall("showVideo");
    }

    public override bool GetIntersFlag()
    {
        return SDKCall<bool>("getIntersFlag");
    }

    public override bool GetSplashFlag()
    {
        return SDKCall<bool>("getSplashFlag");
    }

    public override bool GetVideoFlag()
    {
        return SDKCall<bool>("getVideoFlag");
    }

	public override bool GetRateFlag()
	{
		return SDKCall<bool>("getRateFlag");
	}
	public override bool Logout()
    {
        if (!IsSupportLogout())
        {
            return false;
        }
        SDKCall("logout");
        return true;
    }

    public override void ShakePhone(int tm)
    {
        SDKCall("shakePhone", tm);
    }

    public override bool ShowAccountCenter()
    {
        if (!IsSupportAccountCenter())
        {
            return false;
        }

        SDKCall("showAccountCenter");
        return true;
    }

    public override void SubmitGameData(ASCExtraGameData data)
    {
        string json = encodeGameData(data);
        SDKCall("submitExtraData", json);
    }

    public override bool SDKExit()
    {
        SDKCall("exit");
        return true;
    }

    public override void Pay(ASCPayParams data)
    {
        string json = encodePayParams(data);
        SDKCall("pay", json);
    }

    public override void Share(ShareParams shareParams)
    {
        string json = encodeShareParams(shareParams);
        SDKCall("shareToApp", json);
    }

    public override bool IsSupportExit()
    {
        return SDKCall<bool>("isSupportExit");
    }

    public override bool IsSupportAccountCenter()
    {
        return SDKCall<bool>("isSupportAccountCenter");
    }

    public override bool IsSupportLogout()
    {
        return SDKCall<bool>("isSupportLogout");
    }

    public override void StartLevel(string num)
    {
        SDKCall("startLevel", num);
    }

    public override void FinishLevel(string num)
    {
        SDKCall("finishLevel", num);
    }

    public override void FailLevel(string num)
    {
        SDKCall("failLevel", num);
    }

    public override void UserUseBoosterInfo(string item, int num, double price)
    {
        SDKCall("userUseBoosterInfo", item, num, price);
    }

    public override void UserBuyBoosterInfo(string item, int num, double price)
    {
        SDKCall("userBuyBoosterInfo", item, num, price);
    }

    public override void UserCustomEvent(string eventName)
    {
        SDKCall("userCustomEvent", eventName);
    }

	public override void ExchangeGift(string code)
	{
		SDKCall("exchangeGift", code);
	}

	public override void UploadUserInfo(string level, string buff, string coin)
	{
		SDKCall("setUserInfo", level, buff, coin);
	}

	public override void GetDownloadUrl(string partID)
	{
		SDKCall("getDownloadUrl", partID);
	}

	public override bool GetElectFlag()
	{
		return SDKCall<bool>("getElectFlag");
	}

	public override void ShowElect(string partName)
	{
		SDKCall("showElect",partName);
	}

	public override void PushMsg(String ticker, String title, String content)
	{
		SDKCall("pushMsg", ticker, title, content);
	}

	public override void SetPropDeliveredComplete(string orderID)
	{
		SDKCall("setPropDeliveredComplete", orderID);
	}
    public override void GetRankInfos()
    {
         SDKCall("getRankInfos");
    }
    public override void UploadRankInfo(string name, string type, int level)
    {
        SDKCall("uploadRankInfo", name, type, level);
    }

    private string encodeGameData(ASCExtraGameData data)
    {
        Dictionary<string, object> map = new Dictionary<string, object>();
        map.Add("dataType", data.dataType);
        map.Add("roleID", data.roleID);
        map.Add("roleName", data.roleName);
        map.Add("roleLevel", data.roleLevel);
        map.Add("serverID", data.serverID);
        map.Add("serverName", data.serverName);
        map.Add("moneyNum", data.moneyNum);
        map.Add("roleCreateTime", data.roleCreateTime);
        map.Add("roleLevelUpTime", data.roleLevelUpTime);
        return MiniJSON.Json.Serialize(map);
    }

    private string encodePayParams(ASCPayParams data)
    {
        Dictionary<string, object> map = new Dictionary<string, object>();
        map.Add("productId", data.productId);
        map.Add("productName", data.productName);
        map.Add("productDesc", data.productDesc);
        map.Add("price", data.price);
        map.Add("buyNum", data.buyNum);
        map.Add("coinNum", data.coinNum);
        map.Add("serverId", data.serverId);
        map.Add("serverName", data.serverName);
        map.Add("roleId", data.roleId);
        map.Add("roleName", data.roleName);
        map.Add("roleLevel", data.roleLevel);
        map.Add("payNotifyUrl", data.payNotifyUrl);
        map.Add("vip", data.vip);
        map.Add("extension", data.extension);
        return MiniJSON.Json.Serialize(map);
    }

    private string encodeShareParams(ShareParams shareParams)
    {
        Dictionary<string, object> map = new Dictionary<string, object>();
        map.Add("title", shareParams.title);
        map.Add("content", shareParams.content);
        map.Add("dialogMode", shareParams.dialogMode);
        map.Add("sourceName", shareParams.sourceName);
        map.Add("sourceUrl", shareParams.sourceUrl);
        map.Add("titleUrl", shareParams.titleUrl);
        map.Add("url", shareParams.url);
        return MiniJSON.Json.Serialize(map);
    }
} 

//#endif