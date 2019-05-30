using UnityEngine;
using UnityEngine.UI;
using Events;
using Utility;
using System;
using System.Collections;

public class GameOverPanel : BasePanel
{


    public override void Awake()
    {
        base.Awake();
    }

    private void EvaluationHandle(object param)
    {
        bool flag = (bool)param;
    }

    public override void Start()
    {
        base.Start();
    }

    private void OnEnable()
    {

    }

    /// <summary>
    /// 分享
    /// </summary>
    public void Share()
    {

    }



    private void ResurrectionHandle(string obj)
    {

    }


    /// <summary>
    /// 重玩
    /// </summary>
    public void Replay()
    {

    }

    public override void Show()
    {

    }



    public override void Freeze()
    {
        base.Freeze();
    }

    public override void Hide()
    {
        base.Hide();

    }

    public override void ReShow()
    {
        base.ReShow();
    }



    // Update is called once per frame
    void Update()
    {

    }
}


