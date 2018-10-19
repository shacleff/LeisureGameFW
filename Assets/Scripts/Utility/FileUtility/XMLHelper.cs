using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class XMLHelper 
{
    private static XmlNodeList rootNodeList;


    /// <summary>
    /// 获取xml节点数据，并回调
    /// </summary>
    /// <param name="_path">路径</param>
    /// <param name="_nodeName">最高根名</param>
    /// <returns>XmlNodeList节点数据</returns>
    public static XmlNodeList GetXmlNodeList(string _path,string _nodeName)
    {
        XmlDocument xml = InitXmlData(_path);
        XmlNodeList node = xml.SelectSingleNode(_nodeName).ChildNodes;
        return node;
    }

    /// <summary>
    /// 获取xml节点数据，并回调
    /// </summary>
    /// <param name="_path">路径</param>
    /// <param name="_nodeName">最高根名</param>
    /// <param name="_callback">XmlNodeList节点数据</param>
    public static void GetXmlNodeList(string _path,string _nodeName,Action<XmlNodeList> _callback)
    {
        XmlDocument xml = InitXmlData(_path);
        XmlNodeList node = xml.SelectSingleNode(_nodeName).ChildNodes;
        if (_callback != null) _callback(node);
    }

    /// <summary>
    /// 异步加载xml数据
    /// </summary>
    /// <param name="path"></param>
    /// <param name="_callback">回调函数</param>
    /// <returns></returns>
    public IEnumerator WWWLoadXmlTxt(string path,Action<string> _callback)
    {
        WWW www = new WWW(path);
        yield return www;
        if (_callback != null && www.text != null) _callback(www.text);
    }

    /// <summary>
    /// 初始化
    /// </summary>
    /// <returns></returns>
    public static XmlDocument InitXmlData(string _path)
    {
        XmlDocument xml = new XmlDocument();
        XmlReaderSettings setting = new XmlReaderSettings();
        setting.IgnoreComments = true;
        TextAsset xmlTxt = Resources.Load<TextAsset>(_path);
        xml.LoadXml(xmlTxt.text);
        return xml;

    }

    public static void showXml()
    {
        TextAsset xmlTxt = Resources.Load<TextAsset>("Test2");
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlTxt.text);
        XmlNodeList nodeList = xmlDoc.SelectSingleNode("transforms").ChildNodes;
        //遍历每一个节点，拿节点的属性以及节点的内容
        foreach (XmlElement xe in nodeList)
        {
            Debug.Log("Attribute :" + xe.GetAttribute("name"));
            Debug.Log("NAME :" + xe.Name);
            foreach (XmlElement x1 in xe.ChildNodes)
            {
                if (x1.Name == "y")
                {
                    Debug.Log("VALUE :" + x1.InnerText);

                }
            }
        }
        Debug.Log("all = " + xmlDoc.OuterXml);
    }


    public static void ReadXml()
    {

    }

}
