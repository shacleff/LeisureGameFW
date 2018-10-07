using System;
using System.Data;
using System.Collections.Generic;

public class XmlDataEquip : XmlDataBase
{



    public override void AppendAttribute(int _id, string _key, string _value)
    {
        base.AppendAttribute(_id, _key, _value);
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
