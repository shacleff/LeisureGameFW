﻿using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utility;

public class BagPanel : BasePanel
{

    public override void Awake()
    {
        base.Awake();
        //Messenger.AddListener(ELocalMsgID.USER_DATA_
    }

    // Use this for initialization
    public override void Start()
    {
        base.Start();
    }

    protected override void ClosePanelHandle(GameObject go)
    {
        base.ClosePanelHandle(go);
    }


    public void OpenBackPanel()
    {
    }

    public void CancelBackpanel()
    {
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void CreateGunSelect()
    {
    }

    


}


