using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelMenu : MonoSingleton<UIPanelMenu>
{
    public Transform uiPanelParent;
    public GameObject mainPanel;
    public GameObject achivevementPanel;
    public GameObject bagPanel;
    public GameObject giftPanel;
    public GameObject gameOverPanel;
    public GameObject gamingPanel;
    public GameObject levelSelectPanel;
    public GameObject missionPanel;
    public GameObject rankPanel;
    public GameObject settingPanel;
    public GameObject settlementPanel;
    public GameObject shopPanel;
    public GameObject pausePanel;

    private void Awake()
    {
        foreach (Transform uiPanel in uiPanelParent)
        {
            if (uiPanel.gameObject.name != "MainPanel" && uiPanel.GetComponent<BasePanel>()!=null) uiPanel.gameObject.SetActive(false);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OpenPanel(UIPanelID uIPanelID)
    {
        switch (uIPanelID)
        {
            case UIPanelID.AchievementPanel:
                OpenAchievementPanel();
                break;
            case UIPanelID.BagPanel:
                OpenBagPanel();
                break;
            case UIPanelID.GiftPanel:
                OpenGiftPanel();
                break;
            case UIPanelID.GameOverPanel:
                OpenGameOverPanel();
                break;
            case UIPanelID.GamingPanel:
                PlayGame();
                break;
            case UIPanelID.LevelSelectPanel:
                OpenSelectPanel();
                break;
            case UIPanelID.MissionPanel:
                OpenMissionPanel();
                break;
            case UIPanelID.RankPanel:
                OpenRankPanel();
                break;
            case UIPanelID.MainPanel:
                OpenMainPanel();
                break;
            case UIPanelID.SettingPanel:
                OpenSettingPanel();
                break;
            case UIPanelID.SettlementPanel:
                OpenSettlementPanel();
                break;
            case UIPanelID.ShopPanel:
                OpenShopPanel();
                break;
            case UIPanelID.PausePanel:
                OpenPausePanel();
                break;
            case UIPanelID.Other:

                break;
            default:
                break;
        }
    }

    

    public void OpenMainPanel()
    {
        Debug.Log("OpenMainPanel");

    }

    public void PlayGame()
    {
        Debug.Log("PlayGame");
        gamingPanel.SetActive(true);
    }

    public void OpenGameOverPanel()
    {
        Debug.Log("OpenGameOverPanel");
        gameOverPanel.SetActive(true);
    }

    public void OpenSelectPanel()
    {
        Debug.Log("OpenSelectPanel");
        levelSelectPanel.SetActive(true);
    }

    public void OpenAchievementPanel()
    {
        Debug.Log("OpenAchievementPanel");
        achivevementPanel.SetActive(true);
    }

    public void OpenMissionPanel()
    {
        Debug.Log("OpenMissionPanel");
        missionPanel.SetActive(true);
    }

    public void OpenSettingPanel()
    {
        Debug.Log("OpenSettingPanel");
        settingPanel.SetActive(true);
    }

    public void OpenShopPanel()
    {
        Debug.Log("OpenShopPanel");
        shopPanel.SetActive(true);
    }

    public void OpenBagPanel()
    {
        Debug.Log("OpenBagPanel");
        bagPanel.SetActive(true);
    }

    public void OpenLevelPanel()
    {
        Debug.Log("OpenLevelPanel");
        levelSelectPanel.SetActive(true);
    }

    public void OpenRankPanel()
    {
        Debug.Log("OpenRankPanel");
        rankPanel.SetActive(true);
    }

    public void OpenGiftPanel()
    {
        Debug.Log("OpenGiftPanel");
        giftPanel.SetActive(true);
    }

    public void OpenSettlementPanel()
    {
        Debug.Log("OpenSettlementPanel");
        settlementPanel.SetActive(true);
    }

    public void OpenPausePanel()
    {
        Debug.Log("OpenPausePanel");
        pausePanel.SetActive(true);
    }

    public void ClosePanel(UIPanelID uiPanel)
    {

    }

}
