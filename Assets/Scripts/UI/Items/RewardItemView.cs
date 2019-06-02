using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardItemView : BaseItemView
{
    #region 组件声明
    //public Image ItemImg;
    //public Image BgImg;
    //public Image CheckImg;
    //public Image LockImg;
    //public Image SignImg;
    //public Image RedImg;
    //public Text NameText;
    //public Text ValueText;
    #endregion

    //public BaseItem itemData;

   // public int Index { get; set; }

    private void Awake()
    {
        #region 声明赋值

        /*ItemImg = transform.Find("ItemImg").GetComponent<Image>();
        BgImg = GetComponent<Image>();
        CheckImg = transform.Find("Check").GetComponent<Image>();
        LockImg = transform.Find("Lock").GetComponent<Image>();
        SignImg = transform.Find("Sign").GetComponent<Image>();
        RedImg = transform.Find("Red").GetComponent<Image>();
        NameText = transform.Find("Name").GetComponent<Text>();
        ValueText = transform.Find("Value").GetComponent<Text>();*/

        #endregion
        
    }

    public override void Start()
    {
        base.Start();
        Sprite _sprite= UIResourceManager.Instance.spriteArr[Index];
        ItemImg.sprite = _sprite;
        NameText.text = Index.ToString();
        UpdateState();
    }

    public override void ClickHandle()
    {
        base.ClickHandle();
    }
    

    public override void UpdateState()
    {
        base.UpdateState();
    }
    



    public override void Update ()
    {
        base.Update();
	}
}
