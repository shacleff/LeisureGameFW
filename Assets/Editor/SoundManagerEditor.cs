using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using FileUtility;

[CustomEditor(typeof(SoundManager))]
public class SoundManagerEditor : Editor
{
    private SoundManager soundManager;

    private void OnEnable()
    {
        soundManager = (SoundManager)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        //soundManager.audio = (GameObject)EditorGUILayout.ObjectField("startBtn", script.startBtn, typeof(UnityEngine.GameObject), true);

        EditorGUILayout.HelpBox("选中Item sprite所在的文件夹，然后点击LoadSprite", MessageType.Info);
        string[] soundGuids = Selection.assetGUIDs;
        if (GUILayout.Button("LoadAudioList", GUILayout.Height(30)))
        {
            if (soundGuids.Length == 0) Debug.LogError("你没有选中文件夹");
            string path = AssetDatabase.GUIDToAssetPath(soundGuids[0]);
            soundManager.soundList.Clear();
            string[] ext = { ".mp3",".wav",".ogg","m4r",".flac" };
            List<string> files = FileManager.GetExtensionFileName(path + "/", ext);
            for (int i = 0; i < files.Count; i++)
            {
                AudioClip clip = AssetDatabase.LoadAssetAtPath<AudioClip>(path + "/" + files[i]);
                soundManager.soundList.Add(clip);
            }
        }
        
        serializedObject.ApplyModifiedProperties();

    }
}
