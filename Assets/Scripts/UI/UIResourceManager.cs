using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private void Awake()
    {
       // Instance = this;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void OpenPopup(PopupType _popupType)
    {
        GameObject offline;
        if(PopupCanvas.transform.Find("OfflinePopup")!=null)
        {
            offline = PopupCanvas.transform.Find("OfflinePopup").gameObject;
        }
        else
        {
            offline = Instantiate(Resources.Load<GameObject>(UIPath.OFFLINE_POPUP), PopupCanvas.transform);
        }
        offline.SetActive(true);
    }

}

