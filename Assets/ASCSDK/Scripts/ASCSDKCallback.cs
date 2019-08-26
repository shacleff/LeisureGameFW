using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

//动态价格参数设置
public class PointConfiglist
{
	//道具数量
	//Item number
	public int Quantity { set; get; }
	//id
	//id
	public int BillingPoint { set; get; }
	//价格
	//Price
	public int Price { set; get; }
}


/// <summary>
/// ASCSDK 回调 Android和IOS走同样的回调接口，保证接口的统一性
/// The ASCSDK calls back Android and IOS to follow the same callback interface to ensure the uniformity of the interface.
/// </summary>
public class ASCSDKCallback : MonoBehaviour
{

    private static ASCSDKCallback _instance;

    private static object _lock = new object();


    //初始化回调对象
    //Initializes the callback object.
    public static ASCSDKCallback InitCallback()
    {
        UnityEngine.Debug.LogError("Callback->InitCallback");

        lock (_lock)
        {
            if (_instance == null)
            {
                GameObject callback = GameObject.Find("(ascsdk_callback)");
                if (callback == null)
                {
                    callback = new GameObject("(ascsdk_callback)");
                    _instance = callback.AddComponent<ASCSDKCallback>();
                    UnityEngine.Object.DontDestroyOnLoad(callback);

                }
                else
                {
                    _instance = callback.GetComponent<ASCSDKCallback>();
                }
            }

            return _instance;
        }
    }


    //初始化成功回调
    //Initializing a successful callback.
    public void OnInitSuc()
    {
        //一般不需要处理
        //You don't have to deal with it.
        UnityEngine.Debug.LogError("Callback->OnInitSuc");
        ASCSDKInterface.Instance.Login();
    }

    //登录成功回调
    //Login successfully callback.
    public void OnLoginSuc(string jsonData)
    {
        UnityEngine.Debug.LogError("Callback->OnLoginSuc");

        ASCLoginResult data = parseLoginResult(jsonData);
        if (data == null)
        {
            UnityEngine.Debug.LogError("The data parse error." + jsonData);
            return;
        }

        if (ASCSDKInterface.Instance.OnLoginSuc != null)
        {
            ASCSDKInterface.Instance.OnLoginSuc.Invoke(data);
        }
    }

    //切换帐号回调
    //Switch account callback.
    public void OnSwitchLogin()
    {

        UnityEngine.Debug.LogError("Callback->OnSwitchLogin");

        if (ASCSDKInterface.Instance.OnLogout != null)
        {
            ASCSDKInterface.Instance.OnLogout.Invoke();
        }
    }

    //登出回调
    //Logout callback
    public void OnLogout()
    {
        UnityEngine.Debug.LogError("Callback->OnLogout");

        if (ASCSDKInterface.Instance.OnLogout != null)
        {
            ASCSDKInterface.Instance.OnLogout.Invoke();
        }
    }
    //排行榜回调
    //???
    public void OnGetRankInfo(string jsonData)
    {
        UnityEngine.Debug.LogError("OnGetRankInfo  :  " + jsonData);
        if (jsonData !="" && jsonData != null)
        {
            ASCSDKInterface.Instance.OnGetRankInfo?.Invoke(jsonData);
        }
        //object jsonParsed = MiniJSON.Json.Deserialize(jsonData);
        //if (jsonParsed != null)
        //{
        //    Dictionary<string, object> jsonMap = jsonParsed as Dictionary<string, object>;
        //    if (jsonMap.ContainsKey("videoResult"))
        //    {
        //        int videoResult = int.Parse(jsonMap["videoResult"].ToString());//示例
        //    }
        //}
    }

    /// <summary>
    /// 此方法为看视频回调接口
    /// This method looks at the video callback interface.
    /// </summary>值为1是为成功，0为失败
    public void OnPlayVideoSuc(string jsonData)
    {
        
        object jsonParsed = MiniJSON.Json.Deserialize(jsonData);
        int videoResult = 0;
        if (jsonParsed != null)
        {
            Dictionary<string, object> jsonMap = jsonParsed as Dictionary<string, object>;
            if (jsonMap.ContainsKey("videoResult"))
            {
                videoResult = int.Parse(jsonMap["videoResult"].ToString());
            }
        }
        if (videoResult == 1)
        {
            //成功
            if (ASCSDKInterface.Instance.OnVideoCallBack != null)
            {
                Debug.Log("ASCSDKInterface.Instance.OnVideoCallBack SUCCEED");
                ASCSDKInterface.Instance.OnVideoCallBack.Invoke(CallBackStatus.SUCCEED);
            }
        }
        else
        {
            //失败
            if (ASCSDKInterface.Instance.OnVideoCallBack != null)
            {
                ASCSDKInterface.Instance.OnVideoCallBack.Invoke(CallBackStatus.FAILURE);
            }
        }
        ASCSDKInterface.Instance.NativeLog("OnPlayVideoSuc:" + "The OnPlayVideoSuc video Result = " + videoResult);

    }


    //支付回调，网游不需要实现该接口，该接口用于单机游戏
    //To pay the callback, the online game does not need to implement the interface, which is used for stand-alone games.
    public void OnPaySuc(string jsonData)
    {
        object jsonParsed = MiniJSON.Json.Deserialize(jsonData);
        int payResult = -1;
		int productId = -1;
		string orderID ="";
		if (jsonParsed != null)
        {
            Dictionary<string, object> jsonMap = jsonParsed as Dictionary<string, object>;
            if (jsonMap.ContainsKey("payResult"))
            {
                payResult = int.Parse(jsonMap["payResult"].ToString());
            }
            if (jsonMap.ContainsKey("productId"))
            {
				productId = int.Parse(jsonMap["productId"].ToString());
            }
			if (jsonMap.ContainsKey("orderID"))
			{
				orderID = jsonMap["orderID"].ToString();
			}
		}

        if (payResult == 0)
        {
            //成功
            if (ASCSDKInterface.Instance.OnPayCallBack != null)
            {
                ASCSDKInterface.Instance.OnPayCallBack.Invoke(CallBackStatus.SUCCEED, productId);
				ASCSDKInterface.Instance.SetPropDeliveredComplete(orderID);
			}
        }
        else
        {
            //失败
            if (ASCSDKInterface.Instance.OnPayCallBack != null)
            {
                ASCSDKInterface.Instance.OnPayCallBack.Invoke(CallBackStatus.FAILURE, productId);
            }
        }
        //productId 购买道具的id,根据此id下发道具，支付时传入对应的道具id
        //ProductId buys the id of the prop, then sends the prop according to this id, and passes in the corresponding prop id when payment is made.
    }
    private ASCLoginResult parseLoginResult(string str)
    {
        object jsonParsed = MiniJSON.Json.Deserialize(str);
        if (jsonParsed != null)
        {
            Dictionary<string, object> jsonMap = jsonParsed as Dictionary<string, object>;
            ASCLoginResult data = new ASCLoginResult();
            if (jsonMap.ContainsKey("isSuc"))
            {
                data.isSuc = bool.Parse(jsonMap["isSuc"].ToString());
            }
            if (jsonMap.ContainsKey("isSwitchAccount"))
            {
                data.isSwitchAccount = bool.Parse(jsonMap["isSwitchAccount"].ToString());
            }
            if (jsonMap.ContainsKey("userID"))
            {
                data.userID = jsonMap["userID"].ToString();
            }
            if (jsonMap.ContainsKey("sdkUserID"))
            {
                data.sdkUserID = jsonMap["sdkUserID"].ToString();
            }
            if (jsonMap.ContainsKey("username"))
            {
                data.username = jsonMap["username"].ToString();
            }

            if (jsonMap.ContainsKey("sdkUsername"))
            {
                data.sdkUsername = jsonMap["sdkUsername"].ToString();
            }
            if (jsonMap.ContainsKey("token"))
            {
                data.token = jsonMap["token"].ToString();
            }

            return data;
        }

        return null;
    }

	//礼包回调
	public void OnGetGiftInfo(string jsonData)
	{
		ASCSDKInterface.Instance.NativeLog("OnGetGiftInfo:" + jsonData);
		object jsonParsed = MiniJSON.Json.Deserialize(jsonData);
		if (jsonParsed != null)
		{
			Dictionary<string, object> jsonMap = jsonParsed as Dictionary<string, object>;
			String msg = "";
			int propNumber = 0;
			string propType = "";
			if (jsonMap.ContainsKey("propNumber"))
			{
				propNumber = int.Parse(jsonMap["propNumber"].ToString());
			}
			if (jsonMap.ContainsKey("msg"))
			{
				msg = jsonMap["msg"].ToString();
			}
			if (jsonMap.ContainsKey("propType"))
			{
				propType= jsonMap["propType"].ToString();
			}
			if (ASCSDKInterface.Instance.OnGetGiftInfo != null)//Golds or Diamonds or .....
			{
				ASCSDKInterface.Instance.OnGetGiftInfo.Invoke(propNumber, msg, propType);
				ASCSDKInterface.Instance.NativeLog("OnGetGiftInfo成功回调unity方法:"+ propNumber+ msg+ propType);
			}
		}
	}


	//动态修改价格
	public void OnGetProductInfo(string jsonData)
	{
		object jsonParsed = MiniJSON.Json.Deserialize(jsonData);
		if (jsonParsed != null)
		{
			ASCSDKInterface.Instance.PointConfig = new List<PointConfiglist>();
			Dictionary<string, object> jsonMap = jsonParsed as Dictionary<string, object>;
			if (jsonMap.ContainsKey("pointConfiglist"))
			{
				List<object> awardList = jsonMap["pointConfiglist"] as List<object>;
				foreach (var item in awardList)
				{
					Dictionary<string, object> dictAward = item as Dictionary<string, object>;
					PointConfiglist point = new PointConfiglist();
					if (dictAward.ContainsKey("quantity"))
					{
						point.Quantity = int.Parse(dictAward["quantity"].ToString());
					}
					if (dictAward.ContainsKey("billingPoint"))
					{
						point.BillingPoint = int.Parse(dictAward["billingPoint"].ToString());
					}
					if (dictAward.ContainsKey("price"))
					{
						point.Price = int.Parse(dictAward["price"].ToString());
					}
					ASCSDKInterface.Instance.PointConfig.Add(point);
				}
			}
			ASCSDKInterface.Instance.NativeLog("OnGetProductInfo:" + jsonData);
			if (ASCSDKInterface.Instance.OnPriceData != null) ASCSDKInterface.Instance.OnPriceData.Invoke();
		}
	}
}