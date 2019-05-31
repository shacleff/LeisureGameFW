using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utility;

public class ShopPanel : BasePanel
{
    public GameObject ItemPrefab;
    public Transform ItemContent;

    public Button BuyBtn;
    private ScrollRect scrollRect;
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
    }


    private void InitItemView()
    {
        List<Sprite> itemSprites = UIResourceManager.Instance.spriteArr;
        GameObject obj;
        for (int i = 0; i < itemSprites.Count; i++)
        {
            obj = Instantiate(ItemPrefab, ItemContent);
            obj.GetComponent<ItemView>().SetData();
            obj.GetComponent<ItemView>().Index = i;
            itemViews.Add(obj.GetComponent<BaseItemView>());
        }
    }

    public void UpdateItemState()
    {
        
        foreach (BaseItemView item in itemViews)
        {
            item.UpdateState();
        }
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

