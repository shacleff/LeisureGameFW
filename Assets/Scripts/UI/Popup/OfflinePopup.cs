using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 所有弹窗应该由一个类统一管理弹出，这样不会造成多个弹窗出现由此带来的不必要的冲突
/// </summary>
public class OfflinePopup : BasePopup
{
    public GameObject CollectBtn;
    public GameObject CloseBtn;
    public Text CoinTxt;
    public Text TimerTxt;

    public override void Awake()
    {
        base.Awake();
        this.popupType = PopupType.OfflinePopup;
    }


    public override void Start()
    {
        base.Start();
        CloseBtn.GetComponent<Button>().onClick.AddListener(Exit);
        CollectBtn.GetComponent<Button>().onClick.AddListener(RewardHandle);
    }

    private void RewardHandle()
    {
        
    }

    public override void Update()
    {
        base.Update();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        TimerTxt.text = DateTimeUtility.TimeString(OfflineTime.GetInstance().OfflineDuration, DateTimeUtility.TimeFormat.M_S);
        //TimerTxt.text=""
    }

    /// <summary>
    /// 进入弹窗，并传入/更新弹窗信息
    /// </summary>
    /// <param name="_data"></param>
    public override void Enter(object _data = null)
    {
        base.Enter(_data);
    }

    public override void Exit()
    {
        base.Exit();
        Destroy(gameObject);
    }

}
