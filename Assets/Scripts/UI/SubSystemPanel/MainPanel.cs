using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    public GameObject startBtn;
    public GameObject achievementBtn;
    public GameObject missionBtn;
    public GameObject settingBtn;
    public GameObject shopBtn;
    public GameObject bagBtn;
    public GameObject rankBtn;
    public GameObject giftBtn;


    // Start is called before the first frame update
    void Start()
    {
        startBtn.GetComponent<Button>().onClick.AddListener(PlayGame);
        achievementBtn.GetComponent<Button>().onClick.AddListener(OpenAchievementPanel);
        missionBtn.GetComponent<Button>().onClick.AddListener(OpenMissionPanel);
        settingBtn.GetComponent<Button>().onClick.AddListener(OpenSettingPanel);
        shopBtn.GetComponent<Button>().onClick.AddListener(OpenShopPanel);
        bagBtn.GetComponent<Button>().onClick.AddListener(OpenBagPanel);
        rankBtn.GetComponent<Button>().onClick.AddListener(OpenRankPanel);
        giftBtn.GetComponent<Button>().onClick.AddListener(OpenGiftPanel);
    }

    private void PlayGame()
    {
        Debug.Log("PlayGame");
    }

    public void OpenAchievementPanel()
    {
        Debug.Log("OpenAchievementPanel");
    }

    public void OpenMissionPanel()
    {
        Debug.Log("OpenMissionPanel");
    }

    public void OpenSettingPanel()
    {
        Debug.Log("OpenSettingPanel");
    }

    public void OpenShopPanel()
    {
        Debug.Log("OpenShopPanel");
    }

    public void OpenBagPanel()
    {
        Debug.Log("OpenBagPanel");
    }

    public void OpenRankPanel()
    {
        Debug.Log("OpenRankPanel");
    }

    public void OpenGiftPanel()
    {
        Debug.Log("OpenGiftPanel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
