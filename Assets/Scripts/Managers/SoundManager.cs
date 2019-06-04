using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 声音管理类
/// 功能：
/// 背景音乐的播放暂停，支持多个背景音乐
/// 音效的播放暂停，通过音效数组的索引来播放指定的音效
/// </summary>
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    private static SoundManager _instance = null;
    private static SoundManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (SoundManager)FindObjectOfType(typeof(SoundManager));
                if (_instance == null)
                {
                    // Create gameObject and add component
                    _instance = (new GameObject("SoundManager")).AddComponent<SoundManager>();
                }
            }
            return _instance;
        }
    }

    public AudioSource musicAS;
    public List<AudioClip> musicList;
    public AudioSource soundAS;
    public List<AudioClip> soundList;

    private void Awake()
    {
        Instance = this;
        if(musicList.Count>0)
        {
            musicAS.clip = musicList[0];
        }
    }

    public void Initialized()
    {
        PlayMusic();
    }

    /// <summary>
    /// 播放默认第一个背景音乐
    /// </summary>
    public void PlayMusic()
    {
        if (GameManagers.GetInstance().IsMusic)
        {
            musicAS.loop = true;
            musicAS.Play();
        }
    }

    /// <summary>
    /// 播放指定索引的背景音乐
    /// </summary>
    /// <param name="_musicNumber">soundList索引</param>
    public void PlayMusic(int _musicNumber)
    {
        if (GameManagers.GetInstance().IsMusic)
        {
            musicAS.loop = false;
            if (_musicNumber < musicList.Count)
            {
                musicAS.clip = soundList[_musicNumber];
                musicAS.Play();
            }
            else
            {
                Debug.LogError("the sound is out of array index");
            }
        }
    }

    /// <summary>
    /// 播放默认的第一个音效
    /// </summary>
    public void PlaySound()
    {

    }

    /// <summary>
    /// 播放指定索引的音效
    /// </summary>
    /// <param name="_soundNumber">soundList索引</param>
    public void PlaySound(int _soundNumber)
    {
        if(GameManagers.GetInstance().IsSound)
        {
            soundAS.loop = false;
            if(_soundNumber<soundList.Count)
            {
                soundAS.clip = soundList[_soundNumber];
                soundAS.Play();
            }
            else
            {
                Debug.LogError("the sound is out of array index");
            }
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    /// <summary>
    /// 暂停所有音乐
    /// </summary>
    public void StopMusic()
    {
        musicAS.Stop();
    }


}
