﻿using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System;
using System.Collections.Generic;
using DesignPattern;
using JoeyGame.Tank;

namespace JoeyGame
{

    public class GUIConsole : Singleton<GUIConsole>
    {
        
        struct ConsoleMessage
        {
            public readonly string message;
            public readonly string stackTrace;
            public readonly LogType type;

            public ConsoleMessage(string message, string stackTrace, LogType type)
            {
                this.message = message;
                this.stackTrace = stackTrace;
                this.type = type;
            }
        }

        /// <summary>
        /// Update回调
        /// </summary>
        public delegate void OnUpdateCallback();
        /// <summary>
        /// OnGUI回调
        /// </summary>
        public delegate void OnGUICallback();

        public OnUpdateCallback onUpdateCallback = null;
        public OnGUICallback onGUICallback = null;
        /// <summary>
        /// FPS计数器
        /// </summary>
        private FPSCounter fpsCounter = null;
        /// <summary>
        /// 内存监视器
        /// </summary>
        private MemoryDetector memoryDetector = null;
        private bool showGUI = true;
        List<ConsoleMessage> entries = new List<ConsoleMessage>();
        Vector2 scrollPos;
        bool scrollToBottom = true;
        bool collapse;

        const int margin = 20;
        Rect windowRect = new Rect(margin + Screen.width * 0.5f, margin, Screen.width * 0.5f - (2 * margin), Screen.height - (2 * margin)-800);

        GUIContent clearLabel = new GUIContent("Clear", "Clear the contents of the console.");
        GUIContent collapseLabel = new GUIContent("Collapse", "Hide repeated messages.");
        GUIContent scrollToBottomLabel = new GUIContent("ScrollToBottom", "Scroll bar always at bottom");


        private GUIConsole()
        {
            this.fpsCounter = new FPSCounter(this);
            this.memoryDetector = new MemoryDetector(this);
            //        this.showGUI = App.Instance().showLogOnGUI;
            App.GetInstance().onUpdate += Update;
            App.GetInstance().onGUI += OnGUI;
            Application.logMessageReceived += HandleLog;

        }

        ~GUIConsole()
        {
            Application.logMessageReceived -= HandleLog;
        }


        void Update()
        {
#if UNITY_EDITOR
            if (Input.GetKeyUp(KeyCode.F1))
                this.showGUI = !this.showGUI;
#elif UNITY_ANDROID
            if (Input.GetKeyUp(KeyCode.Escape))
                this.showGUI = !this.showGUI;
#elif UNITY_IOS
            if (!mTouching && Input.touchCount == 4)
            {
                mTouching = true;
                this.showGUI = !this.showGUI;
            } else if (Input.touchCount == 0){
                mTouching = false;
            }
#endif

            if (this.onUpdateCallback != null)
                this.onUpdateCallback();
        }

        void OnGUI()
        {
            if (!this.showGUI)
                return;

            if (this.onGUICallback != null)
                this.onGUICallback();

            if (GUI.Button(new Rect(10, 200, 80, 50), "清空数据"))
            {
                PlayerPrefs.DeleteAll();
#if UNITY_EDITOR
                EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            }
            windowRect = GUILayout.Window(123456, windowRect, ConsoleWindow, "Console");
        }


        /// <summary>
        /// A window displaying the logged messages.
        /// </summary>
        void ConsoleWindow(int windowID)
        {
            if (scrollToBottom)
            {
                GUILayout.BeginScrollView(Vector2.up * entries.Count * 100.0f);
            }
            else
            {
                scrollPos = GUILayout.BeginScrollView(scrollPos);
            }
            // Go through each logged entry
            for (int i = 0; i < entries.Count; i++)
            {
                ConsoleMessage entry = entries[i];
                // If this message is the same as the last one and the collapse feature is chosen, skip it
                if (collapse && i > 0 && entry.message == entries[i - 1].message)
                {
                    continue;
                }
                // Change the text colour according to the log type
                switch (entry.type)
                {
                    case LogType.Error:
                    case LogType.Exception:
                        GUI.contentColor = Color.red;
                        break;
                    case LogType.Warning:
                        GUI.contentColor = Color.yellow;
                        break;
                    default:
                        GUI.contentColor = Color.white;
                        break;
                }
                if (entry.type == LogType.Exception)
                {
                    GUILayout.Label(entry.message + " || " + entry.stackTrace);
                }
                else
                {
                    GUILayout.Label(entry.message);
                }
            }
            GUI.contentColor = Color.white;
            GUILayout.EndScrollView();
            GUILayout.BeginHorizontal();
            // Clear button
            if (GUILayout.Button(clearLabel))
            {
                entries.Clear();
            }
            // Collapse toggle
            collapse = GUILayout.Toggle(collapse, collapseLabel, GUILayout.ExpandWidth(false));
            scrollToBottom = GUILayout.Toggle(scrollToBottom, scrollToBottomLabel, GUILayout.ExpandWidth(false));
            GUILayout.EndHorizontal();
            // Set the window to be draggable by the top title bar
            GUI.DragWindow(new Rect(0, 0, 10000, 20));
        }

        void HandleLog(string message, string stackTrace, LogType type)
        {
            ConsoleMessage entry = new ConsoleMessage(message, stackTrace, type);
            entries.Add(entry);
        }
    }
}


