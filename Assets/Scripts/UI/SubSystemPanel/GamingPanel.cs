using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Events;
using System;
using Utility;

public class GamingPanel : BasePanel
{
    public GameObject pauseBtn;

    private bool isPause = false;
    private Transform UICamera;

    public override void Awake()
    {
        base.Awake();
        mCurrUItype.PanelShowMode = UIPanelShowMode.HideOther;
    }

    public override void Start()
    {
        base.Start();
        EventTriggerListener.Get(pauseBtn).onClick +=PauseHandler;
    }

    private void PauseHandler(GameObject go)
    {
        UIPanelMenu.GetInstance().OpenPausePanel();
    }

    public override void Freeze()
    {
        base.Freeze();
    }

    public override void Hide()
    {
        base.Hide();
    }

    private void OnApplicationPause(bool pause)
    {
        isPause = pause;
        Debug.Log("Pause...............");

    }

    private void OnApplicationFocus(bool focus)
    {
        isPause = !focus;
        Debug.Log("..................focus " + isPause);
       
    }

    private void Update()
    {
        if (!isPause)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Time.timeScale = 1;
            }
        }
    }


    protected override void ClosePanelHandle(GameObject go)
    {
        base.ClosePanelHandle(go);

    }

    private void GameOver()
    {

    }

}

