using System;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using JoeyGame.Tank;

namespace JoeyGame
{
    public class FileLogOutput:ILogOutput
    {
        private string m_devicePath = Application.dataPath+"/";
        static string logPath = "Log";
        private Queue<LogData> mWritingLogQueue = null;
        private Queue<LogData> mWaitingLogQueue = null;
        private object mLogLock = null;
        private Thread mFileLogThread = null;
        private bool mIsRunning = false;
        private StreamWriter mLogWriter = null;

        public FileLogOutput()
        {
            APP.GetInstance().onApplicationQuit += Close;
            this.mWritingLogQueue = new Queue<LogData>();
            this.mWaitingLogQueue = new Queue<LogData>();
            this.mLogLock = new object();
            DateTime _nowTime = DateTime.Now;
            string logName = string.Format("Q{0}{1}{2}{3}{4}{5}", _nowTime.Year, _nowTime.Month
                , _nowTime.Day, _nowTime.Hour, _nowTime.Minute, _nowTime.Second);
            //string logPath="";
            string _logPath = string.Format("{0}/{1}/{2}.log",m_devicePath,logPath,logName);
            
            string logDir = Path.GetDirectoryName(_logPath);
            if (!Directory.Exists(logDir))
                Directory.CreateDirectory(logDir);
            if (File.Exists(_logPath))
                File.Delete(_logPath);
            this.mLogWriter = new StreamWriter(_logPath);
            this.mLogWriter.AutoFlush = true;
            this.mIsRunning = true;
            this.mFileLogThread = new Thread(new ThreadStart(WriteLog));
            this.mFileLogThread.Start();
        }

        private void WriteLog()
        {
            while(this.mIsRunning)
            {
                if(this.mWritingLogQueue.Count==0)
                {
                    lock(this.mLogLock)
                    {
                        while (this.mWaitingLogQueue.Count == 0)
                            Monitor.Wait(this.mLogLock);
                        Queue<LogData> tmpQueue = this.mWaitingLogQueue;
                        this.mWritingLogQueue = this.mWaitingLogQueue;
                        this.mWaitingLogQueue = tmpQueue;
                    }
                }
                else
                {
                    while(this.mWritingLogQueue.Count>0)
                    {
                        LogData _log = this.mWritingLogQueue.Dequeue();
                        if(_log.Level== FIleLogLevel.ERROR)
                        {
                            this.mLogWriter.WriteLine("............");
                            this.mLogWriter.WriteLine(_log.Log);
                            this.mLogWriter.WriteLine(_log.Trace);
                            this.mLogWriter.WriteLine("..............");
                        }
                        else
                        {
                            this.mLogWriter.WriteLine(_log.Log);
                        }
                    }
                }
            }

        }

        


        public void Log(LogData _logData)
        {
            lock(this.mLogLock)
            {
                this.mWaitingLogQueue.Enqueue(_logData);
                Monitor.Pulse(this.mLogLock);
            }
        }

        public void Close()
        {
            this.mIsRunning = false;
            this.mLogWriter.Close();
        }
    }
}
