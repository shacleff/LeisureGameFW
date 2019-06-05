using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManagers : MonoSingleton<GameManagers>
{
    public GameStatus gameStatus { get; set; }

    public bool IsMusic { get; private set; }
    public bool IsSound { get; private set; }

    public int Coin { get; set; }
    public int Gem { get; set; }

    private void Awake()
    {
        this.IsMusic=CPlayerPrefs.GetBool(PrefKeys.MUSIC_ON,true);
        this.IsSound = CPlayerPrefs.GetBool(PrefKeys.SOUND_ON, true);
        this.Coin = CPlayerPrefs.GetInt(PrefKeys.TOTAL_COIN, GlobalProperties.DEFAULT_COIN);
        this.Gem = CPlayerPrefs.GetInt(PrefKeys.TOTAL_GEM, GlobalProperties.DEFAULT_GEM);

        string personalDataJson = CPlayerPrefs.GetString(PrefKeys.GAME_PERSONAL_DATA);
        Debug.Log("personale: "+personalDataJson);
        if(personalDataJson=="" || string.IsNullOrEmpty(personalDataJson))
        {
            PersonalData p = new PersonalData();
            p.SetLevel(4);
            p.SetName("joehuang");
            
            //CPlayerPrefs.SetString(PrefKeys.GAME_PERSONAL_DATA, JsonHelper.Serialize(p));
        }
    }

    // Use this for initialization
    void Start()
    {
        SoundManager.Instance.Initialized();

        gameStatus = GameStatus.IDLE;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        gameStatus = GameStatus.GAMING;
    }
    

    public void GameOver()
    {
        gameStatus = GameStatus.GAMOVER;
    }

    public void GameReward()
    {

    }

    public void AddCoin(int _addNumber)
    {
        this.Coin += _addNumber;
        CPlayerPrefs.SetInt(PrefKeys.TOTAL_COIN, this.Coin);
        EventManager.Instance.DispatchEvent(EventArg.COIN_CHANGE, this.Coin.ToString());
    }

    public void ReduceCoin(int _reduceNumber)
    {
        this.Coin -= _reduceNumber;
        CPlayerPrefs.SetInt(PrefKeys.TOTAL_COIN, this.Coin);
        EventManager.Instance.DispatchEvent(EventArg.COIN_CHANGE, this.Coin.ToString());
    }

    public void AddGem(int _addNumber)
    {
        this.Gem += _addNumber;
        CPlayerPrefs.SetInt(PrefKeys.TOTAL_GEM, this.Gem);
        EventManager.Instance.DispatchEvent(EventArg.GEM_CHANGE, this.Gem.ToString());
    }

    public void ReduceGem(int _reduceNumber)
    {
        this.Gem -= _reduceNumber;
        CPlayerPrefs.SetInt(PrefKeys.TOTAL_GEM, this.Gem);
        EventManager.Instance.DispatchEvent(EventArg.GEM_CHANGE, this.Gem.ToString());
    }

    /// <summary>
    /// 设置背景音乐开关
    /// </summary>
    /// <param name="isOn"></param>
    public void SetMusicSwitch(bool isOn)
    {
        CPlayerPrefs.SetBool(PrefKeys.MUSIC_ON, isOn);
        this.IsMusic = CPlayerPrefs.GetBool(PrefKeys.MUSIC_ON);
        if (this.IsMusic)
        {
            SoundManager.Instance.PlayMusic();
        }
        else
        {
            SoundManager.Instance.StopMusic();
        }
        Debug.Log("switch music on:" + this.IsMusic);
    }

    /// <summary>
    /// 设置音效开关
    /// </summary>
    /// <param name="isOn"></param>
    public void SetSoundSwitch(bool isOn)
    {
        CPlayerPrefs.SetBool(PrefKeys.SOUND_ON, isOn);
        this.IsSound = CPlayerPrefs.GetBool(PrefKeys.SOUND_ON);
        Debug.Log("switch sound on:" + this.IsSound);
    }
}


