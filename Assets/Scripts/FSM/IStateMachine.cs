using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.FSM
{
    /// <summary>
    /// 状态控制接口类
    /// runs the current state and transitions to the next state
    /// 运行当前状态并过渡到下一个状态
    /// </summary>
    public interface IStateMachine
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable Execute();
    }
}

