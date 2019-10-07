using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// 每日签到系统
/// </summary>
public class CheckInManager : MonoSingleton<CheckInManager>
{
    public static string CHECK_IN_INFO = "checkin_info";
    public static string LOGIN_DAY_COUNT = "login_day_count";
    public static string LAST_LOGIN_DATE = "last_login_date";
    public Sprite[] DaySprites;
    private DateTime LastDate;
    /// <summary>
    /// 已经登录的天数
    /// </summary>
    private int hadDays;

    private CheckInManager() { }


    // Start is called before the first frame update
    void Start()
    {
        string lastDateStr=PlayerPrefs.GetString(LAST_LOGIN_DATE, "");
        //string _hadDayStr= PlayerPrefs.GetString(LAST_LOGIN_DATE, "");
        LastDate = lastDateStr == "" ? DateTimeUtility.Now() :JsonHelper.Deserialize<DateTime>(lastDateStr);
        hadDays= int.Parse(PlayerPrefs.GetString(LOGIN_DAY_COUNT, "0"));
    }

    public void CheckIn()
    {
        EventManager.Instance.DispatchEvent(CHECK_IN_INFO, DaySprites);
        //UIResourceManager.GetInstance().OpenCheckInPopup(DaySprites);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            CheckIn();
        }
    }
}
