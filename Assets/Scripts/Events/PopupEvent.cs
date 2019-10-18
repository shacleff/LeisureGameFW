/**
 * 
 * Author:JoeyHuang
 * Time: 2019/10/16 14:38:22
 * 说明：
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 弹窗事件对象
/// </summary>
public class PopupEvent
{
    public static string OPEN_POPUP="open_popup";
    public static string UPDATE_POPUP="open_popup";

    public string EventName { get; set; }
    public PopupType popupType { get; set; }
    public object Datas { get; set; }
    public string PopupPrefabPath { get; set; }

    public PopupEvent(string _eventName,PopupType _popupType,object _datas,string _popupPrefabPath)
    {
        this.EventName = _eventName;
        this.popupType = _popupType;
        this.Datas = _datas;
        this.PopupPrefabPath = _popupPrefabPath;
    }
}