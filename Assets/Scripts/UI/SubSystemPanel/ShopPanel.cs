using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utility;


/// <summary>
/// 商店UI控制类，负责商店中的UI逻辑的处理
/// </summary>
public class ShopPanel : BasePanel
{
    public GameObject ItemPrefab;
    public Transform ItemContent;

    public Button BuyBtn;
    public ScrollRect scrollRect;
    private GridLayoutGroup Layout;
    private List<BaseItemView> itemViews = new List<BaseItemView>();

    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        base.Start();
        InitItemView();

        EventManager.Instance.AddEventListener(ShopEventMsg.UPDATE_ITEM_UI, UpdateItemState);
    }
    

    private void InitItemView()
    {
        List<Sprite> itemSprites = UIResourceManager.Instance.spriteArr;
        GameObject obj;
        for (int i = 0; i < itemSprites.Count; i++)
        {
            obj = Instantiate(ItemPrefab, ItemContent);
            obj.GetComponent<BaseItemView>().Index = i;
            itemViews.Add(obj.GetComponent<BaseItemView>());
            scrollRect.gameObject.GetComponent<ScrollFocusController>().ItemTrans.Add(obj.transform);
        }
        scrollRect.gameObject.GetComponent<ScrollFocusController>().InitIndexArr();
    }



    public void UpdateItemState(object param)
    {
        
        foreach (BaseItemView item in itemViews)
        {
            item.UpdateState();
        }
    }

    public void Buy()
    {
        EventManager.Instance.DispatchEvent(ShopEventMsg.BUY_ITEM_MSG);
    }

    public void RandomBuy()
    {
        EventManager.Instance.DispatchEvent(ShopEventMsg.RANDOM_BUY_ITEM_MSG);
    }

    public void FreeReward()
    {
        EventManager.Instance.DispatchEvent(ShopEventMsg.SHOP_REWARD);
    }


    public override void Freeze()
    {
        base.Freeze();
    }

    public override void Hide()
    {
        base.Hide();
    }

    public override void ReShow()
    {
        base.ReShow();
    }

    public override void Show()
    {
        base.Show();
        
    }
    

    protected override void ClosePanelHandle(GameObject go)
    {
        base.ClosePanelHandle(go);
    }
}

