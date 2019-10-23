/**
 * 
 * Author:JoeyHuang
 * Time: 2019/10/23 14:04:17
 * 说明：
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RedPointNode
{
    /// <summary>
    /// 节点名称
    /// </summary>
    public string NodeName;
    /// <summary>
    /// 红点数量
    /// </summary>
    public int PointNum;
    /// <summary>
    /// 父对象
    /// </summary>
    public RedPointNode Parent;
    /// <summary>
    /// 红点发生变化的回调函数
    /// </summary>
    public RedPointSystem.OnPointNumChange PointNumChange;
    /// <summary>
    /// 红点孩子节点
    /// </summary>
    public Dictionary<string, RedPointNode> nodeChilds = new Dictionary<string, RedPointNode>();


    public void SetRedPointNum(int _pointNum)
    {
        if(nodeChilds.Count>0)
        {
            return;
        }
        PointNum = _pointNum;
        NotifyPointNumChange();
        if(Parent!=null)
        {
            Parent.ChangeRedPointNum();
        }

    }

    public void ChangeRedPointNum()
    {
        int num = 0;
        foreach (RedPointNode _node in nodeChilds.Values)
        {
            num += _node.PointNum;
        }
        if(num!=PointNum)
        {
            PointNum = num;
            NotifyPointNumChange();
        }
    }

    public void NotifyPointNumChange()
    {
        PointNumChange?.Invoke(this);
    }


}
