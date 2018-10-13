using System;
using System.Collections;
using UnityEngine;

namespace Game.FSM
{
    /// <summary>
    /// 状态接口，每个状态类都要调用此接口
    /// a mode of the app that executes over time
    /// 一种随时间推移而执行的应用程序模式
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// 开始进入此状态
        /// </summary>
        void BeginEnter();
        /// <summary>
        /// 结束进入
        /// </summary>
        void EndEnter();
        /// <summary>
        /// 由StateMachine IEnumerable Execute()方法去执行该方法
        /// </summary>
        IEnumerable Execute();
        /// <summary>
        /// 随着时间的推移，执行状态的逻辑。这个函数应该“返回”，直到它没有什么可做的。
        /// 当它准备好开始过渡到下一个状态时，它也可以分派一个开始退出。如果它这样做了，这个问题就不会再继续了。
        /// Execute the state's logic over time. This function should 'yield return' until it has nothing left to do.
        /// It may also dispatch OnBeginExit when it is ready to begin transitioning to the next state. If it does this, this funtion will no longer be resumed.
        /// </summary>
        event EventHandler<StateBeginEventArgs> OnBeginExit;
        
        /// <summary>
        /// 结束退出状态
        /// </summary>
        void EndExit();
    }
}


