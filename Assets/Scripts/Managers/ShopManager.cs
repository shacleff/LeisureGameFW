using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Events;

public class ShopEventMsg
{
    public static string BUY_ITEM_MSG = "buy_item_msg";
    public static string RANDOM_BUY_ITEM_MSG = "random_buy_item_msg";
    public static string UPDATE_SHOP_UI = "update_shop_ui";
    public static string UPDATE_ITEM_UI = "update_item_ui";
}


public class ShopManager : MonoBehaviour
{
    private List<int> ItemIndexs;
    private List<int> LockItemIndexs;
    private List<int> UnLockItemIndexs;
    private ScrollRect scrollRect;
    private GridLayoutGroup Layout;
    private int mCostCoin=100;
    private int mActualCoin = 50;
    private int mCurrItemIndex=0;

    private void Awake()
    {
        ItemIndexs = new List<int>();
        LockItemIndexs = new List<int>();
        UnLockItemIndexs = new List<int>();
        
    }

    void Start ()
    {
        InitData();
        UpdateData();
        EventManager.Instance.AddEventListener(ShopEventMsg.BUY_ITEM_MSG, BuyItem);
        EventManager.Instance.AddEventListener(ShopEventMsg.RANDOM_BUY_ITEM_MSG, RandomBuyItem);
	}

    private void BuyItem(object param)
    {
        UpdateData();
        EventManager.Instance.DispatchEvent(ShopEventMsg.UPDATE_SHOP_UI);
    }

    /// <summary>
    /// 随机购买金币
    /// </summary>
    /// <param name="param"></param>
    private void RandomBuyItem(object param)
    {
        if (LockItemIndexs.Count <= 0) return;
        //if (ScoreHandler.GetInstance().Coin < mCostCoin)
        //{
        //    return;
        //}
        //ScoreHandler.GetInstance().Coin -= mCostCoin;
        int random = UnityEngine.Random.Range(0, LockItemIndexs.Count);
        mCurrItemIndex = LockItemIndexs[random];
        UnLockItemIndexs.Add(ItemIndexs[mCurrItemIndex]);
        LockItemIndexs.Remove(ItemIndexs[mCurrItemIndex]);
        GamePlayerPrefs.SetBuyedItem(mCurrItemIndex);
        GamePlayerPrefs.SetCurrItem(mCurrItemIndex);
        UpdateData();
        EventManager.Instance.DispatchEvent(ShopEventMsg.UPDATE_SHOP_UI);
        //Messenger.Broadcast(ELocalMsgID.UPDATE_SHOP_UI);
        //SetSelectItem(mCurrItemIndex);
    }

    public void InitData()
    {
        //int count = GamePlayerPrefs.GetItemCount();
        //for (int i = 0; i < count; i++)
        //{
        //    ItemIndexs.Add(i);
        //}
        //UpdateData();
        
    }

    
    public void UpdateData()
    {
        UnLockItemIndexs.Clear();
        LockItemIndexs.Clear();
        for (int i = 0; i < ItemIndexs.Count; i++)
        {
            bool _isBuy = GamePlayerPrefs.IsBuyedItem(ItemIndexs[i]);
            if (_isBuy)
            {
                UnLockItemIndexs.Add(ItemIndexs[i]);
            }
            else
            {
                LockItemIndexs.Add(ItemIndexs[i]);
            }
        }
    }
	

    public void ClickItem(int _index)
    {
        if (GamePlayerPrefs.IsBuyedItem(_index))
        {
            SelectItem(_index);
        }
    }

    /// <summary>
    /// 选中一个Item时调用
    /// </summary>
    public void SelectItem(int _index)
    {
        GamePlayerPrefs.SetCurrItem(_index);
    }

    /// <summary>
    /// 触发随机选择Item按钮
    /// </summary>
    public void RandomSelectItemBtn()
    {
        //int _random = 0;
        //if(mActualCoin< mCostCoin)
        //{
        //    _random = UnityEngine.Random.Range(0, LockItems.Count);
        //    mCurrItemIndex = LockItems[_random].Index;

        //    UnLockItems.Add(ItemViews[mCurrItemIndex]);
        //    LockItems.RemoveAt(_random);
        //}
        //else
        //{
            
        //}
    }
    
	
	void Update ()
    {
		
	}

    
}
