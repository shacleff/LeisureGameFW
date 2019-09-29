using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OfflinePopup : BasePopup
{
    public GameObject CollectBtn;
    public GameObject CloseBtn;
    public Text CoinTxt;
    public Text TimerTxt;

    public override void Awake()
    {
        base.Awake();
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

    public override void Exit()
    {
        base.Exit();
        Destroy(gameObject);
    }

}
