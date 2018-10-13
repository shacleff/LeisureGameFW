using System;

namespace Game.FSM
{
    /// <summary>
    /// 状态过渡事件
    /// Event args that are dispatched when a state wants to transition to another state
    /// 当一个状态想要过渡到另一个状态时，会发出事件args
    /// </summary>
    public class StateBeginEventArgs:EventArgs
    {
        /// <summary>
        /// 下一个要过渡到的状态
        /// </summary>
        public IState NextState;
        /// <summary>
        /// 状态转换器
        /// </summary>
        public IStateTransition iStateTransition;

        public StateBeginEventArgs(IState _state,IStateTransition _iStateTransition)
        {
            this.NextState = _state;
            this.iStateTransition = _iStateTransition;
        }
        
    }

}


