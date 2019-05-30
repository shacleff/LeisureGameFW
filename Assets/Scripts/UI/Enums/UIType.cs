using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 窗体类型 （引用窗体的重要属性[枚举类型]）
/// </summary>
public class UIType
{
    /// <summary>
    /// 是否清掉栈集合
    /// </summary>
    public bool IsClearStack { get; set; }
    public UIPanelType PanelType { get; set; }
    public UIPanelShowMode PanelShowMode { get; set; }
    public UIPanelLucenyType PanelLucenyType { get; set; }

    public UIType()
    {
        PanelType = UIPanelType.Normal;
        PanelShowMode = UIPanelShowMode.Normal;
        PanelLucenyType = UIPanelLucenyType.Lucency;
    }
}

