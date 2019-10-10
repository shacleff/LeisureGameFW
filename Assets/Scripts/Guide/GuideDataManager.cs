using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GuideDataManager:Singleton<GuideDataManager>
{
    private string guideTablePath = "Guide";
    private List<GuideData> guideDatas = new List<GuideData>();


    private GuideDataManager() { }


    public void Init()
    {
        ParseTable();
    }

    private void ParseTable()
    {
        //string guideStr = Resources.Load<TextAsset>(guideTablePath).ToString();
        
        CsvHelper.GetInstance().LoadCsvFromResource(guideTablePath,LoadComplete);
    }

    private void LoadComplete(Dictionary<string, List<string>> keyValuePairs)
    {
        GuideData guideData = new GuideData();
        foreach (string item in keyValuePairs.Keys)
        {
            List<string> _val = keyValuePairs[item];
            Debug.Log(item);
            if(item=="id")
            {

            }
            else if(item=="整数")
            {

            }
            else if(item=="唯一标识")
            {

            }
            else
            {
                guideData = new GuideData(_val[0], _val[4], _val[1], _val[2], _val[3]);
                guideDatas.Add(guideData);
            }
        }
        for (int i = 0; i < guideDatas.Count; i++)
        {
            //Debug.Log(guideDatas[i]);
        }
    }
}
