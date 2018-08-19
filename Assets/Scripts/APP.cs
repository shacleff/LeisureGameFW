using DesignPattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoeyGame
{
    public class APP : MonoSingleton<APP>
    {
        public enum GameMode
        {
            QA,
            Developing,
            Release
        }

        public GameMode gameMode = GameMode.Developing;
        public bool isShowTheFileLog = false;
        public bool ShowTheTestObject = false;

        public delegate void LifeCircleCallback();

        public event LifeCircleCallback onUpdate = null;
        public event LifeCircleCallback onFixedUpdate = null;
        public event LifeCircleCallback onLatedUpdate = null;
        public event LifeCircleCallback onGUI = null;
        public event LifeCircleCallback onDestroy = null;
        public event LifeCircleCallback onApplicationQuit = null;

        private APP() { }


        void Awake()
        {
            DontDestroyOnLoad(this);
            InitBaseCompoenet();

            Instance = this;
            Application.targetFrameRate = 60;
        }

        void Start()
        {

            LogHelper _logHelper = new LogHelper();
            Log.SetLogHelper(_logHelper);
        }

        void Update()
        {
            if (this.onUpdate != null)
                this.onUpdate();

            if (Input.GetKeyDown(KeyCode.Space))
            {
#if UNITY_EDITOR
                if (!UnityEditor.EditorApplication.isPaused)
                    UnityEditor.EditorApplication.isPaused = true;
                else
                    UnityEditor.EditorApplication.isPaused = false;
#endif
            }

        }

        private void InitBaseCompoenet()
        {
        }

        private IEnumerator FinishLaunching()
        {

            yield return null;
        }

        void FixedUpdate()
        {
            if (this.onFixedUpdate != null)
                this.onFixedUpdate();
        }

        void LateUpdate()
        {
            if (this.onLatedUpdate != null)
                this.onLatedUpdate();
        }

        void OnApplicationQuit()
        {
            if (this.onApplicationQuit != null)
                this.onApplicationQuit();
        }

        void OnGUI()
        {
            if (this.onGUI != null)
                this.onGUI();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (this.onDestroy != null)
                this.onDestroy();
        }
    }
}



   
