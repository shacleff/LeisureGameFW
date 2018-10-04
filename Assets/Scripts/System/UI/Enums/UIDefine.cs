using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlipGun.UI
{

    /// <summary>
    /// 窗体类型
    /// </summary>
    public enum UIPanelType
    {
        Normal,
        Fixed,
        Popup
    }

    /// <summary>
    /// 窗体显示模式
    /// </summary>
    public enum UIPanelShowMode
    {
        /// <summary>
        /// 模式允许多个窗体同时显示，这种类型应用最多
        /// </summary>
        Normal,
        /// <summary>
        ///  一般都大量引用于“弹出窗体”中。此类窗体的特点是：显示弹出窗体时不完全覆盖底层窗体，一般在屏幕的四周会露出底层窗体。之所以命名“反向切换”是因为: 程序员要维护一种“后进先出”的“栈”的数据结构特点，即我们一般要求玩家必须先关闭弹出的顶层窗体，再依次关闭下一级窗体
        /// </summary>
        ReverseChange,
        /// <summary>
        /// 模式一般应用于全局性的窗体。我们在开发此类窗体时，为了减少UI渲染压力、提高Unity渲染效率，则设置被覆盖的窗体为“不可见”状态。（即： this.gameObject.SetActive(false)）。例如一般的登录窗体、选择英雄窗体等
        /// </summary>
        HideOther
    }

    /// <summary>
    /// 窗体透明度
    /// </summary>
    public enum UIPanelLucenyType
    {
        /// <summary>
        /// 完全透明，不能穿透
        /// </summary>
        Lucency,
        /// <summary>
        /// 半透明，不能穿透
        /// </summary>
        Translucence,
        /// <summary>
        /// 低透明度，不能穿透
        /// </summary>
        ImPenetrable,
        /// <summary>
        /// 可以穿透
        /// </summary>
        Pentrate
    }

    /// <summary>
    /// 系统定义类（包含框架中使用到的枚举类型、委托事件、系统常量、接口等）
    /// </summary>
    public class UIDefine
    {
        public static readonly string TOP_CANVAS_NAME = "Canvas";
        public static readonly string UI_NORMAL = "Normal";
        public static readonly string UI_FIXED = "Fixed";
        public static readonly string UI_POPUP = "Popup";
        public static readonly string UI_TOP = "Top";
    }

}

