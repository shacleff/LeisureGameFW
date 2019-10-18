using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public delegate void CheckInDataRequest();

/// <summary>
/// 每日签到系统
/// 流程：
/// 1、主界面加载完成后，初始化签到管理类
/// 2、打开签到界面，发所有签到信息给总管理类，总管理类再发给签到界面
/// 2、发改天签到的天数给签到界面
/// </summary>
public class CheckInManager : MonoSingleton<CheckInManager>,IManager
{
    public static string CHECK_IN_INFO_EVENT = "check_in_info_event";
    public static string CHECK_IN_VERIFY_EVENT = "check_in_verify_event";
    public static string CHECK_IN_INFO = "checkin_info";
    public static string LOGIN_DAY_COUNT = "login_day_count";
    public static string LAST_LOGIN_DATE = "last_login_date";
    public Sprite[] DaySprites;
    //public List<CheckInItem> datas;
    private DateTime LastDate;
    /// <summary>
    /// 已经登录的天数,获取的数为-1的话，就说明游戏第一次登陆
    /// </summary>
    private int hadDays;
    /// <summary>
    /// 
    /// </summary>
    public List<CheckInItem> datas;

    private CheckInManager() { }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Init()
    {
        string lastDateStr = PlayerPrefs.GetString(LAST_LOGIN_DATE, "");
        //string _hadDayStr= PlayerPrefs.GetString(LAST_LOGIN_DATE, "");
        LastDate = lastDateStr == "" ? DateTimeUtility.Now() : JsonHelper.Deserialize<DateTime>(lastDateStr);
        hadDays = PlayerPrefs.GetInt(LOGIN_DAY_COUNT, -1);
        if(hadDays==-1)
        {

        }
        else
        {
            CheckInCanDisConnect();
        }
        
    }

    public void OpenPopup()
    {
        EventManager.Instance.DispatchEvent(PopupEvent.OPEN_POPUP, new PopupEvent(PopupEvent.OPEN_POPUP, PopupType.CheckIn, datas,UIPath.CHECK_IN_POPUP));
    }

    /// <summary>
    /// 检查每日签到，需要一直连续的
    /// </summary>
    public void CheckInContinuous()
    {
        EventManager.Instance.DispatchEvent(CHECK_IN_INFO, datas);
        //UIResourceManager.GetInstance().OpenCheckInPopup(DaySprites);
    }

    /// <summary>
    /// 检查每日签到，不需要一直连续的
    /// </summary>
    public void CheckInCanDisConnect()
    {

        DateTime now = DateTimeUtility.Now();
        DateTime lastTime24Hour = new DateTime(LastDate.Year, LastDate.Month, LastDate.Day, 23, 59, 59);
        TimeSpan _timeSpan = now.Subtract(lastTime24Hour);
        if (_timeSpan.TotalSeconds>10)
        {
            hadDays++;
            Debug.LogFormat("新的一天。。。。。。。。。。第{0}天", hadDays);
            if(hadDays >= 7)
            {
                hadDays = 0;
            }
            EventManager.Instance.DispatchEvent(CHECK_IN_INFO_EVENT,hadDays);
        }
    }

    public void Save(object param)
    {
        PlayerPrefs.SetString(LAST_LOGIN_DATE, JsonHelper.Serialize(DateTimeUtility.Now()));
        PlayerPrefs.SetInt(LOGIN_DAY_COUNT, hadDays);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            CheckInContinuous();
        }
    }

    
}

[Serializable]
public class CheckInItem
{

    public int id;
    public string name;
    public Sprite sprite;
    public bool isActive;
    public string desc;
}

