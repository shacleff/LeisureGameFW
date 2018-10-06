using UnityEngine;
using System.Collections;

public class XmlDataBase
{
    public string path;

    protected Hashtable data;

    public void Init()
    {
        data = new Hashtable();
    }

    public void Init(string path)
    {
        this.path = path;
        data = new Hashtable();
    }

    public virtual string GetRootNodeName()
    {
        return "ROOT";
    }

    /// <summary>
    /// 匹配每个ID所对应的key->value键值对数据
    /// </summary>
    /// <param name="_id">物品 ID</param>
    /// <param name="_key">数据项的key</param>
    /// <param name="_value">数据项key所对应的值</param>
    public virtual void AppendAttribute(int _id, string _key, string _value)
    {
        
    }

    public virtual bool HasValue(int key)
    {
        return data.ContainsKey(key);
    }

    public Hashtable GetHashtable()
    {
        return data;
    }
}
