using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.FSM
{
    public class IFSMManager : MonoBehaviour
    {

        public Dictionary<string, IState> stateNameToValue;
        

        public virtual void ChangeState(string _newStateName)
        {

        }
    }
}


