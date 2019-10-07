using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utility;

public class SettingPanel : BasePanel
{
    public Toggle musicToggle;
    public Toggle soundToggle;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        base.Start();

        SetMusic();
        SetSound();
    }

    public void SetMusic()
    {
        musicToggle.isOn = GameManagers.GetInstance().IsMusic;
        musicToggle.onValueChanged.AddListener((bool isOn) => {
            GameManagers.GetInstance().SetMusicSwitch(isOn);
        });
    }

    public void SetSound()
    {
        soundToggle.isOn= GameManagers.GetInstance().IsSound;
        soundToggle.onValueChanged.AddListener((bool isOn) => {
            GameManagers.GetInstance().SetSoundSwitch(isOn);
        });
    }

    

    protected override void ClosePanelHandle(GameObject go)
    {
        base.ClosePanelHandle(go);
    }


}