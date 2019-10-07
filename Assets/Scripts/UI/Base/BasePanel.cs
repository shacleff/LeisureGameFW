using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;

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

    public GameObject closeBtn;

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
        EventTriggerListener.Get(closeBtn).onClick += ClosePanelHandle;
    }

    protected virtual void ClosePanelHandle(GameObject go)
    {
        this.gameObject.SetActive(false);
    }

    public virtual void Update()
    {

    }

    public virtual void LateUpdate()
    {

    }

    public virtual void OnEnter()
    {

    }

    public virtual void OnExit()
    {

    }

    protected void Clear()
    {

    }

    protected void Unload()
    {

    }

}

