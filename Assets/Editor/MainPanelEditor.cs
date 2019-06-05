using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MainPanel))]
public class MainPanelEditor : Editor
{
    private MainPanel script;
    public bool BtnSwitch = false;
    public bool mainBtns = true;

    private void OnEnable()
    {
        script = (MainPanel)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        mainBtns = EditorGUILayout.Foldout(mainBtns, "mainBtns");

        if (mainBtns)
        {
            script.startBtn = (GameObject)EditorGUILayout.ObjectField("startBtn", script.startBtn, typeof(UnityEngine.GameObject), true);
            script.achievementBtn = (GameObject)EditorGUILayout.ObjectField("achievementBtn", script.achievementBtn, typeof(UnityEngine.GameObject), true);
            script.missionBtn = (GameObject)EditorGUILayout.ObjectField("missionBtn", script.missionBtn, typeof(UnityEngine.GameObject), true);
            script.settingBtn = (GameObject)EditorGUILayout.ObjectField("settingBtn", script.settingBtn, typeof(UnityEngine.GameObject), true);
            script.shopBtn = (GameObject)EditorGUILayout.ObjectField("shopBtn", script.shopBtn, typeof(UnityEngine.GameObject), true);
            script.bagBtn = (GameObject)EditorGUILayout.ObjectField("bagBtn", script.bagBtn, typeof(UnityEngine.GameObject), true);
            script.rankBtn = (GameObject)EditorGUILayout.ObjectField("rankBtn", script.rankBtn, typeof(UnityEngine.GameObject), true);
            script.giftBtn = (GameObject)EditorGUILayout.ObjectField("giftBtn", script.giftBtn, typeof(UnityEngine.GameObject), true);
            script.levelBtn = (GameObject)EditorGUILayout.ObjectField("levelBtn", script.levelBtn, typeof(UnityEngine.GameObject), true);
        }

        BtnSwitch = EditorGUILayout.Foldout(BtnSwitch, "可用按钮开关");
        if (BtnSwitch)
        {
            script.StartBtnSwitch = EditorGUILayout.Toggle("StartBtnSwitch", script.StartBtnSwitch);
            script.achievementBtnSwitch = EditorGUILayout.Toggle("achievementBtnSwitch", script.achievementBtnSwitch);
            script.missionBtnSwitch = EditorGUILayout.Toggle("missionBtnSwitch", script.missionBtnSwitch);
            script.settingBtnSwitch = EditorGUILayout.Toggle("settingBtnSwitch", script.settingBtnSwitch);
            script.shopBtnSwitch = EditorGUILayout.Toggle("shopBtnSwitch", script.shopBtnSwitch);
            script.bagBtnSwitch = EditorGUILayout.Toggle("bagBtnSwitch", script.bagBtnSwitch);
            script.rankBtnSwitch = EditorGUILayout.Toggle("rankBtnSwitch", script.rankBtnSwitch);
            script.giftBtnSwitch = EditorGUILayout.Toggle("giftBtnSwitch", script.giftBtnSwitch);
            script.levelBtnSwitch = EditorGUILayout.Toggle("levelBtnSwitch", script.levelBtnSwitch);
        }

        serializedObject.ApplyModifiedProperties();
        //string path
    }
}
