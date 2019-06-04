using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Events;

public class MainPanel : MonoBehaviour
{
    [HideInInspector]
    public GameObject startBtn, achievementBtn, missionBtn, settingBtn, shopBtn, bagBtn, rankBtn, giftBtn;

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

    public Text coinText;
    public Text gemText;


    // Start is called before the first frame update
    void Start()
    {
        toggleSwitch();


        EventTriggerListener.Get(startBtn).onClick += OpenPanelBtnHandler;
        EventTriggerListener.Get(achievementBtn).onClick += OpenPanelBtnHandler;
        EventTriggerListener.Get(missionBtn).onClick += OpenPanelBtnHandler;
        EventTriggerListener.Get(settingBtn).onClick += OpenPanelBtnHandler;
        EventTriggerListener.Get(shopBtn).onClick += OpenPanelBtnHandler;
        EventTriggerListener.Get(bagBtn).onClick += OpenPanelBtnHandler;
        EventTriggerListener.Get(rankBtn).onClick += OpenPanelBtnHandler;
        EventTriggerListener.Get(giftBtn).onClick += OpenPanelBtnHandler;

        this.coinText.text = GameManagers.GetInstance().Coin.ToString();
        this.gemText.text = GameManagers.GetInstance().Gem.ToString();
        EventManager.Instance.AddEventListener(EventArg.COIN_CHANGE, UpdateCoin);
        EventManager.Instance.AddEventListener(EventArg.GEM_CHANGE, UpdateGem);
    }

    private void UpdateCoin(object param)
    {
        this.coinText.text = param.ToString();
    }

    private void UpdateGem(object param)
    {
        this.gemText.text = param.ToString();
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

    public void OpenPanelBtnHandler(GameObject obj)
    {
        switch (obj.name)
        {
            case "startBtn":
                UIController.GetInstance().PlayGame();
                SoundManager.Instance.PlaySound(0);
                break;
            case "achievementBtn":
                UIController.GetInstance().OpenAchievementPanel();
                SoundManager.Instance.PlaySound(1);
                break;
            case "missionBtn":
                UIController.GetInstance().OpenMissionPanel();
                SoundManager.Instance.PlaySound(2);
                break;
            case "settingBtn":
                UIController.GetInstance().OpenSettingPanel();
                SoundManager.Instance.PlaySound(3);
                break;
            case "shopBtn":
                UIController.GetInstance().OpenShopPanel();
                break;
            case "bagBtn":
                UIController.GetInstance().OpenBagPanel();
                break;
            case "rankBtn":
                UIController.GetInstance().OpenRankPanel();
                break;
            case "giftBtn":
                UIController.GetInstance().OpenGiftPanel();
                break;
            default:
                break;
        }
    }

    private void PlayGame()
    {
        
    }

    public void OpenAchievementPanel()
    {
        
    }

    public void OpenMissionPanel()
    {
        
    }

    public void OpenSettingPanel()
    {
        
    }

    public void OpenShopPanel()
    {
        
    }

    public void OpenBagPanel()
    {
        
    }

    public void OpenRankPanel()
    {
        
    }

    public void OpenGiftPanel()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
