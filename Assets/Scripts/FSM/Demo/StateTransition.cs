using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.FSM;
using System;

public class StateTransition : IStateTransition
{


    public IEnumerable Enter()
    {
        foreach (var e in TransHandle("enter"))
        {
            yield return e;
        }
    }

    

    public IEnumerable Exit()
    {
        foreach (var e in TransHandle("exit"))
        {
            yield return e;
        }   
    }

    private IEnumerable<object> TransHandle(string arg)
    {
        Debug.Log("start "+arg+" transhandle");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("end "+arg+" transhandle");
    }
}
