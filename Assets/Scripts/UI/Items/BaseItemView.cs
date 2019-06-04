using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 物品Item 基类 UI
/// </summary>
public class BaseItemView : MonoBehaviour
{
    public Image ItemImg;
    public Image BgImg;
    public Image CheckImg;
    public Image LockImg;
    public Text NameText;
    public Text ValueText;

    public BaseItem itemData;
    public int Index { get; set; }
    public Vector3 CurrLocalScale = Vector3.one;

    // Start is called before the first frame update
    public virtual void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => ClickHandle());
        //UpdateState();
    }

    public virtual void ClickHandle()
    {
        
        //这里应该加上是否解锁
        GamePlayerPrefs.SetCurrItem(Index);
        if((GamePlayerPrefs.IsBuyedItem(Index) && (GamePlayerPrefs.GetCurrItem()!=Index))==false)
        {
            Debug.Log("未解锁");
            TipBox.Instance.ShowMessage("未解锁",0.5f);
        }
        EventManager.Instance.DispatchEvent(ShopEventMsg.UPDATE_ITEM_UI);
        UpdateState();
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void UpdateState()
    {
        bool isBuy = GamePlayerPrefs.IsBuyedItem(Index);
        bool isUnlock = isBuy && GamePlayerPrefs.GetCurrItem() != Index;
        bool isChoose = isBuy && GamePlayerPrefs.GetCurrItem() == Index;
        //Debug.Log("isBuy:" + isBuy + ",isUnlock:" + isUnlock + ",isChoose:" + isChoose);
        LockImg.gameObject.SetActive(!isBuy);
        CheckImg.gameObject.SetActive(isChoose);
    }
}
