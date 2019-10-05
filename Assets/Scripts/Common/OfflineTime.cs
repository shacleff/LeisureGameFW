using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OfflineTime:Singleton<OfflineTime>
{
    public static string OFFLINE_TIME = "offline_time";

    private float timer = 0;
    public double OfflineDuration { get; set; }

    private OfflineTime() {
        APP.GetInstance().onUpdate += UpdateTime;
    }

    public double CheckOffline()
    {
        OfflineDuration = GetSecondsOffset();
        return OfflineDuration;
    }

    // Update is called once per frame
    void UpdateTime()
    {
        timer += Time.deltaTime;
        if(timer>1)
        {
            timer = 0;
            SaveTime();
        }
    }

    public void SaveTime()
    {
        PlayerPrefs.SetString(OFFLINE_TIME, DateTimeUtility.Now().ToString());
    }

    public DateTime GetLastTime()
    {
        DateTime lastTime;
        string timeStr=PlayerPrefs.GetString(OFFLINE_TIME);
        if(DateTime.TryParse(timeStr,out lastTime))
        {
            return lastTime;
        }
        return DateTimeUtility.Now();
    }

    /// <summary>
    /// 获取时间差，单位秒
    /// </summary>
    /// <returns></returns>
    public double GetSecondsOffset()
    {
        return (DateTimeUtility.Now() - GetLastTime()).TotalSeconds;
    }

    /// <summary>
    /// 获取时间差，单位分钟
    /// </summary>
    /// <returns></returns>
    public double GetMinutesOffset()
    {
        return (DateTimeUtility.Now() - GetLastTime()).TotalMinutes;
    }

    /// <summary>
    /// 获取时间差，单位时钟
    /// </summary>
    /// <returns></returns>
    public double GetHoursOffset()
    {
        return (DateTimeUtility.Now() - GetLastTime()).TotalHours;
    }
}
