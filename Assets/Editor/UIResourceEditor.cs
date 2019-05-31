using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using FileUtility;

[CustomEditor(typeof(UIResourceManager))]
public class UIResourceEditor : Editor
{
    private UIResourceManager script;
    string subPath = "Resource";

    void OnEnable()
    {
        script = (UIResourceManager)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.HelpBox("选中Item sprite所在的文件夹，然后点击LoadSprite", MessageType.Info);
        //subPath=EditorGUILayout.TextField("subPath: ",subPath);
        string[] guids = Selection.assetGUIDs;

        if (GUILayout.Button("LoadSprite", GUILayout.Height(30)))
        {
            if (guids.Length == 0) Debug.LogError("你没有选中文件夹");
            string path = AssetDatabase.GUIDToAssetPath(guids[0]);
            script.spriteArr.Clear();
            string[] ext = { ".png" };
            List<string> files = FileManager.GetExtensionFileName(path + "/", ext);
            for (int i = 0; i < files.Count; i++)
            {
                Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(path + "/" + files[i]);
                script.spriteArr.Add(sprite);
            }
        }
        

        serializedObject.ApplyModifiedProperties();
        //string path
    }

}



