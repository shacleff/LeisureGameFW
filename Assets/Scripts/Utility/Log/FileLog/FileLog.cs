using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DesignPattern;

namespace JoeyGame
{
    public enum FIleLogLevel
    {
        LOG=1,
        WARNING=2,
        ASSERT=3,
        ERROR=4,
        Max
    }

    public class LogData
    {
        public string Log { set; get; }
        public string Trace { set; get; }
        public FIleLogLevel Level { set; get; }
    }

    public class FileLog:Singleton<FileLog>
    {
        public delegate void OnGUICallback();
        /// <summary>
        /// UI输出日志等级，只要大于等于这个级别的日志，都会输出到屏幕
        /// </summary>
        public FIleLogLevel uiOutputLogLevel = FIleLogLevel.LOG;
        /// <summary>
        /// 文本输出日志等级
        /// </summary>
        public FIleLogLevel fileOutputLogLevel = FIleLogLevel.Max;
        /// <summary>
        /// unity日志和日志输出等级的映射
        /// </summary>
        private Dictionary<LogType, FIleLogLevel> logTypeLevelDict = null;
        /// <summary>
        /// OnGUI回调
        /// </summary>
        public OnGUICallback onGUICallback = null;
        public List<FileLogOutput> logOutputList = null;
        private int mainThreadID = -1;

        /// <summary>
        /// Unity的Debug.Assert（）在发布版本有问题
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="info"></param>
        public static void Asset(bool condition,string info)
        {
            if (condition) return;
            Debug.LogError(info);
        }

        private FileLog()
        {
            Application.logMessageReceivedThreaded += LogCallback;
            Application.logMessageReceivedThreaded += LogMultiThreadCallback;

            logTypeLevelDict = new Dictionary<LogType, FIleLogLevel>()
            {
                {LogType.Log,FIleLogLevel.LOG },
                {LogType.Warning,FIleLogLevel.WARNING},
                {LogType.Assert,FIleLogLevel.ASSERT},
                {LogType.Error,FIleLogLevel.ERROR },
                {LogType.Exception,FIleLogLevel.ERROR },
            };
            this.uiOutputLogLevel = FIleLogLevel.LOG;
            this.fileOutputLogLevel = FIleLogLevel.ERROR;
            this.mainThreadID = Thread.CurrentThread.ManagedThreadId;
            this.logOutputList = new List<FileLogOutput> { new FileLogOutput(),};

        }

        void OnGUI()
        {
            if (this.onGUICallback != null)
                this.onGUICallback();
        }

        void OnDestroy()
        {
            Application.logMessageReceived -= LogCallback;
            Application.logMessageReceivedThreaded -= LogMultiThreadCallback;
        }
        /// <summary>
        /// 日志调用回调，主线程和其他线程都会回调这个函数，在其中根据配置输出日志
        /// </summary>
        void LogCallback(string _log,string _track,LogType _type)
        {
            if (this.mainThreadID == Thread.CurrentThread.ManagedThreadId)
                Output(_log, _track, _type);
        }

        void LogMultiThreadCallback(string _log,string _track,LogType _type)
        {
            if (this.mainThreadID != Thread.CurrentThread.ManagedThreadId)
                Output(_log, _track, _type);
        }

        void Output(string _log,string _track,LogType _type)
        {
            FIleLogLevel _level = this.logTypeLevelDict[_type];
            LogData _logData = new LogData
            {
                Log = _log,
                Trace = _track,
                Level = _level,
            };
            for (int i = 0; i < this.logOutputList.Count; ++i)
                this.logOutputList[i].Log(_logData);
        }
    }
}
