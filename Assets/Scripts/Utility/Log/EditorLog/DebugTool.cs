using UnityEngine;
using System.Collections;
using System.Diagnostics;


namespace JoeyGame
{
    public interface IDebugTool
    {
        void Trace();
    }

    public class DebugTool
    {
       
        public static void Trace(params object[] objs)
        {
            
        }
    }

    

}

