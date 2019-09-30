using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Events;

public class MainPanel : MonoBehaviour
{
    [HideInInspector]
    public GameObject startBtn, achievementBtn, missionBtn, settingBtn, shopBtn, bagBtn, rankBtn, giftBtn,levelBtn;

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
    [HideInInspector]
    public bool levelBtnSwitch = true;

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
        EventTriggerListener.Get(levelBtn).onClick += OpenPanelBtnHandler;

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
                UIPanelMenu.GetInstance().PlayGame();
                SoundManager.Instance.PlaySound(0);
                break;
            case "achievementBtn":
                UIPanelMenu.GetInstance().OpenAchievementPanel();
                SoundManager.Instance.PlaySound(1);
                break;
            case "missionBtn":
                UIPanelMenu.GetInstance().OpenMissionPanel();
                SoundManager.Instance.PlaySound(2);
                break;
            case "settingBtn":
                UIPanelMenu.GetInstance().OpenSettingPanel();
                SoundManager.Instance.PlaySound(3);
                break;
            case "shopBtn":
                UIPanelMenu.GetInstance().OpenShopPanel();
                break;
            case "bagBtn":
                UIPanelMenu.GetInstance().OpenBagPanel();
                break;
            case "rankBtn":
                UIPanelMenu.GetInstance().OpenRankPanel();
                break;
            case "giftBtn":
                UIPanelMenu.GetInstance().OpenGiftPanel();
                break;
            case "levelBtn":
                UIPanelMenu.GetInstance().OpenLevelPanel();
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Q))
        {
            MaskFocus.GetInstance().FocusUI(new UIBehaviour[] { startBtn.GetComponent<Button>() }, 10, true);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            MaskFocus.GetInstance().FocusUI(new UIBehaviour[] { achievementBtn.GetComponent<Button>() }, 10, true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            MaskFocus.GetInstance().FocusUI(new UIBehaviour[] { missionBtn.GetComponent<Button>() }, 10, true);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            MaskFocus.GetInstance().FocusUI(new UIBehaviour[] { settingBtn.GetComponent<Button>() }, 10, true);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            MaskFocus.GetInstance().FocusUI(new UIBehaviour[] { rankBtn.GetComponent<Button>() }, 10, true);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            MaskFocus.GetInstance().FocusUI(new UIBehaviour[] { giftBtn.GetComponent<Button>() }, 10, true);
        }

    }
}
