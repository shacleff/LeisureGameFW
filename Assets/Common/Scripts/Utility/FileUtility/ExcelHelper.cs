using System;
using UnityEngine;
using System.IO;
using Excel;
using System.Data;


public class ExcelHelper 
{

    
    public static void ReadExcelFromRes(string _path)
    {
        FileStream stream = File.Open(Application.dataPath + "/Resources/Asteroid.xlsx",FileMode.Open,FileAccess.Read);
        IExcelDataReader dataReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        DataSet result = dataReader.AsDataSet();
        int columns = result.Tables[0].Columns.Count;
        int rows = result.Tables[0].Rows.Count;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Debug.Log(result.Tables[0].Rows[i][j].ToString());
            }
        }
    }
    
}
