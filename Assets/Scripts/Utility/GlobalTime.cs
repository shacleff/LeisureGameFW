using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using System;

public class GlobalTime 
{

	public static void GetLocalTime()
    {

        DateTime dateTime = DateTime.Now;
        //string _time=
        Debug.Log("W now  " + DateTime.Now);        //当前时间（年月日时分秒）  
        Debug.Log("W utc  " + DateTime.UtcNow);     // 当前时间（年月日时分秒）  
        /*Debug.Log("W year  " + System.DateTime.Now.Year);  //当前时间（年）  
        Debug.Log("W month   " + System.DateTime.Now.Month); //当前时间（月）  
        Debug.Log("W day   " + System.DateTime.Now.Day);    // 当前时间(日)  
        Debug.Log("W h    " + System.DateTime.Now.Hour);  // 当前时间(时)  
        Debug.Log("W min   " + System.DateTime.Now.Minute);  // 当前时间(分)  
        Debug.Log("W second   " + System.DateTime.Now.Second); // 当前时间(秒)  */
    }

    public static string GetLocalCountTime(DateTime _prevDateTime)
    {
        //DateTime dateTime = new DateTime(2018, 5, 14,11,00,00);
       // string str = dateTime.ToString();
        TimeSpan timeSpan = DateTime.Now - _prevDateTime;
        double timeDifference = timeSpan.TotalMilliseconds;

        string h =( 3 - timeSpan.Hours).ToString();
        string m = (59 - timeSpan.Minutes).ToString();
        string s = (59 - timeSpan.Seconds).ToString();
        h = "0" + h;
        if (timeSpan.Days > 0) return "00:00:00";
        if (timeSpan.Hours >= 4) return "00:00:00";

        return string.Format("{0}:{1}:{2}",h,m,s);
    }
	
    public static double GetLocalTimeStamp(DateTime _prevDateTime)
    {
        TimeSpan timeSpan = DateTime.Now - _prevDateTime;

        double timeDifference = timeSpan.TotalMinutes;
        return timeDifference;
    }

    public static string GetTimeStampSeconds()
    {
        TimeSpan timespan = DateTime.Now - new DateTime(1997, 1, 1);

        return timespan.TotalSeconds.ToString();
    }

}
