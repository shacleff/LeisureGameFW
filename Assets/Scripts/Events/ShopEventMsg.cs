using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class ShopEventMsg
{
    /// <summary>
    /// 购买物品
    /// </summary>
    public static string BUY_ITEM_MSG = "buy_item_msg";
    /// <summary>
    /// 随机购买物品
    /// </summary>
    public static string RANDOM_BUY_ITEM_MSG = "random_buy_item_msg";
    /// <summary>
    /// 更新商店里的UI状态
    /// </summary>
    public static string UPDATE_SHOP_UI = "update_shop_ui";
    /// <summary>
    /// 更新物品UI状态
    /// </summary>
    public static string UPDATE_ITEM_UI = "update_item_ui";
    /// <summary>
    /// 商店奖励（后面可以增加具体的奖励声明）
    /// </summary>
    public static string SHOP_REWARD = "shop_reward";
}

