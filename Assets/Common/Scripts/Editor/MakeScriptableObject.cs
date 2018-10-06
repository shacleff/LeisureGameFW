using UnityEngine;
using UnityEditor;

public class MakeScriptableObject
{
    [MenuItem("Tools/MyTool/Create My Scriptable Object")]
    public static void DoIt()
    {
        MyScriptableObject asset = ScriptableObject.CreateInstance<MyScriptableObject>();
        AssetDatabase.CreateAsset(asset, "Assets/MyScriptableObject.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }

    [MenuItem("Tools/MyTool/CreateItemData")]
    public static void MakeItemData()
    {
        GameData _itemData = ScriptableObject.CreateInstance<GameData>();
        AssetDatabase.CreateAsset(_itemData, "Assets/GameDataObject.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = _itemData;
    }
}