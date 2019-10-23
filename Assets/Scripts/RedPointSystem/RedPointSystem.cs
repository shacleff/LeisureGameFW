using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 红点系统
/// 链接：https://zhuanlan.zhihu.com/p/87104548
/// 概况：
///          
/// 红点系统
///     1、结构层：部署红点的层级结构
///     2、驱动层：如何驱动这个树结构产生状态变化，以及状态变化之后如何将变化的行为通知到指定的表现层
///     3、表现层：就专门承担表现的职责
/// 
/// 树结构例子：
///     主界面
///         1、工会
///         2、任务
///         3、邮件
///             (1).系统
///             (2).队伍
///             (3).工会
/// </summary>
public class RedPointSystem : Singleton<RedPointSystem>
{
    public delegate void OnPointNumChange(RedPointNode _node);

    private RedPointNode mRoot;

    public static List<string> RedPointTrees = new List<string>();

    private RedPointSystem() { }

    /// <summary>
    /// 初始化红点系统
    /// </summary>
    public void Init()
    {
        RedPointTrees.Add(RedPointConst.MAIN);
        RedPointTrees.Add(RedPointConst.MAIL);
        RedPointTrees.Add(RedPointConst.TASK);
        RedPointTrees.Add(RedPointConst.ALLIANCE);
        RedPointTrees.Add(RedPointConst.MAIL_ALLIANCE);
        RedPointTrees.Add(RedPointConst.MAIL_SYSTEM);
        RedPointTrees.Add(RedPointConst.MAIL_TEAM);

        mRoot = new RedPointNode();
        mRoot.NodeName = RedPointConst.MAIN;

        foreach (string _nodeName in RedPointTrees)
        {
            RedPointNode _root = mRoot;
            string[] _nodeNameArr = _nodeName.Split('.');
            if (_nodeNameArr[0] != _root.NodeName)
            {
                Debug.LogWarning("node error:" + _nodeNameArr[0]);
                continue;
            }
            if (_nodeNameArr.Length > 1)
            {
                for (int i = 0; i < _nodeNameArr.Length; i++)
                {
                    if (!_root.nodeChilds.ContainsKey(_nodeNameArr[i]))
                    {
                        _root.nodeChilds.Add(_nodeNameArr[i], new RedPointNode());
                    }
                    _root.nodeChilds[_nodeNameArr[i]].NodeName = _nodeNameArr[i];
                    _root.nodeChilds[_nodeNameArr[i]].Parent = _root;
                    _root = _root.nodeChilds[_nodeNameArr[i]];
                }
            }
        }
    }

    /// <summary>
    /// 树结构设置事件回调
    /// </summary>
    /// <param name="_nodeName"></param>
    /// <param name="_callback"></param>
    public void SetRedPointCallBack(string _nodeName, OnPointNumChange _callback)
    {
        RedPointNode _root = mRoot;
        string[] _nodeNameArr = _nodeName.Split('.');
        if (_nodeNameArr.Length == 1)
        {
            if (_nodeNameArr[0] != RedPointConst.MAIN)
            {
                Debug.LogError("Node Error:" + _nodeNameArr[0]);
                return;
            }
        }
        for (int i = 0; i < _nodeNameArr.Length; i++)
        {
            if (!_root.nodeChilds.ContainsKey(_nodeNameArr[i]))
            {
                Debug.LogError("This Node not Contains Child " + _nodeNameArr[i]);
                return;
            }
            _root = _root.nodeChilds[_nodeNameArr[i]];
            if (i == _nodeNameArr.Length - 1)
            {
                _root.PointNumChange = _callback;
                return;
            }
        }
    }

    /// <summary>
    /// 设置红点驱动
    /// </summary>
    /// <param name="_nodeName"></param>
    /// <param name="_pointNum"></param>
    public void SetInvoke(string _nodeName,int _pointNum)
    {
        RedPointNode _root = mRoot;
        string[] _nodeNameArr = _nodeName.Split('.');
        if (_nodeNameArr.Length == 1)
        {
            if (_nodeNameArr[0] != RedPointConst.MAIN)
            {
                Debug.LogError("Node Error:" + _nodeNameArr[0]);
                return;
            }
        }
        for (int i = 0; i < _nodeNameArr.Length; i++)
        {
            if (!_root.nodeChilds.ContainsKey(_nodeNameArr[i]))
            {
                Debug.LogError("This Node not Contains Child " + _nodeNameArr[i]);
                return;
            }
            _root = _root.nodeChilds[_nodeNameArr[i]];
            if (i == _nodeNameArr.Length - 1)
            {
                _root.SetRedPointNum(_pointNum);
            }
        }
    }


}
