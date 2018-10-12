using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.FSM
{

    public class IFSM<T> where T :class 
    {

        string Name;
        T Ower;
        int FsmStateCount;
        
    }

}


