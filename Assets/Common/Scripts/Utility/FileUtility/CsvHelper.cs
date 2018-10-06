using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Game;

public class CsvHelper:Singleton<CsvHelper>
{
    public delegate void DirectoryDelegate(Dictionary<string,List<string>> keyValuePairs);

    private CsvHelper() { }

    /// <summary>
    /// 读取csv数据
    /// </summary>
    /// <param name="_path">完整路径</param>
    /// <param name="directoryDelegate">Dictionary<string,List<string>>数据类型数据</param>
	public void LoadCsv(string _path,DirectoryDelegate directoryDelegate)
    {
        App.GetInstance().StartCoroutine(StartLoad(_path, directoryDelegate));
    }

    /// <summary>
    /// 读取csv数据
    /// </summary>
    /// <param name="_path">完整路径</param>
    /// <param name="directoryDelegate">Dictionary<string,List<string>>数据类型数据</param>
    /// <returns></returns>
    public IEnumerator StartLoad(string _path,DirectoryDelegate directoryDelegate)
    {
        string csvTxt = null;
        yield return App.GetInstance().StartCoroutine(LoadTxt(_path, (_txt) => { csvTxt = _txt; }));
        Dictionary<string, List<string>> keyValues = ToDictionary(AnalysisCsvTxt(csvTxt));
        directoryDelegate(keyValues);
    }

    private string GetPath(string _fileName)
    {
        string _path = Application.streamingAssetsPath + "/" + _fileName + ".csv";

        return _path;
    }

    private IEnumerator LoadTxt(string _path,Action<string> callback)
    {
        WWW www = new WWW(_path);
        yield return www;
        callback(www.text);
    }

    /// <summary>
    /// 返回解析完成后的csv数据
    /// </summary>
    /// <param name="csvTxt"></param>
    /// <returns></returns>
    private List<List<string>> AnalysisCsvTxt(string csvTxt)
    {
        return AnalysisCsvTxt(csvTxt, Encoding.UTF8);
    }

    /// <summary>
    /// 分析csv文件，提取相关数据
    /// 去掉空格符，去掉无效字符
    /// </summary>
    /// <param name="csvTxt"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    private List<List<string>> AnalysisCsvTxt(string csvTxt,Encoding encoding)
    {
        List<List<string>> csvList = new List<List<string>>();

        string txt = csvTxt.Replace("\r", "");
        string[] lines = txt.Split('\n');
        if(lines.Length>0)
        {
            byte[] byt = encoding.GetBytes(lines[0]);
            if(byt.Length>3 && byt[0]==0xEF && byt[1]==0xBB && byt[2]==0xBF)
            {
                lines[0] = encoding.GetString(byt, 3, byt.Length - 3);
            }
        }

        for (int i = 0; i < lines.Length; i++)
        {
            if(string.IsNullOrEmpty(lines[i]) || lines[i].StartsWith("#"))
            {
                continue;
            }
            List<string> s = SplitLine(lines[i], encoding);
            csvList.Add(s);
        }

        return csvList;
    }

    /// <summary>
    /// 分割每行的数据，保存每个字段到list列表中
    /// </summary>
    /// <param name="line"></param>
    /// <param name="encoding"></param>
    /// <returns>返回每行的字段list</returns>
    private List<string> SplitLine(string line,Encoding encoding)
    {
        List<string> lineLists = new List<string>();

        byte[] bytes = encoding.GetBytes(line);
        int end = bytes.Length - 1;

        List<byte> byteList = new List<byte>();
        bool inQuote = false;
        for (int i = 0; i < bytes.Length; i++)
        {
            switch ((char)bytes[i])
            {
                case ',':
                    if (inQuote) byteList.Add(bytes[i]);
                    else
                    {
                        lineLists.Add(Makefield(ref byteList, encoding));
                        byteList.Clear();
                    }
                    break;
                case '"':
                    inQuote = !inQuote;
                    byteList.Add((byte)'"');
                    break;
                case '\\':
                    if(i<end)
                    {
                        switch ((char)bytes[i+1])
                        {
                            case 'n':
                                byteList.Add((byte)'\n');
                                i++;
                                break;
                            case 't':
                                byteList.Add((byte)'\t');
                                i++;
                                break;
                            case 'r':
                                i++;
                                break;
                            default:
                                byteList.Add((byte)'\\');
                                break;
                        }
                    }
                    else
                    {
                        byteList.Add((byte)'\\');
                    }
                    break;
                default:
                    byteList.Add(bytes[i]);
                    break;
            }
        }

        lineLists.Add(Makefield(ref byteList, encoding));
        byteList.Clear();

        return lineLists;
    }

    /// <summary>
    /// 每个字段值
    /// </summary>
    /// <param name="bl"></param>
    /// <param name="encoding"></param>
    /// <returns>返回分析过的字段值string</returns>
    private string Makefield(ref List<byte> bl, Encoding encoding)
    {
        if (bl.Count > 1 && bl[0] == '"' && bl[bl.Count - 1] == '"')
        {
            bl.RemoveAt(0);
            bl.RemoveAt(bl.Count - 1);
        }
        int n = 0;
        while (true)
        {
            if (n >= bl.Count)
                break;
            if (bl[n] == '"')
            {
                if (n < bl.Count - 1 && bl[n + 1] == '"')
                {
                    bl.RemoveAt(n + 1);
                    n++;
                }
                else
                    bl.RemoveAt(n);
            }
            else
                n++;
        }

        return encoding.GetString(bl.ToArray());
    }

    /// <summary>
    /// 把获取到的csv list数据转换为dictionary
    /// </summary>
    /// <param name="data"></param>
    private Dictionary<string,List<string>> ToDictionary(List<List<string>> data)
    {
        Dictionary<string, List<string>> keyValuePairs = new Dictionary<string, List<string>>();
        for (int i = 0; i < data.Count; i++)
        {
            if (string.IsNullOrEmpty(data[i][0]))
                continue;
            keyValuePairs[data[i][0]] = data[i];
        }
        return keyValuePairs;
    }
}
