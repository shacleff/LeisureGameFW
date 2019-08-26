using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// ASCSDK Unity 统一调用单例接口
/// ASCSDK Unity Singleton interface
/// </summary>
public abstract class ASCSDKInterface{
    //登陆回调
    public delegate void LoginSucHandler(ASCLoginResult data);
    //登出回调
    public delegate void LogoutHandler();
    //视频回调
    public delegate void VideoHandler(CallBackStatus status);
    //排行榜回调
    public delegate void RankInfo(string str);
    //支付回调
    public delegate void PayHandler(CallBackStatus status,int productId);
	//礼包回调
	public delegate void GetGiftInfo(int propNumber, string msg,string type);
	//获取后台价格回调
	public delegate void PriceData();
	//单例
	private static ASCSDKInterface _instance;
	//动态修改价格
	public List<PointConfiglist> PointConfig;

	public  LoginSucHandler OnLoginSuc;
    public  LogoutHandler OnLogout;
    public  VideoHandler OnVideoCallBack;
    public  RankInfo OnGetRankInfo;
    public  PayHandler OnPayCallBack;
	public  GetGiftInfo OnGetGiftInfo;
	public PriceData OnPriceData;
	public static ASCSDKInterface Instance
    {
        get
        {
            if (_instance == null)
            {
#if UNITY_ANDROID
                _instance = new SDKInterfaceAndroid();
#endif
            }
            return _instance;
        }
    }

    //初始化
    //initialize
    public virtual void Init()
    {
        ASCSDKCallback.InitCallback();
    }


	/// <summary>
	/// 根据计费点获取价格，无则返回默认值(Get the price by id Billing Point, and return the default value if none)
	/// </summary>
	/// <param name="x">计费点</param>
	/// <param name="defaultPrice"> 默认价格（default value）</param>
	/// <returns></returns>
	public int GetPriceData(int x, int defaultPrice)
	{
		if (PointConfig != null && PointConfig.Count > 0)
			for (int i = 0; i < PointConfig.Count; i++)
			{
				if (PointConfig[i].BillingPoint == x)
					return PointConfig[i].Price;
			}
		return defaultPrice;
	}

	/// <summary>
	/// 根据计费点获取道具数量，无则返回默认值(Get the price by Billing Point, and return the default value if none)
	/// </summary>
	/// <param name="x">计费点</param>
	/// <param name="defaultPrice"> 默认数量（default value）</param>
	/// <returns></returns>
	public int GetQuantityData(int x, int defaultPrice)
	{
		if (PointConfig != null && PointConfig.Count > 0)
			for (int i = 0; i < PointConfig.Count; i++)
			{
				if (PointConfig[i].BillingPoint == x)
					return PointConfig[i].Quantity;
			}
		return defaultPrice;
	}
	//登录
	//Login
	public abstract void Login();

    //展示横幅
    //Show Banner
    public abstract void ShowBanner();

    //展示插屏
    //Show Inters
    public abstract void ShowInters();

    //展示开屏
    //Show Splash
    public abstract void ShowSplash();

    //展示视频
    //Show Video
    public abstract void ShowVideo();

	//隐藏横幅
	//Hide Banner
	public abstract void HideBanner();

	//获取插屏标识。为ture则表示允许show该广告
	//Get the screen identification.
	public abstract bool GetIntersFlag();

    //获取开屏标识。为ture则表示允许show该广告
    //Get the open screen identification.
    public abstract bool GetSplashFlag();

    //获取视频标识。为ture则表示允许show该广告
    //Get video identification.
    public abstract bool GetVideoFlag();

	//获取评价标识
	//Get Rate identification.
	public abstract bool GetRateFlag();

	//登出
	//log out
	public abstract bool Logout();

    //显示个人中心
    //Display individual center
    public abstract bool ShowAccountCenter();

    //上传游戏数据
    //Upload game data
    public abstract void SubmitGameData(ASCExtraGameData data);

    //调用SDK的退出确认框,返回false，说明SDK不支持退出框，游戏需要使用自己的退出框
    //Call the exit confirmation box of the SDK, return false, indicating that the SDK does not support the exit confirmation box, and the game needs to use its own exit confirmation box.
    public abstract bool SDKExit();

    //调用SDK支付界面
    //Call the SDK payment interface.
    public abstract void Pay(ASCPayParams data);

    //SDK是否支持退出确认框
    //Call the SDK payment interface.
    public abstract bool IsSupportExit();

    //SDK是否支持用户中心
    //Whether to support the user center.
    public abstract bool IsSupportAccountCenter();

    //SDK是否支持登出
    //Whether to support logout.
    public abstract bool IsSupportLogout();

    //评价
    //evaluate
    public abstract void Evaluation();

    //安卓端打印日志
    //Print Log
    public abstract void NativeLog(string str);

    //分享
    //share
    public abstract void Share(ShareParams shareParams);

    //开始关卡
    //Starting level
    public abstract void StartLevel(string num);

    //胜利关卡
    //Victory gate
    public abstract void FinishLevel(string num);

	//是否允许互推
	//Whether mutual push is allowed
	public abstract bool GetElectFlag();

	//展示互推
	//show elect
	public abstract void ShowElect(string partName);

	//加载OBB
	//load obb
	public abstract void GetDownloadUrl(string partID);

	//推送消息
	//push notification
	public abstract void PushMsg(string ticker, string title, string content);

	//通知服务器道具下发成功(用于确认道具下发成功)
	//Notify the server that the prop has been successfully delivered
	public abstract void SetPropDeliveredComplete(string orderId);

	//失败关卡
	//Failure levels
	public abstract void FailLevel(string num);

    //道具使用统计 item:道具名字，num：消耗数量，price：需要的金币
    //Item: property name, num: consumption amount, price: needed gold COINS
    public abstract void UserUseBoosterInfo(string item, int num, double price);

    //道具购买统计 item:道具名字，num：购买数量，price：需要的金币
    //Item: item name, num: number of items purchased, price: needed gold COINS
    public abstract void UserBuyBoosterInfo(string item, int num, double price);

    //自定义事件 eventName：自定义事件名字（由另一方实现）
    //Custom event eventName: custom eventName (implemented by the other party)
    public abstract void UserCustomEvent(string eventName);

	//礼包兑换,为0的话为调用demo的界面
	//GIFT EXCHANGE
	public abstract void ExchangeGift(string code);

	//上传用户游戏参数，level->玩家当前通关最高关卡,buff->玩家当前道具总量,coin->玩家当前剩余金币数量
	//Upload user game parameters, level-> players currently pass the highest level of clearance, the total number of buff > players' current props, and the number of coin-> players' current remaining gold COINS
	public abstract void UploadUserInfo(string level, string buff, string coin);

    public abstract void ShakePhone(int tm);

    /// <summary>
    /// 排行榜- 上传个人信息
    /// </summary>
    /// <param name="name">个人名称</param>
    /// <param name="type">排行榜类型 distance 距离赛   level 关卡</param>
    /// <param name="level"> 对应排行榜类型的数值</param>
    public abstract void UploadRankInfo(string name,string type, int level);
    //获取排行榜信息
    public abstract void GetRankInfos();
}

/// <summary>
/// 支付接口需要的参数
/// Pay the parameters required for the interface.
/// </summary>
public class ASCPayParams
{
    //游戏中商品ID
    //The product ID in the game
    public string productId { get; set; }

    //游戏中商品名称，比如元宝，钻石...
    //The name of the commodity in the game, such as yuan bao, diamond...
    public string productName { get; set; }

    //游戏中商品描述
    //Description of goods in game.
    public string productDesc { get; set; }

    //价格，单位为元
    //The price is in yuan.
    public int price { get; set; }

    //购买数量,一般都为1.注意下，比如游戏中“100元宝”是一条充值商品，
    //The number of purchases is usually 1. Note that, for example, "100 yuan bao" in the game is a loaded commodity.
    //对应的价格是90元。那么上面price是90元。这里buyNum=1而不是100
    //The corresponding price is 90 yuan. So the price above is 90 yuan. Here, buyNum=1 instead of 100.
    public int buyNum { get; set; }

    //当前玩家身上剩余的虚拟币数量
    //The amount of virtual currency remaining in the current player.
    public int coinNum { get; set; }

    //当前角色所在的服务器ID
    //The server where the current role resides ID
    public string serverId { get; set; }

    //当前角色所在的服务器名称
    //The server name of the current role.
    public string serverName { get; set; }

    //当前角色ID
    //Current role ID
    public string roleId { get; set; }
    
    //当前角色名称
    //Name
    public string roleName { get; set; }

    //当前角色等级
    //Current role level
    public int roleLevel { get; set; }

    //游戏服的支付回调地址，用于接收支付回调通知
    //The payment callback address of the game server is used to receive the payment callback notification.
    public string payNotifyUrl { get; set; }

    //当前角色的vip等级
    //VIP level of the current role.
    public string vip { get; set; }

    //扩展数据， 支付成功回调通知游戏服务器的时候，会原封不动返回这个值
    //Expand the data and pay the successful callback to the game server, returning the value unchanged.
    public string extension { get; set; }
}


/// <summary>
/// 数据上报接口需要的参数
/// The data is reported to the parameters required by the interface.
/// </summary>
public class ASCExtraGameData
{

    public const int TYPE_SELECT_SERVER = 1;        //选择服务器  SelGate
    public const int TYPE_CREATE_ROLE = 2;          //创建角色    Create Character
    public const int TYPE_ENTER_GAME = 3;           //进入游戏    play
    public const int TYPE_LEVEL_UP = 4;				//等级提升    Level Up
    public const int TYPE_EXIT_GAME = 5;			//退出游戏    quit a game

    //调用时机，设置为上面定义的类型，在各个对应的地方调用submitGameData方法
    //Call the time, set to the type defined above, and call the submitGameData method in each corresponding place.
    public int dataType { get; set; }
    
    //角色ID
    //Role ID
    public string roleID { get; set; }
    
    //角色名称
    //Role Name
    public string roleName { get; set; }
    
    //角色等级
    //Role Leve
    public string roleLevel { get; set; }

    //服务器ID
    //server ID
    public int serverID { get; set; }

    //服务器名称
    //server Name
    public string serverName { get; set; }

    //当前角色生成拥有的虚拟币数量
    //The current role generates the number of virtual COINS that are owned.
    public int moneyNum { get; set; }

    //角色创建时间，从1970年到现在的时间，单位秒
    //Character creation time, from 1970 to now, in unit seconds.
    public string roleCreateTime { get; set; }

    //角色等级变化时间，从1970年到现在的时间，单位秒
    //Character level change time.for 1970 to now time ，Unit s
    public string roleLevelUpTime { get; set; }
}

/// <summary>
/// ASCSDK 登录结果
/// </summary>
public class ASCLoginResult
{
    //是否认证成功
    //The certification results
    public bool isSuc { get; set; }

    //当前是否为SDK界面中切换帐号的回调
    //Whether to switch the account callback for the SDK interface currently.
    public bool isSwitchAccount { get; set; }

    //ascserver返回的userID
    //ascserver return userID 
    public string userID { get; set; }

    //渠道SDK的userID
    //store SDK User ID
    public string sdkUserID { get; set; }

    //ascserver返回的用户名
    //ascserver return USer Name
    public string username { get; set; }

    //渠道SDK的用户名
    //store sdk Name
    public string sdkUsername { get; set; }

    //ascserver返回的用于登录认证的凭据
    //ascserver return Credentials for login authentication.
    public string token { get; set; }

}


public class ShareParams
{
    //分享的标题，最大30个字符
    // Shared title, maximum 30 characters.
    public string title { get; set; }

    //标题链接
    // title link
    public string titleUrl { get; set; }

    //分享此内容显示的出处名称
    // share the source name of this content.
    public string sourceName { get; set; }

    //出处链接
    // source link
    public string sourceUrl { get; set; }

    //内容，最大130个字符
    // content, Max. 130 characters.
    public string content { get; set; }

    //链接，微信分享的时候会用到
    // link, WeChat will be used when sharing.
    public string url { get; set; }

    //图片地址
    // picture address
    public string imgUrl { get; set; }

    //是否全屏还是对话框
    // whether full screen or dialog box.
    public bool dialogMode { get; set; }

    //Notification的图标
    //Notification Image
    public int notifyIcon { get; set; }

    //notification的文字
    // notification of text
    public string notifyIconText { get; set; }

    //内容的评论，人人网分享必须参数，不能为空
    // comments on the content, renren shares must be parameters, cannot be empty.
    public string comment { get; set; }

}

public enum CallBackStatus
{
    
    //失败
    FAILURE=0,
    //成功
    SUCCEED = 1,
}