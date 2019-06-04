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

    public override void Freeze()
    {
        base.Freeze();
    }

    public override void Hide()
    {
        base.Hide();
    }

    public override void ReShow()
    {
        base.ReShow();
    }

    public override void Show()
    {
        base.Show();
    }

    

    protected override void ClosePanelHandle(GameObject go)
    {
        base.ClosePanelHandle(go);
    }



    void Update()
    {

    }
}