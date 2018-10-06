﻿//#define UAS
//#define CHUPA
#define SMA

using System;
using UnityEditor;
using UnityEngine;


public class SellReadMeInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("1. Edit Game Settings (Admob, In-app Purchase..)", EditorStyles.boldLabel);

        if (GUILayout.Button("Edit Game Settings", GUILayout.MinHeight(40)))
        {
#if UAS
            Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/Vortex/Common/Prefabs/GameMaster.prefab");
#else
            Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/Common/Prefabs/GameMaster.prefab");
#endif
        }

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("2. Game Documentation", EditorStyles.boldLabel);
#if UAS
        if (GUILayout.Button("Set Up (Important)", GUILayout.MinHeight(40)))
        {
            Application.OpenURL("https://drive.google.com/open?id=1iQX4Y_15DZX1sX2OvKXvsqM-GA3Sd7XpLNxDyOSq9hM");
        }
        EditorGUILayout.Space();
#endif

        if (GUILayout.Button("Open Full Documentation", GUILayout.MinHeight(40)))
        {
			Application.OpenURL("https://drive.google.com/open?id=1RJTAcX7rUlsQbDxkAjfjUBbAoS6HWdRtxSmuYKkv3i0");
        }

        EditorGUILayout.Space();
        if (GUILayout.Button("Build For iOS Video Guide", GUILayout.MinHeight(40)))
        {
			Application.OpenURL("https://www.youtube.com/watch?v=f0TfqG9_Xbc");
        }

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("3. My Other Great Source Codes", EditorStyles.boldLabel);
        if (GUILayout.Button("Hexa Puzzle Block", GUILayout.MinHeight(30)))
        {
#if UAS
            Application.OpenURL("https://www.assetstore.unity3d.com/en/#!/content/85474");
#elif CHUPA
            Application.OpenURL("https://www.chupamobile.com/unity-board/block-hexa-puzzle-unity-in-top-free-game-16762");
#elif SMA
            Application.OpenURL("https://www.sellmyapp.com/downloads/hexa-puzzle-blocks-top-free-game/");
#endif
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Word Search Cookies", GUILayout.MinHeight(30)))
        {
#if UAS
            Application.OpenURL("https://www.assetstore.unity3d.com/en/#!/content/88864");
#elif CHUPA
            Application.OpenURL("https://www.chupamobile.com/unity-puzzle/word-chef-cookies-top-free-game-17252");
#elif SMA
            Application.OpenURL("https://www.sellmyapp.com/downloads/word-chef-cookies-top-free-game/");
#endif
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Unroll Ball - Slide Puzzle", GUILayout.MinHeight(30)))
        {
#if UAS
            Application.OpenURL("https://www.assetstore.unity3d.com/en/#!/content/99663");
#elif CHUPA
            Application.OpenURL("https://www.chupamobile.com/unity-puzzle/unroll-ball-slide-puzzle-18557");
#elif SMA
            Application.OpenURL("https://www.sellmyapp.com/downloads/unroll-ball-slide-puzzle/");
#endif
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Unblock Me", GUILayout.MinHeight(30)))
        {
#if UAS
            Application.OpenURL("https://www.assetstore.unity3d.com/en/#!/content/69070");
#elif CHUPA
            Application.OpenURL("https://www.chupamobile.com/unity-casual/unblock-me-12590");
#elif SMA
            Application.OpenURL("https://www.sellmyapp.com/downloads/unblock-me-2/");
#endif
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Cut The Rope", GUILayout.MinHeight(30)))
        {
            Application.OpenURL("https://www.chupamobile.com/unity-arcade/cut-my-rope-12320");
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Rolling Sky", GUILayout.MinHeight(30)))
        {
#if CHUPA || UAS
            Application.OpenURL("https://www.chupamobile.com/unity-arcade/rolling-ball-on-sky-15053");
#elif SMA
            Application.OpenURL("https://www.sellmyapp.com/downloads/rolling-ball-on-sky/");
#endif
        }

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("4. Contact Us For Support", EditorStyles.boldLabel);
        EditorGUILayout.TextField("Email: ", "phuongdong0702@gmail.com");
        EditorGUILayout.TextField("Skype: ", "phuongdong0702");
    }
}