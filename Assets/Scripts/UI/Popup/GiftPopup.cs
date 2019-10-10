﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 所有弹窗应该由一个类统一管理弹出，这样不会造成多个弹窗出现由此带来的不必要的冲突
/// </summary>
public class GiftPopup : BasePopup
{
    public override void Awake()
    {
        base.Awake();
        this.popupType = PopupType.GiftBag;
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void Exit()
    {
        base.Exit();
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }
}