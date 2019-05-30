using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using FlipGun;

/// <summary>
/// UI窗体管理器脚本（框架核心脚本）
/// </summary>
public class UIManager
{
    /// <summary>
    /// 1、面板名称；
    /// 2、路径
    /// </summary>
    private Dictionary<string, string> mPanelNameToPath;
    /// <summary>
    /// 保存所有面板到Dictionary
    /// </summary>
    private Dictionary<string, BasePanel> mNameToPanels;
    /// <summary>
    /// 保存当前已经显示的panel到Dictionary
    /// </summary>
    private Dictionary<string, BasePanel> mCurrentShowingPanels;
    private List<DTUIPanel> dTUIPanels = new List<DTUIPanel>();
    private Stack<BasePanel> mCurrentPanelStacks;
    /// <summary>
    /// UI根节点
    /// </summary>
    private Transform mRootTransfrom = null;
    public Transform RootTransfrom
    {
        get { return mRootTransfrom; }
    }
    /// <summary>
    /// 需要全屏显示的panel节点
    /// </summary>
    public Transform mNormalTransfrom = null;

    private Transform mFixedTransfrom = null;
    /// <summary>
    /// 固定显示的panel节点
    /// </summary>
    public Transform FixedTransfrom
    {
        get { return mFixedTransfrom; }
    }

    private Transform mPopupTransfrom = null;
    /// <summary>
    /// 弹窗显示的panel节点
    /// </summary>
    public Transform PopupTransfrom
    {
        get { return mPopupTransfrom; }
    }

    private Transform mTopTransfrom = null;
    /// <summary>
    /// 最顶层Canvas节点
    /// </summary>
    public Transform Toptransfrom
    {
        get { return mTopTransfrom; }
    }

    public GameObject LeftCamera;
    public GameObject RightCamera;

    public UIManager()
    {
        Init();
        LeftCamera = GameObject.Find("LeftCamera");
        RightCamera = GameObject.Find("RightCamera");
        LeftCamera.SetActive(false);
        RightCamera.SetActive(false);
    }

    private void Init()
    {
        mPanelNameToPath = new Dictionary<string, string>();
        mNameToPanels = new Dictionary<string, BasePanel>();
        mCurrentShowingPanels = new Dictionary<string, BasePanel>();
        mCurrentPanelStacks = new Stack<BasePanel>();

        //InitRootCanvas();
        mRootTransfrom = GameObject.Find(UIDefine.TOP_CANVAS_NAME).transform;
        mNormalTransfrom = GameObjectHelper.GetGameObjectByName(mRootTransfrom, UIDefine.UI_NORMAL);
        mFixedTransfrom = GameObjectHelper.GetGameObjectByName(mRootTransfrom, UIDefine.UI_FIXED);
        mPopupTransfrom = GameObjectHelper.GetGameObjectByName(mRootTransfrom, UIDefine.UI_POPUP);
        mTopTransfrom = GameObjectHelper.GetGameObjectByName(mRootTransfrom, UIDefine.UI_TOP);

        InitUIPanelConfig();
    }

    private void InitUIPanelConfig()
    {
        //Manager.GetInstance().DictionaryConfig.LoadDictionaryFormPath(GlobalPath.UIPANEL_PATH);
        //mPanelNameToPath = Manager.GetInstance().DictionaryConfig.AppSetting;
        mPanelNameToPath.Add("MainGamePanel", "UIPrefabs\\Panels\\MainGamePanel");
        mPanelNameToPath.Add("AchievementPanel", "UIPrefabs\\Panels\\AchievementPanel");
        mPanelNameToPath.Add("FreeGiftPanel", "UIPrefabs\\Panels\\FreeGiftPanel");
        mPanelNameToPath.Add("RankPanel", "UIPrefabs\\Panels\\RankPanel");
        mPanelNameToPath.Add("MallPanel", "UIPrefabs\\Panels\\MallPanel");
        mPanelNameToPath.Add("GamingPanel", "UIPrefabs\\Panels\\GamingPanel");
        mPanelNameToPath.Add("GameOverPanel", "UIPrefabs\\Panels\\GameOverPanel");


    }

    public void InitRootCanvas()
    {
        mNameToPanels.Add("MainGamePanel", GameObjectHelper.GetGameObjectByName(mNormalTransfrom, "MainGamePanel").Get<BasePanel>());
        mCurrentShowingPanels.Add("MainGamePanel", GameObjectHelper.GetGameObjectByName(mNormalTransfrom, "MainGamePanel").Get<BasePanel>());
        // mCurrentShowingPanels.Add("MainGamePanel", mPanelNameToPath[]);
    }

    public void OpenPanel(int _paneID)
    {
        for (int i = 0; i < dTUIPanels.Count; i++)
        {
            DTUIPanel _panel = dTUIPanels[i];
            if (_panel.PanelId == (UIPanelID.UIFormId)_paneID)
            {
                OpenPanel(_panel.PanelName);
            }
        }
    }

    public void OpenPanel(string _panelName)
    {
        BasePanel _basePanel;
        if (string.IsNullOrEmpty(_panelName)) return;
        _basePanel = AddToAllPanelCache(_panelName);
        switch (_basePanel.CurrUIType.PanelShowMode)
        {
            case UIPanelShowMode.Normal:
                OpenPanelToCurrCache(_panelName);
                break;
            case UIPanelShowMode.ReverseChange:
                OpenPanelToStack(_panelName);
                break;
            case UIPanelShowMode.HideOther:
                OpenPanelAndHideOther(_panelName);
                break;
            default:
                break;
        }
    }

    public void ClosePanel(string _panelName)
    {
        BasePanel _basePanel;
        if (string.IsNullOrEmpty(_panelName)) return;
        mNameToPanels.TryGetValue(_panelName, out _basePanel);
        if (_basePanel == null) return;
        switch (_basePanel.CurrUIType.PanelShowMode)
        {
            case UIPanelShowMode.Normal:
                ExitPanel(_panelName);
                break;
            case UIPanelShowMode.ReverseChange:
                PopPanel();
                break;
            case UIPanelShowMode.HideOther:
                ExitPanelAndOpenOther(_panelName);
                break;
            default:
                break;
        }
    }

    public BasePanel GetPanel(string _panelName)
    {
        BasePanel _basePanel;
        if (string.IsNullOrEmpty(_panelName)) return null;
        mCurrentShowingPanels.TryGetValue(_panelName, out _basePanel);
        if (_basePanel == null) return null;
        return _basePanel;
    }

    /// <summary>
    /// 从Resource Manager中加载Panel资源
    /// </summary>
    /// <param name="_panelName"></param>
    /// <returns></returns>
    private BasePanel LoadPanel(string _panelName)
    {
        GameObject _panel;
        BasePanel _basePanel;
        //传名字过去，Resource Manager可以根据配置表去匹配名字加载相应的资源。这里先用Resources测试下 --3-20
        //GameObject obj = Manager.GetInstance().Resource.Load<GameObject>(mPanelNameToPath[_panelName]);
        GameObject obj = RootTransfrom.Get<UIPanelConfig>().GetPanel(_panelName);
        _panel = GameObject.Instantiate(obj);
        _panel.Reset();
        _panel.name = _panelName;
        _basePanel = _panel.GetComponent<BasePanel>();
        if (_basePanel == null)
        {
            Log.Error(string.Format("baseUiForm==null! ,请先确认窗体预设对象上是否加载了baseUIForm的子类脚本！ 参数 uiFormName={0}", _panelName));
            return null;
        }
        switch (_basePanel.CurrUIType.PanelType)
        {
            case UIPanelType.Normal:
                _panel.transform.SetParent(mNormalTransfrom, false);
                break;
            case UIPanelType.Fixed:
                _panel.transform.SetParent(mFixedTransfrom, false);
                break;
            case UIPanelType.Popup:
                _panel.transform.SetParent(mPopupTransfrom, false);
                break;
            default:
                break;
        }
        _basePanel.Hide();
        mNameToPanels.Add(_panelName, _basePanel);
        return _basePanel;

    }

    #region 显示窗口操作

    /// <summary>
    /// 根据UI窗体的名称，加载到“所有UI窗体”缓存集合中
    /// 功能： 检查“所有UI窗体”集合中，是否已经加载过，否则才加载。
    /// </summary>
    /// <param name="_panelName"></param>
    /// <returns></returns>
    private BasePanel AddToAllPanelCache(string _panelName)
    {
        BasePanel _basePanel;
        mNameToPanels.TryGetValue(_panelName, out _basePanel);
        if (_basePanel == null)
        {
            _basePanel = LoadPanel(_panelName);
        }
        return _basePanel;
    }

    /// <summary>
    /// 打开窗体，并把当前窗体加入到mCurrentShowingPanels
    /// 应用在UIPanelShowMode是Normal模式的 
    /// </summary>
    /// <param name="_panelName"></param>
    public void OpenPanelToCurrCache(string _panelName)
    {
        BasePanel _basePanel;
        mCurrentShowingPanels.TryGetValue(_panelName, out _basePanel);
        if (_basePanel != null) return;
        mNameToPanels.TryGetValue(_panelName, out _basePanel);
        if (_basePanel != null)
        {
            mCurrentShowingPanels.Add(_panelName, _basePanel);
            _basePanel.Show();
        }
    }

    /// <summary>
    /// 把窗体加入到栈里
    /// 应用在UIPanelShowMode是ReverseChange模式的 
    /// </summary>
    /// <param name="_panelName"></param>
    private void OpenPanelToStack(string _panelName)
    {
        BasePanel _basePanel;
        if (mCurrentPanelStacks.Count > 0)
        {
            BasePanel topPanel = mCurrentPanelStacks.Peek();
            topPanel.Freeze();
        }

        mNameToPanels.TryGetValue(_panelName, out _basePanel);
        if (_basePanel != null)
        {
            _basePanel.Show();
            mCurrentPanelStacks.Push(_basePanel);
        }
        else
        {
            Debug.Log(string.Format("baseUIForm==null,Please Check, 参数 uiFormName={0}", _panelName));
        }
    }

    /// <summary>
    /// 打开窗体同时隐藏其他窗体
    /// 应用在UIPanelShowMode是HideOther模式的 
    /// </summary>
    /// <param name="_panelName"></param>
    private void OpenPanelAndHideOther(string _panelName)
    {
        BasePanel _basePanel;
        if (string.IsNullOrEmpty(_panelName)) return;

        List<string> lists = new List<string>();
        foreach (BasePanel _panel in mCurrentShowingPanels.Values)
        {
            _panel.Hide();
        }

        foreach (BasePanel _panel in mCurrentPanelStacks)
        {
            _panel.Hide();

        }
        mNameToPanels.TryGetValue(_panelName, out _basePanel);
        if (_basePanel != null)
        {
            if (!mCurrentShowingPanels.ContainsKey(_panelName))
            {
                mCurrentShowingPanels.Add(_panelName, _basePanel);
            }
            _basePanel.Show();
        }
    }

    #endregion

    #region 关闭窗口操作

    /// <summary>
    /// 反向切换类型的出栈
    /// 弹窗类型的出栈
    /// 应用在UIPanelShowMode是ReverseChange模式的 
    /// </summary>
    private void PopPanel()
    {
        if (mCurrentPanelStacks.Count <= 0) return;
        BasePanel topPanel = mCurrentPanelStacks.Pop();
        topPanel.Hide();

        if (mCurrentPanelStacks.Count >= 2)
        {
            BasePanel nextPanel = mCurrentPanelStacks.Peek();
            nextPanel.ReShow();
        }
    }

    /// <summary>
    /// 一般性退出指定窗体
    /// 应用在UIPanelShowMode是Normal模式的 
    /// </summary>
    /// <param name="_panelName"></param>
    private void ExitPanel(string _panelName)
    {
        BasePanel _basePanel;
        mCurrentShowingPanels.TryGetValue(_panelName, out _basePanel);
        if (_basePanel != null)
        {
            _basePanel.Hide();
            mCurrentShowingPanels.Remove(_panelName);
        }
    }

    /// <summary>
    /// 
    /// 应用在UIPanelShowMode是HideOther模式的 
    /// </summary>
    /// <param name="_panelName"></param>
    private void ExitPanelAndOpenOther(string _panelName)
    {
        BasePanel _basePanel;

        if (string.IsNullOrEmpty(_panelName)) return;
        mCurrentShowingPanels.TryGetValue(_panelName, out _basePanel);
        if (_basePanel == null) return;
        _basePanel.Hide();
        mCurrentShowingPanels.Remove(_panelName);
        foreach (BasePanel _panel in mCurrentShowingPanels.Values)
        {
            _panel.ReShow();
        }
        foreach (BasePanel _panel in mCurrentPanelStacks)
        {
            _panel.ReShow();
        }
    }

    #endregion

    private void Clear()
    {

    }

    private void UnLoad()
    {

    }
}



