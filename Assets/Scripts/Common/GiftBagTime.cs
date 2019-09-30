/**
 * 
 * Author:JoeyHuang
 * Time: 2019/9/29 16:01:35
 * 说明：
 */

using System;
using UnityEngine;

public class GiftBagTime:Singleton<GiftBagTime>
{
    private float GiftTime = 600;
    private DateTime lastTime;
    private float timer = 0;
    public string CountDownTime { get; set; }
    public static string GIFT_TIME = "gift_time";


    private GiftBagTime(){}

    public void Init()
    {
        if (PlayerPrefs.GetString(GIFT_TIME, "") == "")
        {
            lastTime = DateTimeUtility.Now();
        }
        else
        {
            lastTime = JsonHelper.Deserialize<DateTime>(PlayerPrefs.GetString(GIFT_TIME));
        }
        App.GetInstance().onUpdate += UpdateTime;
    }


    public void UpdateTime()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            timer = 0;
            if (IsCountDown())
            {
                CountDownTime = DateTimeUtility.TimeCountDown(lastTime, GiftTime); //TimeString(lastTime.AddSeconds(GiftTime).Subtract(DateTimeUtility.Now()).TotalSeconds, GlobalTime.TimeFormat.M_S);
            }
            else
            {
                CountDownTime = "";
            }
            PlayerPrefs.SetString(GIFT_TIME, JsonHelper.Serialize(DateTimeUtility.Now()));
        }
    }

    private bool IsCountDown()
    {
        TimeSpan _timeSpan = DateTimeUtility.Now().Subtract(lastTime);
        if (_timeSpan < TimeSpan.FromSeconds(GiftTime))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}
