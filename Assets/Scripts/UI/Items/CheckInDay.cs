using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CheckInDay : MonoBehaviour
{
    /// <summary>
    /// 每日奖励图片
    /// </summary>
    public Image dayImage;
    /// <summary>
    /// 每日奖励描述
    /// </summary>
    public Text dayDesc;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// 设置每日奖励的图片和描述信息
    /// </summary>
    /// <param name="_daySprite"></param>
    /// <param name="_dayDesc"></param>
    public void SetDayInfo(Sprite _daySprite,string _dayDesc)
    {
        dayImage.sprite = _daySprite;
        dayDesc.text = _dayDesc;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
