using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TimerManager:Singleton<TimerManager>
{
    private static MonoBehaviour behaviour;
    public delegate void Task();
    private List<TimeItem> timeItems = new List<TimeItem>(); 

    private TimerManager() { }

    public void Init()
    {
        APP.GetInstance().onUpdate += OnUpdateTime;
    }

    private void OnUpdateTime()
    {
        
    }

    public static void StopCoroutine()
    {
        APP.GetInstance().StopAllCoroutines();
    }

    public static Coroutine Schedule(float delay, Task task)
    {
        return APP.GetInstance().StartCoroutine(DoTask(task, delay));
    }

    public static void Schedule(MonoBehaviour _behaviour, float delay, Task task)
    {
        behaviour = _behaviour;
        APP.GetInstance().StartCoroutine(DoTask(task, delay));
    }

    private static IEnumerator DoTask(Task task, float delay)
    {
        yield return new WaitForSeconds(delay);
        task();
    }

    public void AddTime()
    {

    }

    public void DeleteTime()
    {

    }


}

public enum TimeType
{
    Offline,
    Gift,
    Null
}


public class TimeItem
{
    public TimeType CurrType;
    public string Msg;
    public object Target;
}

public enum CountDownType
{
    Skill_1,
    Skill_2,
    Button,
    Null,
}


public class CountDownTimer
{
    private float remainTime;
    public float RemainTime
    {
        get { return remainTime; }
    }
    private int isLoop = 0;
    private bool autoAwake = true;
    private Action<string> updating;
    private Action completeCallback;
    private bool isUpdate = true;
    private bool autoDestroy = false;

    public CountDownTimer(float _duration,int _isloop=0,bool _autoAwake=true)
    {
        remainTime = _duration;
        isLoop = _isloop;
        autoAwake = _autoAwake;
        
    }

    public CountDownTimer(float _duration, int _isloop = 0, bool _autoAwake = true, Action _completeCallback=null)
    {
        remainTime = _duration;
        isLoop = _isloop;
        autoAwake = _autoAwake;
        completeCallback = _completeCallback;
    }

    public CountDownTimer(float _duration, int _isloop = 0, bool _autoAwake = true, Action _completeCallback = null,Action<string> _updating=null)
    {
        remainTime = _duration;
        isLoop = _isloop;
        autoAwake = _autoAwake;
        completeCallback = _completeCallback;
        updating = _updating;
    }

    public CountDownTimer(float _duration, int _isloop = 0, bool _autoAwake = true, Action _completeCallback = null, Action<string> _updating = null, bool _autoDestroy = false)
    {
        
        remainTime = _duration;
        isLoop = _isloop;
        autoAwake = _autoAwake;
        completeCallback = _completeCallback;
        updating = _updating;
        autoDestroy = _autoDestroy;
    }

    public void Start()
    {

    }

    public void UpdateTimer()
    {
        if(isUpdate)
        {
            remainTime -= Time.deltaTime;
            updating?.Invoke(remainTime.ToString());
            if (remainTime <= 0)
            {
                isUpdate = false;
                completeCallback?.Invoke();
                
            }
        }
        
    }
}
