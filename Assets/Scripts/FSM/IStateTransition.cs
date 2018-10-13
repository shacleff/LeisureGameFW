using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.FSM
{
    /// <summary>
    /// 状态转换接口类
    /// the process of moving from one state to another
    /// 从一个状态移动到另一个状态的转换过程
    /// 应用在如果两个状态之间需要某种动画渐变效果时执行
    /// </summary>
    public interface IStateTransition
    {
        IEnumerable Enter();
        IEnumerable Exit();
        
    }
}

