using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.FSM;
using System;
using UnityEngine.UI;

public class IdleState : IState
{
    public event EventHandler<StateBeginEventArgs> OnBeginExit;

    public void BeginEnter()
    {
       
        Debug.Log("Idle Begin enter");
    }

    public void EndEnter()
    {
        Debug.Log("Idle end enter");
    }

    public void EndExit()
    {
        Debug.Log("Idle end exit");
    }

    public IEnumerable Execute()
    {
        yield return new WaitForSeconds(1.0f);
    }

    public void OnBeginExitEvent(StateBeginEventArgs eventArgs)
    {
        OnBeginExit(this, eventArgs);
    }

    public void SwitchState()
    {
        var state = new WalkState();
        var trans = new StateTransition();
        var eventArgs = new StateBeginEventArgs(state, trans);
        OnBeginExit(this, eventArgs);
    }
}
