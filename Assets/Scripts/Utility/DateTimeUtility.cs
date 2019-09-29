/**
 * 
 * Author:JoeyHuang
 * Time: 2019/9/29 9:40:50
 * 说明：
 */

using System;
public class DateTimeUtility
{
    public enum TimeFormat
    {
        D_H_M_S,
        H_M_S,
        M_S,
        S
    }


    public static DateTime Now()
    {
        return UnbiasedTime.Instance.Now();
    }

    public static string TimeCountDown(DateTime lastTime,float timer)
    {
        return TimeString(lastTime.AddSeconds(timer).Subtract(Now()).TotalSeconds,TimeFormat.M_S);
    }

    public static string TimeString(double _totalSecond,TimeFormat timeFormat = TimeFormat.H_M_S)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(_totalSecond);
        string dStr = timeSpan.Days < 10 ? "0" + timeSpan.Days : timeSpan.Days.ToString();
        string hStr = timeSpan.Hours < 10 ? "0" + timeSpan.Hours : timeSpan.Hours.ToString();
        string mStr = timeSpan.Minutes < 10 ? "0" + timeSpan.Minutes : timeSpan.Minutes.ToString();
        string sStr = timeSpan.Seconds < 10 ? "0" + timeSpan.Seconds : timeSpan.Seconds.ToString();
        string _format = string.Format("{0}:{1}:{2}", hStr, mStr, sStr);
        switch (timeFormat)
        {
            case TimeFormat.D_H_M_S:
                _format = string.Format("{0}:{1}:{2}:{3}", dStr, hStr, mStr, sStr);
                break;
            case TimeFormat.H_M_S:
                _format = string.Format("{0}:{1}:{2}",  hStr, mStr, sStr);
                break;
            case TimeFormat.M_S:
                _format = string.Format("{0}:{1}", mStr, sStr);
                break;
            case TimeFormat.S:
                break;
            default:
                break;
        }

        return _format;
    }


}
