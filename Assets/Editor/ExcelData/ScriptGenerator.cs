/**
 * 
 * Author:JoeyHuang
 * Time: 2019/8/10 11:51:53
 * 说明：
 */

using System;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using FileUtility;

namespace ExcelData
{
    public class SupportType
    {
        public const string INT = "int";
        public const string LONG = "long";
        public const string FLOAT = "float";
        public const string STRING = "string";
        public const string LIST_INT = "List<int>";
        public const string LIST_FLOAT = "List<float>";
        public const string LIST_STRING = "List<string>";
        public const string LIST_LIST_INT = "aai";
        public const string LIST_LIST_FLOAT = "aaf";
        public const string LIST_LIST_STRING = "aas";
        public const string DICTIONARY_INT_INT = "i_i";
        public const string DICTIONARY_INT_FLOAT = "i_f";
        public const string DICTIONARY_INT_STRING = "i_s";
        public const string DICTIONARY_INT_LIST_INT = "i_ai";
        public const string DICTIONARY_INT_LIST_FLOAT = "i_af";
    }



    public class ScriptGenerator
    {
        private string ClassName;
        private string InputPath;
        private string[] Types;
        private string[] Fields;
        private string[] Descs;

        public ScriptGenerator(string _path,string _className, string[] _types, string[] _fields,string[] _descs)
        {
            this.InputPath = _path;
            this.ClassName = _className;
            this.Types = _types;
            this.Fields = _fields;
            this.Descs = _descs;
        }

        public string Generator()
        {
            //开始生成脚本
            if (Types == null || Fields == null || ClassName == null)
                throw new Exception("表名:" + ClassName +
                                    "\n表名为空:" + (ClassName == null) +
                                    "\n字段类型为空:" + (Types == null) +
                                    "\n字段名为空:" + (Fields == null));
            return GeneratorClass();
        }

        private string GeneratorClass()
        {
            StringBuilder _source = new StringBuilder();
            _source.Append("using System;\n");
            _source.Append("using System.Collections.Generic;\n");
            _source.Append("using System.Linq;\n");
            _source.Append("using System.Collections;\n");
            _source.Append("using System.Reflection;\n");
            _source.Append("\n");
            _source.Append("\n");
            _source.Append("\n");
            _source.Append("[Serializable]\n");
            _source.Append("public class "+ClassName+" \n");
            _source.Append("{\n");

            for (int i = 0; i < Types.Length; i++)
            {
                string _field = Fields[i];
                string _type = Types[i];
                string _desc = Descs[i];
                _source.Append("\t/// <summary>\n");
                _source.Append("\t/// "+_desc+"\n");
                _source.Append("\t/// </summary>\n");
                _source.Append("\tpublic "+CheckTrueType(_type)+" "+_field+";\n");
            }
            _source.Append("\n");
            _source.Append("}");
            FileManager.WriteToTxt(_source.ToString(), this.InputPath+ ClassName + ".cs", true);

            return _source.ToString();
        }

        private string CheckTrueType(string _type)
        {
            string str = "";
            switch (_type)
            {
                case SupportType.INT:
                    str = _type;
                    break;
                case SupportType.FLOAT:
                    str = _type;
                    break;
                case SupportType.STRING:
                    str = _type;
                    break;
                case SupportType.LONG:
                    str = _type;
                    break;
                case SupportType.LIST_INT:
                    str = _type;
                    break;
                case SupportType.LIST_FLOAT:
                    str = _type;
                    break;
                case SupportType.LIST_STRING:
                    str = _type;
                    break;
                default:
                    throw new Exception("输入了错误的数据类型:  " + _type + ", 类名:  " + ClassName + ", 位于:  " + InputPath);

            }
            return str;
        }
    }


    public class ScriptGeneratorEditor:Editor
    {

        private static string ClassName;
        private static string InputPath;

        private void OnEnable()
        {
            
        }

        [MenuItem("Tools/ExcelTools/GeneratorScript")]
        public static void GeneratorScript()
        {
            StringBuilder _source = new StringBuilder();
            _source.Append("using System;\n");
            _source.Append("using System.Collections.Generic;\n");
            _source.Append("using System.Linq;\n");
            _source.Append("using System.Collections;\n");
            _source.Append("using System.Reflection;\n");
            _source.Append("\n");
            _source.Append("\n");
            _source.Append("\n");
            _source.Append("[Serializable]\n");
            _source.Append("public class GeneratorClass \n");
            _source.Append("{\n");
            _source.Append("\t public string _name;\n");
            _source.Append("\t public int _age;\n");
            _source.Append("}");
            FileManager.WriteToTxt(_source.ToString(),Application.dataPath + "/Resources/GeneratorClass.cs",true);
        }

        private static string CheckTrueType(string _type)
        {
            string str="";
            switch (_type)
            {
                case SupportType.INT:
                    str = _type;
                    break;
                case SupportType.FLOAT:
                    str = _type;
                    break;
                case SupportType.STRING:
                    str = _type;
                    break;
                case SupportType.LONG:
                    str = _type;
                    break;
                case SupportType.LIST_INT:
                    str = _type;
                    break;
                case SupportType.LIST_FLOAT:
                    str = _type;
                    break;
                case SupportType.LIST_STRING:
                    str = _type;
                    break;
                default:
                    throw new Exception("输入了错误的数据类型:  " + _type + ", 类名:  " + ClassName + ", 位于:  " + InputPath);
                    
            }
            return str;
        }

    }

}
