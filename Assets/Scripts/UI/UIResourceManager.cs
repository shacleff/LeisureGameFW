using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utility;

/// <summary>
/// UI资源管理工具，用于更方便的添加UI物品icon或者其他涉及到UI图片的操作
/// </summary>
public class UIResourceManager : MonoSingleton<UIResourceManager>
{
    //public static UIResourceManager Instance;
    public GameObject RootCanvas;
    public GameObject PopupCanvas;
    public List<Sprite> spriteArr=new List<Sprite>();
    private GameObject OffineObj;
    private GameObject GiftBagObj;
    private GameObject CheckInObj;
    private List<BasePopup> popupList=new List<BasePopup>();

    private void Awake()
    {
       // Instance = this;
    }

    void Start()
    {
        //EventManager.Instance.AddEventListener(CheckInManager.CHECK_IN_INFO, OpenCheckInPopup);.
        EventManager.Instance.AddEventListener(PopupEvent.OPEN_POPUP, OpenPopup);
    }

    void Update()
    {

    }

    public void OpenPopup(object _info)
    {
        PopupEvent popupEvent = (PopupEvent)_info;
        OpenPopup(popupEvent.popupType, popupEvent.PopupPrefabPath, popupEvent.Datas);
    }

    public void OpenPopup(PopupType _type,string _popupPrefabPath,object _data)
    {
        CheckPopup(_type);
        if (popupList.Find(o => o.popupType == _type) != null)
        {
            popupList.Find(o => o.popupType == _type).Enter(_data);
        }
        else
        {
            GameObject obj;
            obj = Instantiate(Resources.Load<GameObject>(_popupPrefabPath), PopupCanvas.transform);
            obj.GetComponent<BasePopup>().Enter(_data);
            popupList.Add(obj.GetComponent<BasePopup>());
        }
    }

    /// <summary>
    /// 弹窗同时出现的时候，隐藏除目标外的其他所有弹窗
    /// </summary>
    /// <param name="_popupType"></param>
    public void CheckPopup(PopupType _popupType)
    {
        popupList.FindAll(o => o.popupType != _popupType).ForEach((_popup)=> { _popup.Exit(); });
    }

    /// <summary>
    /// 弹窗同时出现的时候，按照优先级排序
    /// </summary>
    public void OrderPopupUI()
    {
        popupList=popupList.OrderBy(o => o.Priority).ToList();
        for (int i = 0; i < popupList.Count; i++)
        {
            popupList[i].transform.SetAsLastSibling();
        }
    }

    //LayoutRebuilder.ForceRebuildLayoutImmediate
    /// <summary>
    /// 强制刷新UI，一般用在有用到Layout组件上
    /// </summary>
    public void ForceRebuildLayoutImmediate()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(RootCanvas.GetComponent<RectTransform>());
    }

}

