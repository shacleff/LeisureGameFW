/**
 * 
 * Author:JoeyHuang
 * Time: 2019/8/10 15:31:59
 * 说明：
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel;
using FileUtility;
using UnityEngine;
using UnityEditor;
using Newtonsoft.Json;

namespace ExcelData
{
    public class ExcelDataEditor:Editor
    {

        [MenuItem("Tools/ExcelTools/SelectXlsx")]
        public static void SelectXlsx()
        {
            string _directory = EditorUtility.SaveFolderPanel("select xlsx floder", "", "");
            Debug.Log(_directory);
            DirectoryInfo directoryInfo = new DirectoryInfo(_directory);
            foreach (FileInfo fileInfo in directoryInfo.GetFiles())
            {
                if(fileInfo.Extension==".xlsx" || fileInfo.Extension==".xls")
                {
                    Debug.Log(fileInfo.Name);
                    LoadExcelData(fileInfo.Name);
                }
            }
        }

        public static void UpdateJson()
        {

        }

        public static void GeneratorScript()
        {

        }

        public static void LoadExcelData(string _xlsxName)
        {
            FileStream fileStream = File.Open(Application.dataPath+"/Resources/"+ _xlsxName, FileMode.Open, FileAccess.Read);
            IExcelDataReader excel = ExcelReaderFactory.CreateOpenXmlReader(fileStream);

            string[] _types = null;
            string[] _fields = null;
            string[] _descs = null;
            int index = 0;
            StringBuilder jsonStr = new StringBuilder();
            
            jsonStr.Append("[");
            while (excel.Read())
            {
                string[] datas = new string[excel.FieldCount];
                for (int i = 0; i < datas.Length; i++)
                {
                    datas[i] = excel.GetString(i);
                    
                    //Debug.Log(datas[i]);
                }
                if (datas.Length == 0 || string.IsNullOrEmpty(datas[0]))
                {
                    index++;
                    continue;
                }
                if (index == 0) _descs = datas;
                else if (index == 1) _fields = datas;
                else if (index == 2) _types = datas;
                else if (index > 2)
                {
                    jsonStr.Append("{");
                    for (int j = 0; j < datas.Length; j++)
                    {
                       
                        jsonStr.Append(string.Format("\"{0}\":\"{1}\"", _fields[j], datas[j]));
                        if (j != datas.Length - 1)
                        {
                            jsonStr.Append(",");
                        }
                    }
                    jsonStr.Append("},");

                }
                
                index++;
            }
            string str = jsonStr.ToString().TrimEnd();
            str = str.Remove(str.Length - 1);
            str += "]";
            string convertJson = ConvertJsonString(str);
            FileManager.WriteToTxt(convertJson, Application.dataPath + "/Resources/" + excel.Name + ".json", true);
            ScriptGenerator sg = new ScriptGenerator(Application.dataPath + "/Resources/",excel.Name, _types, _fields,_descs);
            sg.Generator();
            Debug.Log(str);

            
        }

        private static string ConvertJsonString(string str)
        {
            //格式化json字符串
            JsonSerializer serializer = new JsonSerializer();
            TextReader tr = new StringReader(str);
            JsonTextReader jtr = new JsonTextReader(tr);
            object obj = serializer.Deserialize(jtr);
            if (obj != null)
            {
                StringWriter textWriter = new StringWriter();
                JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                {
                    Formatting = Formatting.Indented,
                    Indentation = 4,
                    IndentChar = ' '
                };
                serializer.Serialize(jsonWriter, obj);
                return textWriter.ToString();
            }
            else
            {
                return str;
            }
        }


    }
}
