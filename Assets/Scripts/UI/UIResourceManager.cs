using System.Collections;
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
        EventManager.Instance.AddEventListener(CheckInManager.CHECK_IN_INFO, OpenCheckInPopup);
    }

    void Update()
    {

    }

    public void OpenPopup(PopupType _type,string _popupPrefabPath)
    {
        CheckPopup(_type);
        if (popupList.Find(o => o.popupType == _type) != null)
        {
            popupList.Find(o => o.popupType == _type).Enter();
        }
        else
        {
            GameObject obj;
            obj = Instantiate(Resources.Load<GameObject>(_popupPrefabPath), PopupCanvas.transform);
            obj.GetComponent<BasePopup>().Enter();
            popupList.Add(obj.GetComponent<BasePopup>());
        }
    }

    public void OpenOfflinePopup()
    {
        CheckPopup(PopupType.OfflinePopup);
        if (popupList.Find(o => o.popupType == PopupType.OfflinePopup) != null)
        {
            popupList.Find(o => o.popupType == PopupType.OfflinePopup).Enter();
        }
        else
        {
            OffineObj = Instantiate(Resources.Load<GameObject>(UIPath.OFFLINE_POPUP), PopupCanvas.transform);
            OffineObj.GetComponent<OfflinePopup>().Enter();
            popupList.Add(OffineObj.GetComponent<OfflinePopup>());
        }
    }

    public void OpenGiftBagPopup()
    {
        CheckPopup(PopupType.GiftBag);
        if (popupList.Find(o => o.popupType == PopupType.GiftBag) != null)
        {
            popupList.Find(o => o.popupType == PopupType.GiftBag).Enter();
        }
        else
        {
            GiftBagObj = Instantiate(Resources.Load<GameObject>(UIPath.GIFT_BAG_POPUP), PopupCanvas.transform);
            GiftBagObj.GetComponent<GiftPopup>().Enter();
            popupList.Add(GiftBagObj.GetComponent<GiftPopup>());
        }
    }

    public void OpenCheckInPopup(object _info)
    {
        CheckPopup(PopupType.CheckIn);

        Sprite[] _daySprites = (Sprite[])_info;
        if (popupList.Find(o => o.popupType == PopupType.CheckIn) != null)
        {
            popupList.Find(o => o.popupType == PopupType.CheckIn).Enter();
        }
        else
        {
            CheckInObj = Instantiate(Resources.Load<GameObject>(UIPath.CHECK_IN_POPUP), PopupCanvas.transform);
            CheckInObj.GetComponent<CheckInPopup>().Enter();
            popupList.Add(CheckInObj.GetComponent<CheckInPopup>());
        }
        
    }

    public void CheckPopup(PopupType _popupType)
    {
        popupList.FindAll(o => o.popupType != _popupType).ForEach((_popup)=> { _popup.Exit(); });
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

