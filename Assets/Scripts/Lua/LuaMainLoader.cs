using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XLua;

[Serializable]
public class InJection
{
    public string key;
    public GameObject value;
}

[Serializable]
public class InJectionBtn
{
    public string key;
    public Button value;
}


[LuaCallCSharp]
public class LuaMainLoader : MonoBehaviour
{
    public string luaFileName;
    private LuaEnv mLuaEnv = new LuaEnv();
    private LuaTable scriptLua=null;
    public Action luaStart;
    public Action luaEnable;
    public Action luaUpdate;
    public Action luaDestroy;

    public InJection[] inJection;
    public InJectionBtn[] injectionBtn;

    internal static float lastGCTime = 0;
    internal const float GCInterval = 1;//1 second 

    void Awake()
    {
        string luaTxt = Loader(luaFileName);
        //创建这个脚本的lua table
        scriptLua = mLuaEnv.NewTable();
        //创建这个脚本的元表
        LuaTable meta = mLuaEnv.NewTable();
        //设置元表的__index值，使得这个脚本的表查询指向mLuaEnv.Global
        meta.Set("__index", mLuaEnv.Global);
        //把meta表设置为scriptLua的元表
        scriptLua.SetMetaTable(meta);
        meta.Dispose();
        //创建一个键值，用于self指向自己
        

        //Loader("MainLua");
        //txt文本一定是要UTF8格式
        //mLuaEnv.DoString(luaTxt, "LuaMainLoader", scriptLua);
        mLuaEnv.AddLoader(LoadByte);
        mLuaEnv.DoString("require '"+luaFileName+"'");
        Action luaAwake = mLuaEnv.Global.Get<Action>("awake");

        mLuaEnv.Global.Set("self", this);
        foreach (var obj in inJection)
        {
            mLuaEnv.Global.Set(obj.key, obj.value);
        }
        foreach (var btn in injectionBtn)
        {
            mLuaEnv.Global.Set(btn.key, btn.value);
        }

        mLuaEnv.Global.Get("start", out luaStart);
        mLuaEnv.Global.Get("update", out luaUpdate);
        mLuaEnv.Global.Get("ondestroy", out luaDestroy);
        mLuaEnv.Global.Get("on_enable", out luaEnable);
       
        if (luaAwake != null)
            luaAwake();
        
    }
    
    private string Loader(string _filePath)
    {
        //_filePath = Application.streamingAssetsPath + "/LuaFile/" + _filePath + ".lua";
        _filePath = Application.dataPath + "/Scripts/Lua/"+ _filePath + ".lua.txt";
        string s = System.IO.File.ReadAllText(_filePath);
        return s;
       // return System.Text.Encoding.UTF8.GetBytes(s);
    }

    private byte[] LoadByte(ref string _filePath)
    {
        _filePath = Application.dataPath + "/Scripts/Lua/" + _filePath + ".lua.txt";
        string s = System.IO.File.ReadAllText(_filePath);
        return System.Text.Encoding.UTF8.GetBytes(s);
    }

    void Start ()
    {
        //mLuaEnv = new LuaEnv();
        //mLuaEnv.DoString("require 'Mainlua'");
        if (luaStart != null)
            luaStart();
	}

    private void OnEnable()
    {
        if (luaEnable != null)
            luaEnable();
    }

    void Update ()
    {
        if (luaUpdate != null)
            luaUpdate();

        if(Time.time-lastGCTime>GCInterval)
        {
            mLuaEnv.Tick();
            lastGCTime = Time.time;
        }
	}

    private void OnDestroy()
    {
        if (luaDestroy != null)
            luaDestroy();
        luaDestroy = null;
        luaUpdate = null;
        luaStart = null;
        scriptLua.Dispose();
    }
}
