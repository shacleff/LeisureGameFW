using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [HideInInspector]
    public GameObject startBtn, achievementBtn, missionBtn, settingBtn, shopBtn, bagBtn, rankBtn, giftBtn;
    //public GameObject achievementBtn;
    //public GameObject missionBtn;
    //public GameObject settingBtn;
    //public GameObject shopBtn;
    //public GameObject bagBtn;
    //public GameObject rankBtn;
    //public GameObject giftBtn;

    [HideInInspector]
    public bool StartBtnSwitch=true;
    [HideInInspector]
    public bool achievementBtnSwitch = true;
    [HideInInspector]
    public bool missionBtnSwitch = true;
    [HideInInspector]
    public bool settingBtnSwitch = true;
    [HideInInspector]
    public bool shopBtnSwitch = true;
    [HideInInspector]
    public bool bagBtnSwitch = true;
    [HideInInspector]
    public bool rankBtnSwitch = true;
    [HideInInspector]
    public bool giftBtnSwitch = true;


    // Start is called before the first frame update
    void Start()
    {
        toggleSwitch();

        startBtn.GetComponent<Button>().onClick.AddListener(PlayGame);
        achievementBtn.GetComponent<Button>().onClick.AddListener(OpenAchievementPanel);
        missionBtn.GetComponent<Button>().onClick.AddListener(OpenMissionPanel);
        settingBtn.GetComponent<Button>().onClick.AddListener(OpenSettingPanel);
        shopBtn.GetComponent<Button>().onClick.AddListener(OpenShopPanel);
        bagBtn.GetComponent<Button>().onClick.AddListener(OpenBagPanel);
        rankBtn.GetComponent<Button>().onClick.AddListener(OpenRankPanel);
        giftBtn.GetComponent<Button>().onClick.AddListener(OpenGiftPanel);
    }

    public void toggleSwitch()
    {
        startBtn.SetActive(StartBtnSwitch);
        achievementBtn.SetActive(achievementBtnSwitch);
        missionBtn.SetActive(missionBtnSwitch);
        settingBtn.SetActive(settingBtnSwitch);
        shopBtn.SetActive(shopBtnSwitch);
        bagBtn.SetActive(bagBtnSwitch);
        rankBtn.SetActive(rankBtnSwitch);
        giftBtn.SetActive(giftBtnSwitch);
        
    }

    private void PlayGame()
    {
        UIController.GetInstance().PlayGame();
    }

    public void OpenAchievementPanel()
    {
        UIController.GetInstance().OpenAchievementPanel();
    }

    public void OpenMissionPanel()
    {
        UIController.GetInstance().OpenMissionPanel();
    }

    public void OpenSettingPanel()
    {
        UIController.GetInstance().OpenSettingPanel();
    }

    public void OpenShopPanel()
    {
        UIController.GetInstance().OpenShopPanel();
    }

    public void OpenBagPanel()
    {
        UIController.GetInstance().OpenBagPanel();
    }

    public void OpenRankPanel()
    {
        UIController.GetInstance().OpenRankPanel();
    }

    public void OpenGiftPanel()
    {
        UIController.GetInstance().OpenGiftPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
