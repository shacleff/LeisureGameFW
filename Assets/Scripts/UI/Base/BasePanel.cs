using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI窗体脚本（父类，其他窗体都继承此脚本）
/// </summary>
public class BasePanel : MonoBehaviour
{
    protected UIType mCurrUItype;

    public UIType CurrUIType
    {
        get
        {
            return mCurrUItype;
        }
        set
        {
            mCurrUItype = value;
        }
    }

    protected GameObject mCloseBtn;
    protected GameObject CloseBtn
    {
        get { return mCloseBtn; }
    }

    protected string mPanelName;
    public string PanelName
    {
        get { return mPanelName; }
    }

    public virtual void Awake()
    {
        mCurrUItype = new UIType();
    }

    public virtual void Start()
    {

    }

    public virtual void LateUpdate()
    {

    }

    protected virtual void BasePanel_onCloseClick(GameObject go)
    {

    }

    #region 面板4种状态

    /// <summary>
    /// 显示面板
    /// </summary>
    public virtual void Show()
    {
        gameObject.SetActive(true);

    }

    /// <summary>
    /// 隐藏面板
    /// </summary>
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 重新显示面板
    /// </summary>
    public virtual void ReShow()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// 冻结状态
    /// </summary>
    public virtual void Freeze()
    {
        gameObject.SetActive(true);
    }

    #endregion

    protected void Clear()
    {

    }

    protected void Unload()
    {

    }

}

