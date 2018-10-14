using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.FSM
{
    /// <summary>
    /// 完成状态机随机转换，不需要顺序
    /// </summary>
    public class FSMManager : IFSMManager
    {
        private StateTransition transition=new StateTransition();
        private IdleState idle = new IdleState();
        private WalkState walk = new WalkState();
        private AttackState attack = new AttackState();
        private StateMachine machine;

        void Start()
        {
            stateNameToValue = new Dictionary<string, IState>();
            stateNameToValue.Add("Idle", idle);
            stateNameToValue.Add("Walk", walk);
            stateNameToValue.Add("Attack", attack);
            machine = new StateMachine(idle);
            
            StartCoroutine(machine.Execute().GetEnumerator());
        }

        public void ToIdle()
        {
            ChangeState("Idle");
        }

        public void ToAttack()
        {
            ChangeState("Attack");
        }

        public void ToWalk()
        {
            ChangeState("Walk");
        }

        public override void ChangeState(string _newStateName)
        {
            base.ChangeState(_newStateName);
            IState _state = null;
            if(stateNameToValue.TryGetValue(_newStateName,out _state))
            {
                var eventargs = GetEventArgs(_state);
                machine.State.OnBeginExitEvent(eventargs);
            }
        }

        private StateBeginEventArgs GetEventArgs(IState state)
        {
            return new StateBeginEventArgs(state, transition);
        }
    }

}


