﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[CreateAssetMenu(menuName = "GameDataAsset")]
public class GameData : ScriptableObject
{
    public List<BaseItem> items;
    public List<ItemNameList> itemNameListmap;
    
}

[Serializable]
public class ItemNameList
{ 
    public string Name;
    public List<BaseItem> ItemList;
}