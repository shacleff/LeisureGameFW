using System;
using System.Collections.Generic;
using System.Xml;

public class XmlDataManager
{
    XmlDataItem itemData;
    XmlDataRole roleData;


    public void Init()
    {
        itemData = new XmlDataItem();
        itemData.Init(XMLPath.XML_ITEM);
        ReadConfig(itemData);
        
        roleData = new XmlDataRole();
        roleData.Init(XMLPath.XML_ROLE);
        ReadConfig(roleData);
        
    }

    public void ReadConfig(XmlDataBase _database)
    {
        XmlNodeList nodeList = XMLHelper.GetXmlNodeList(_database.path,_database.GetRootNodeName());
        for (int i = 0; i < nodeList.Count; i++)
        {
            XmlElement element = nodeList.Item(i) as XmlElement;
            if (element == null) return;
            string id = element.GetAttribute("ID");
            for (int j = 0; j < element.Attributes.Count; j++)
            {
                XmlAttribute _attr = element.Attributes[j];
                _database.AppendAttribute(int.Parse(id), _attr.Name, _attr.Value);
                //Log.Debug("{0},{1}", _attr.Name, _attr.Value);
            }
        }
    }
}
