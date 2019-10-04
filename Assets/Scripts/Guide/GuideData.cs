using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GuideData
{
    public int ID { get; set; }
    public int MarkID { get; set; }
    private List<TriggerData> triggerLists = new List<TriggerData>();
    private List<TriggerData> conditionLists = new List<TriggerData>();
    private List<TriggerData> actionLists = new List<TriggerData>();

    public GuideData()
    {

    }

    public GuideData(int _id,int _markID,string _trigger,string _condition,string _action)
    {
        this.ID = _id;
        this.MarkID = _markID;
        ParseTrigger(_trigger);
        ParseCondition(_condition);
        ParseAction(_action);
    }

    public GuideData(string _id, string _markID, string _trigger, string _condition, string _action)
    {
        this.ID = int.Parse(_id);
        this.MarkID = int.Parse(_markID);
        ParseTrigger(_trigger);
        ParseCondition(_condition);
        ParseAction(_action);
    }

    public void ParseTrigger(string _triggerStr)
    {
        ParseString(_triggerStr,out triggerLists);

    }

    public void ParseCondition(string _triggerStr)
    {
        ParseString(_triggerStr, out conditionLists);
    }

    public void ParseAction(string _triggerStr)
    {
        ParseString(_triggerStr,out actionLists);
    }

    /// <summary>
    /// 解析 A,B,C|A,B,C| 格式字符串
    /// </summary>
    private void ParseString(string _triggerStr,out List<TriggerData> _lists)
    {
        _lists = new List<TriggerData>();
        TriggerData trigger = new TriggerData();
        string[] tempArr = _triggerStr.Split('|');
        for (int i = 0; i < tempArr.Length; i++)
        {
            string[] tempArr2 = tempArr[i].Split(':');
            trigger = new TriggerData();
            trigger.val1 =int.Parse(tempArr2[0]);
            string[] tempArr3 = tempArr2[1].Split(',');
            trigger.val2 = tempArr3[0];
            if(tempArr3.Length>1) trigger.val3 = int.Parse(tempArr3[1]);
            _lists.Add(trigger);
        }
    }
}

public class TriggerData
{
    public int val1;
    public string val2;
    public int val3;
}

public class ConditionData
{

}

public class ActionData
{

}

public class GuideTable
{
    public int ID;
    /// <summary>
    ///  格式：
    /// </summary>
    public string Trigger;
    public string Condition;
    public string Action;
    public int MarkID;

}

