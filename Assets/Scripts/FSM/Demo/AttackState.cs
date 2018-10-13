﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.FSM;
using System;
using UnityEngine.UI;

public class AttackState : IState
{
    public event EventHandler<StateBeginEventArgs> OnBeginExit;

    public void BeginEnter()
    {
        GameObject obj = GameObject.Find("Canvas/Idle");
        obj.GetComponent<Button>().onClick.AddListener(() => SwitchState());
        Debug.Log("AttackState Begin enter");
    }

    public void EndEnter()
    {
        Debug.Log("AttackState end enter");
    }

    public void EndExit()
    {
        Debug.Log("AttackState end exit");
    }

    public IEnumerable Execute()
    {
        yield return new WaitForSeconds(1.0f);
    }

    public void SwitchState()
    {
        var state = new IdleState();
        var trans = new StateTransition();
        var eventArgs = new StateBeginEventArgs(state, trans);
        OnBeginExit(this, eventArgs);
    }
}
