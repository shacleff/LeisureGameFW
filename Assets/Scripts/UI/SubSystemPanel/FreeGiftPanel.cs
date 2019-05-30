using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using UnityEngine.UI;

public class FreeGiftPanel : BasePanel
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

    public void ShowGift()
    {

    }


    public override void Start()
    {
        base.Start();
    }

    public void Close()
    {

        base.BasePanel_onCloseClick(gameObject);
    }

    protected override void BasePanel_onCloseClick(GameObject go)
    {
        base.BasePanel_onCloseClick(go);
    }
}


