using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;


public class RoleItem
{
    public int ID;
    public int upgradeExp;
    public int maxHp;
    public int maxMp;
    public int attack;
    public int defense;
    public int precise;
    public int dodge;
    public int blastAttack;
}

public class XmlDataRole : XmlDataBase
{

    public override void AppendAttribute(int _id, string _key, string _value)
    {
        base.AppendAttribute(_id, _key, _value);
        RoleItem roleItem;
        if(!data.ContainsKey(_id))
        {
            roleItem = new RoleItem();
            data.Add(_id, roleItem);
        }
        else
        {
            roleItem = (RoleItem)data[_id];
        }
        switch (_key)
        {
            case "ID":
                roleItem.ID = int.Parse(_value);
                break;
            case "upgradeExp":
                roleItem.upgradeExp = int.Parse(_value);
                break;
            case "eFPC_MaxHP":
                roleItem.maxHp = int.Parse(_value);
                break;
            case "eFPC_MaxMP":
                roleItem.maxMp = int.Parse(_value);
                break;
            case "eFPC_Attack":
                roleItem.attack = int.Parse(_value);
                break;
            case "eFPC_Defense":
                roleItem.defense = int.Parse(_value);
                break;
            case "eFPC_Precise":
                roleItem.precise = int.Parse(_value);
                break;
            case "eFPC_Dodge":
                roleItem.dodge = int.Parse(_value);
                break;
            case "eFPC_BlastAttack":
                roleItem.blastAttack = int.Parse(_value);
                break;
            default:
                break;
        }
        data[_id] = roleItem;
    }
    

    public override string GetRootNodeName()
    {
        return base.GetRootNodeName();
        
    }

    public override bool HasValue(int key)
    {
        return base.HasValue(key);
    }

}
