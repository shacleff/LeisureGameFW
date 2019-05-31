using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 基本物品类
/// </summary>
[Serializable]
public class BaseItem 
{
    /// <summary>
    /// 商品名字
    /// </summary>
    public string Name="";
    /// <summary>
    /// 商品描述
    /// </summary>
    public string Desc = "";
    /// <summary>
    /// 商品图名字
    /// </summary>
    public string SpriteName = "";
    /// <summary>
    /// 商品图
    /// </summary>
    public Sprite ItemSprite;
    /// <summary>
    /// 商品路径
    /// </summary>
    public string SpritePath = "";
    /// <summary>
    /// 是否解锁
    /// </summary>
    public bool IsLock=false;
    /// <summary>
    /// 价格
    /// </summary>
    public int Price=0;
    /// <summary>
    /// 金币价格
    /// </summary>
    public int CostCoin=0;
}
