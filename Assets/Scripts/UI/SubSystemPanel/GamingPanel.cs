using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Events;
using System;
using Utility;

public class GamingPanel : BasePanel
{

    private bool isPause = false;

    private Transform UICamera;

    public override void Awake()
    {
        base.Awake();
        mCurrUItype.PanelShowMode = UIPanelShowMode.HideOther;
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
        Pause();
    }

    private void OnApplicationFocus(bool focus)
    {
        isPause = !focus;
        Debug.Log("..................focus " + isPause);
        Pause();
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

    public void Pause()
    {

    }

    public void ContinueGame()
    {

        isPause = false;
    }

    public void BackHomeGame()
    {
        Time.timeScale = 1;
        isPause = false;
    }

    public override void ReShow()
    {
        base.ReShow();
    }

    public override void Show()
    {
        base.Show();


    }

    public override void Start()
    {
        base.Start();

    }

    private void MusicToggle()
    {

    }

    private void WaringAnimation()
    {

    }


    private void OnEnable()
    {
        //Messenger.Broadcast<Transform>(ELocalMsgID.GAME_PALY, transform);
    }

    protected override void BasePanel_onCloseClick(GameObject go)
    {
        base.BasePanel_onCloseClick(go);

    }

    private void GameOver()
    {

    }

}

