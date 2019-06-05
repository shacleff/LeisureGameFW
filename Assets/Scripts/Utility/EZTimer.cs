/*
 * Author:      熊哲
 * CreateTime:  2/1/2018 12:31:35 PM
 * Description:
 * 倒计时任务，正常来说有几个全局的就够了
*/
using System;
using System.Collections.Generic;
using UnityEngine;

public class EZTimer : MonoBehaviour
{
    public class Task
    {
        public float delay;
        public bool loop;
        public Action action;

        public float countdown { get; private set; }
        public bool dead { get; private set; }

        public Task(float delay, bool loop, Action action)
        {
            this.delay = delay;
            this.loop = loop;
            this.action = action;
            countdown = this.delay;
            dead = false;
        }

        public bool Tick(float timespan) // return true if action called
        {
            if (dead) return false;
            countdown -= timespan;
            if (countdown <= 0)
            {
                action();
                if (loop)
                {
                    countdown = delay;
                }
                else
                {
                    dead = true;
                }
                return true;
            }
            return false;
        }
        public void Reset()
        {
            countdown = delay;
            dead = false;
        }
        public void Kill()
        {
            dead = true;
        }
    }

    public enum TickMode { Default = 0, Fixed = 1, Unscaled = 2, FixedUnscaled = 3, }

    [SerializeField]
    private TickMode m_TickMode = TickMode.Default;
    public TickMode tickMode { get { return m_TickMode; } set { m_TickMode = value; } }

    public int taskCount { get { return taskList.Count; } }

    private List<Task> taskList = new List<Task>();

    public void Schedule(Task task)
    {
        taskList.Add(task);
    }
    protected void Tick(float timespan)
    {
        for (int i = 0; i < taskList.Count; i++)
        {
            Task task = taskList[i];
            if (task.Tick(timespan))
            {
                if (task.dead) taskList.Remove(task);
            }
        }
    }

    void Update()
    {
        switch (tickMode)
        {
            case TickMode.Default:
                Tick(Time.deltaTime);
                break;
            case TickMode.Unscaled:
                Tick(Time.unscaledDeltaTime);
                break;
        }
    }
    void FixedUpdate()
    {
        switch (tickMode)
        {
            case TickMode.Fixed:
                Tick(Time.fixedDeltaTime);
                break;
            case TickMode.FixedUnscaled:
                Tick(Time.fixedUnscaledDeltaTime);
                break;
        }
    }
}
