using UnityEngine;
using System.Collections;

/// <summary>
/// 弹窗基类，类似于礼包、签到弹窗都通过继承这个类来统一管理游戏的弹窗
/// 所有弹窗应该由一个类统一管理弹出，这样不会造成多个弹窗出现由此带来的不必要的冲突
/// </summary>
public class BasePopup : MonoBehaviour
{
    public PopupType popupType=PopupType.Base;
    /// <summary>
    /// 弹窗优先级，如果有多个弹窗同事出现，越大的数在越前面
    /// </summary>
    public int Priority;


    public virtual void Awake()
    {

    }

    // Use this for initialization
    public virtual void Start()
    {

    }

    public virtual void OnEnable()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    /// <summary>
    /// 进入弹窗，并传入/更新弹窗信息
    /// </summary>
    /// <param name="_data"></param>
    public virtual void Enter(object _data=null)
    {
        gameObject.SetActive(true);
    }

    public virtual void Exit()
    {

    }
}
