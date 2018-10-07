using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DesignPattern
{
    /// <summary>
    /// 返回空类型的回调定义
    /// </summary>
    public class VoidDelegate
    {
        /// <summary>
        /// 返回无参数的空类型回调
        /// </summary>
        public delegate void WithVoid();
        /// <summary>
        /// 返回参数为GameObject的空类型回调
        /// </summary>
        public delegate void WithGameObject();
        public delegate void WithParams(params object[] paramList);
        public delegate void WithObjectParam(UnityEngine.Object _object);
        public delegate void WithEvent(BaseEventData data);
    }
}
