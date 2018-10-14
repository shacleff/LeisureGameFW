using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.FSM;
using System;
using UnityEngine.UI;

public class WalkState : IState
{
    public event EventHandler<StateBeginEventArgs> OnBeginExit;

    public void BeginEnter()
    {
        GameObject obj = GameObject.Find("Canvas/Attack");
        //obj.GetComponent<Button>().onClick.AddListener(() => SwitchState());
        Debug.Log("WalkState Begin enter");
    }

    public void EndEnter()
    {
        Debug.Log("WalkState end enter");
    }

    public void EndExit()
    {
        Debug.Log("WalkState end exit");
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
        var state = new AttackState();
        var trans = new StateTransition();
        var eventArgs = new StateBeginEventArgs(state, trans);
        OnBeginExit(this, eventArgs);
    }
}
