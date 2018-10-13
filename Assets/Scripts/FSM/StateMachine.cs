using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.FSM
{

    public class StateMachine : IStateMachine
    {
        /// <summary>
        /// 当前状态
        /// </summary>
        private IState state;
        public IState State
        {
            set
            {
                state = value;
                state.OnBeginExit += State_OnBeginExit;
                state.BeginEnter();
            }
            get
            {
                return state;
            }
        }

        /// <summary>
        /// 即将转换成的下一个状态
        /// </summary>
        private IState nextState;
        /// <summary>
        /// 转换器
        /// </summary>
        private IStateTransition transition;

        public StateMachine(IState initState)
        {
            this.State = initState;
            this.State.EndEnter();
        }

        public IEnumerable Execute()
        {
            while(true)
            {
                //当没有过渡转换需要时(transition==null)，返回当前状态(e.Current)
                for (var e= State.Execute().GetEnumerator();transition==null && e.MoveNext();)
                {
                    yield return e.Current;
                }
                while (transition == null) yield return null;
                //停止监听当前状态的转换，防止意外过渡两次
                //Stop listening for the current state to transition This prevents accidentally transitioning twice
                State.OnBeginExit -= State_OnBeginExit;
                //没有下一个状态可以过渡这意味着状态机已经完成了
                //There is no next state to transition to This means the state machine is finished executing
                if (nextState == null) break;
                foreach (var e in transition.Exit())
                {
                    yield return e;
                }
                State.EndExit();
                State = nextState;
                nextState = null;
                foreach (var e in transition.Enter())
                {
                    yield return e;
                }
                transition = null;
                State.EndEnter();
            }
        }

        private void State_OnBeginExit(object sender, StateBeginEventArgs e)
        {
            this.nextState = e.NextState;
            this.transition = e.iStateTransition;
        }
    }
}

