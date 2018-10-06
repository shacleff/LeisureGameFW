using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FileUtility;

public interface IJsonHelper
{
    string SerializeJson(object obj);
    T DeserializeObject<T>(string _json);
}

/// <summary>
/// 网络下载
/// 本地下载
/// Resource文件夹下载
/// StreamingAssets文件夹下载
/// </summary>
public class JsonHelper 
{
    /// <summary>
    ///  序列为json
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string Serialize(object obj)
    {
        
        string _json = JsonConvert.SerializeObject(obj);
        return _json;

    }
    
    /// <summary>
    /// 反序列号到对象
    /// </summary>
    /// <param name="_json"></param>
    /// <returns></returns>
    public static object Deserialize(string _json)
    {
        return JsonConvert.DeserializeObject(_json);
    }

    /// <summary>
    /// 反序列号到泛型对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_json"></param>
    /// <returns></returns>
    public static T Deserialize<T>(string _json)
    {
        T t = JsonConvert.DeserializeObject<T>(_json);

        return t;
    }

    /// <summary>
    /// 反序列号到List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_json"></param>
    /// <returns></returns>
    public static List<T> DeserializeToList<T>(string _json)
    {
        List<T> _list = JsonConvert.DeserializeObject<List<T>>(_json);
        return _list;
    }

    public static void Write()
    {

    }

    public static void Write(object jsonObj,string fileName,string path)
    {
        string jsonTxt = Serialize(jsonObj);
        FileManager.WriteToTxt(jsonTxt, path);

    }

    public static void Read()
    {

    }

    /// <summary>
    /// 相对路径
    /// 绝对路径
    /// Unity路径
    /// 网络路径
    /// </summary>
    /// <param name="url"></param>
    public static void Read(string url)
    {
        string jsonContent = FileManager.GetFileContent(url);
        object o = Deserialize(jsonContent);
    }

    
}

