using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.FSM;
using System;

/// <summary>
///基本状态机完成，转换测试完成，存在问题：现在只能单向转换，Idle->Walk->Attack->Idle轮回   
/// </summary>
public class FSMTest : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        IdleState idle = new IdleState();
        StateMachine machine = new StateMachine(idle);
        StartCoroutine(machine.Execute().GetEnumerator());

    }
    
    void Update ()
    {
		
	}
}
