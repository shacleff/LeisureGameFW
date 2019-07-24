using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class GameWindowEditor : EditorWindow
{
    private GameData gameData;
    private Vector2 scrollPosition = Vector2.zero;
    private bool[] toggles;
    private string[] buttons;

    [MenuItem("Game/GameEditor")]
    public static void Initialize()
    {
        GameWindowEditor window = EditorWindow.GetWindow<GameWindowEditor>(true, "GameEditor");
        window.maxSize = new Vector2(550, 400);
        window.minSize = window.maxSize;
    }

    private void OnEnable()
    {
        toggles = new bool[] { false, false, false, false, false };
        buttons = new string[] { "Open", "Open", "Open", "Open", "Open" };
        gameData = (GameData)AssetDatabase.LoadAssetAtPath("Assets/GameDataObject.asset",typeof(GameData));

    }

    private void OnGUI()
    {
        if(GUILayout.Button("select", SetGUIStyle(30)))
        {
            
        }
    }

    private void OnGUI2()
    {
        GUI.color=Color.white;
        GUILayout.Label("GameEditor", SetGUIStyle(30));

        scrollPosition=GUILayout.BeginScrollView(scrollPosition);

        #region Item

        for (int i = 0; i < gameData.itemNameListmap.Count; i++)
        {
            Space(10);
            string _name = gameData.itemNameListmap[i].Name;
            List<BaseItem> items = gameData.itemNameListmap[i].ItemList;
            HideHeader("Item-"+_name, _name, i);
            if (toggles[i])
            {
                buttons[i] = "Close";
                BeginVert("GroupBox");
                ItemShow(items);
                EndVert();
            }
            else buttons[i] = "Open";
            EndVert();
        }

        
        #endregion
        
        GUILayout.EndScrollView();
    }

    private void ItemShow(List<BaseItem> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            BaseItem _item = items[i];
            LabelField("Item-" + i, SetGUIStyle(12, Color.white, 10, FontStyle.Italic));
            _item.Name = TextField("Name: ", _item.Name);
            _item.Desc = TextField("Description: ", _item.Desc);
            _item.IsLock = Toggle("IsLock: ", _item.IsLock);
            _item.CostCoin = IntField("CostCoin: ", _item.CostCoin, GUILayout.Width(200));
            _item.Price = IntField("Price: ", _item.Price);
            _item.SpriteName = TextField("SpriteName: ", _item.SpriteName);
            _item.SpritePath = TextField("SpritePath: ", _item.SpritePath);
            Space(20);
        }
        BeginHor();
        if (GUILayout.Button("Add Item"))
        {
            items.Add(new BaseItem());
        }
        if (GUILayout.Button("Remove Item"))
        {
            items.RemoveAt(items.Count - 1);
        }
        EndHor();
        
        EditorUtility.SetDirty(gameData);
    }

    private void HideHeader(string title,string secondTitle,int blockIndex)
    {
        BeginVert();
        LabelField(title, "TL Selection H2");
        BeginHor();
        if (GUILayout.Button(buttons[blockIndex], SetW(50), SetH(25))) toggles[blockIndex] = !toggles[blockIndex];
        BeginHor("HelpBox");
        
        LabelField(secondTitle, "infoHelpBoxText");
        GUILayout.Label("item" + blockIndex, SetW(50), SetH(20));
        EndHor();
        EndHor();
        Space(5);
    }

    #region GUIStyle再封装

    public GUIStyle SetGUIStyle(int _fontSize)
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = _fontSize;
        style.normal.textColor = Color.white;
        style.margin = new RectOffset(200, 0, 5, 0);
        return style;
    }

    public GUIStyle SetGUIStyle(int _fontSize, Color _color)
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = _fontSize;
        style.normal.textColor = _color;
        style.margin = new RectOffset(200, 0, 5, 0);
        return style;
    }

    public GUIStyle SetGUIStyle(int _fontSize, Color _color, int _left, FontStyle _fontStyle = FontStyle.Normal)
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = _fontSize;
        style.normal.textColor = _color;
        style.fontStyle = _fontStyle;
        style.margin = new RectOffset(_left, 0, 5, 0);
        return style;
    }

    #endregion

    #region API简化

    

    private void LabelField(string _text,GUIStyle _style,params GUILayoutOption[] options)
    {
        EditorGUILayout.LabelField(_text, _style, options);
    }

    private string TextField(string _label, string _text, params GUILayoutOption[] options)
    {
        return EditorGUILayout.TextField(_label, _text, options);
    }

    private int IntField(string _label, int _value, params GUILayoutOption[] options)
    {
        return EditorGUILayout.IntField(_label, _value, options);
    }

    private bool Toggle(string _label, bool _value, params GUILayoutOption[] options)
    {
        return EditorGUILayout.Toggle(_label, _value, "Toggle");
    }

    private Sprite ShowSprite(string _label, UnityEngine.Object obj)
    {
        return EditorGUILayout.ObjectField(_label, obj, typeof(Sprite), false) as Sprite;
    }

    private GUILayoutOption SetW(int _w)
    {
        return GUILayout.Width(_w);
    }

    private GUILayoutOption SetH(int _h)
    {
        return GUILayout.Height(_h);
    }

    private void BeginHor()
    {
        GUILayout.BeginHorizontal();
    }

    private void BeginHor(string style)
    {
        GUILayout.BeginHorizontal(style);
    }

    private void EndHor()
    {
        GUILayout.EndHorizontal();
    }

    private void BeginVert()
    {
        GUILayout.BeginVertical();
    }

    private void BeginVert(string style)
    {
        GUILayout.BeginVertical(style);
    }

    private void EndVert()
    {
        GUILayout.EndVertical();
    }

    private void Separator()
    {
        GUILayout.Space(2);
        EditorGUILayout.Separator();
        GUILayout.Space(2);
    }

    private void Space(float height = 5)
    {
        GUILayout.Space(height);
    }

    #endregion


    private void OnDestroy()
    {
        EditorUtility.SetDirty(gameData);
    }

       
}
