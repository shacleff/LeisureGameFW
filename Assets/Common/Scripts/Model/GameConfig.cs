using UnityEngine;
using System;

[System.Serializable]
public class GameConfig
{
    public Admob admob;

    [Header("")]
    public int adPeriod;
    
}

[System.Serializable]
public class Admob
{
    [Header("Interstitial")]
    public string androidInterstitial;
    public string iosInterstitial;
    [Header("Banner")]
    public string androidBanner;
    public string iosBanner;
    [Header("Rewarded Video")]
    public string androidRewardedVideo;
    public string iosRewardedVideo;
}
