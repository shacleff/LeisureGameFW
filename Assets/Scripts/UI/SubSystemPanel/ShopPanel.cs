﻿using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utility;

public class ShopPanel : BasePanel
{


    public override void Awake()
    {
        base.Awake();
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

    public override void Show()
    {
        base.Show();


    }

    public override void Start()
    {
        base.Start();
        //Init();
    }


    public void SeeAds()
    {

    }

    private void VideoCallBack(string arg1)
    {

    }




    public void CancelAds()
    {

    }

    public void PayCoin()
    {

    }

    public void PayGun()
    {


    }


    protected override void ClosePanelHandle(GameObject go)
    {
        base.ClosePanelHandle(go);
    }
}

