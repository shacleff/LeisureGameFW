using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.FSM
{
    public class FSMManager : IFSMManager
    {
        public FSMManager()
        {

        }

        public override void ChangeState(string _newStateName)
        {
            base.ChangeState(_newStateName);
            IState _state = null;
            if(stateNameToValue.TryGetValue(_newStateName,out _state))
            {

            }
        }
    }

}


