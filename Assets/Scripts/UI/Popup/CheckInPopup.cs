using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 所有弹窗应该由一个类统一管理弹出，这样不会造成多个弹窗出现由此带来的不必要的冲突
/// </summary>
public class CheckInPopup : BasePopup
{
    public GameObject daysParent;
    /// <summary>
    /// 签到信息（内容，奖励）
    /// </summary>
    private object _dayDatas;

    public override void Awake()
    {
        base.Awake();
        this.popupType = PopupType.CheckIn;
    }

    public void SetDaysInfo(Sprite[] _daySprites)
    {
        for (int i = 0; i < daysParent.transform.childCount; i++)
        {
            CheckInDay checkInDay = daysParent.transform.GetChild(i).GetComponent<CheckInDay>();
            checkInDay.SetDayInfo(_daySprites[i], string.Format("第{0}天", (i + 1)));
        }
    }

    public override void Enter()
    {
        base.Enter();

    }

    public override void Exit()
    {
        base.Exit();
        gameObject.SetActive(false);
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }
}
