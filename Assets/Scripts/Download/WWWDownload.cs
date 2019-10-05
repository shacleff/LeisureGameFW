using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class WWWDownload:Singleton<WWWDownload>
{
    private WWWDownload() { }

    /// <summary>
    /// 异步加载资源，加载的资源通过event发布事件
    /// </summary>
    /// <param name="_path">路径</param>
    public void Download(string _path)
    {
         APP.GetInstance().StartCoroutine(StartDownload(_path));
    }

    /// <summary>
    /// 加载文本文件（回调函数为string类型）
    /// 异步加载资源，加载完成调用完成委托
    /// </summary>
    /// <param name="_path">路径</param>
    /// <param name="completeCallback">加载完成委托</param>
    public void Download(string _path,Action<string> completeCallback)
    {
        APP.GetInstance().StartCoroutine(StartDownload(_path, completeCallback));
    }

    /// <summary>
    /// 加载资源（回调参数为object类型）
    /// 异步加载资源，加载完成调用完成委托
    /// </summary>
    /// <param name="_path">路径</param>
    /// <param name="CompleteCallback">加载完成委托</param>
    public void Download(string _path,Action<object> CompleteCallback)
    {
        APP.GetInstance().StartCoroutine(StartDownload(_path,CompleteCallback));
    }

    #region Asyc Download 

    /// <summary>
    /// 异步加载资源，加载的资源通过event发布事件
    /// </summary>
    /// <param name="path">路径</param>
    /// <returns></returns>
    private IEnumerator StartDownload(string path)
    {
        WWW www = new WWW(path);
        yield return www;
        EventManager.Instance.DispatchEvent(EventArg.UI_CONFIG, www.text);
    }

    /// <summary>
    /// 加载文本文件（回调函数为string类型）
    /// 异步加载资源，加载完成调用完成委托
    /// </summary>
    /// <param name="_path">路径</param>
    /// <param name="completeCallback">加载完成委托</param>
    /// <returns></returns>
    private IEnumerator StartDownload(string _path, Action<string> completeCallback)
    {
        WWW www = new WWW(_path);
        yield return www;
        completeCallback(www.text);
    }

    /// <summary>
    /// 加载资源（回调参数为object类型）
    /// 异步加载资源，加载完成调用完成委托
    /// </summary>
    /// <param name="_path">路径</param>
    /// <param name="CompleteCallback">加载完成委托</param>
    /// <returns></returns>
    private IEnumerator StartDownload(string _path, Action<object> CompleteCallback)
    {
        WWW www = new WWW(_path);
        yield return www;
        CompleteCallback(www);
    }

    #endregion



}
