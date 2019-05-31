using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : BaseItemView
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
        //Sprite _sprite= DataHandler.GetInstance().ItemSprites[Index];
        //ItemImg.sprite = _sprite;
        //NameText.text = Index.ToString();
        //GetComponent<Button>().onClick.AddListener(() => ClickHandle());
        //UpdateState();
    }

    public override void ClickHandle()
    {
        base.ClickHandle();
    }

    public void SetData()
    {

    }

    public override void UpdateState()
    {
        base.UpdateState();
        //bool isBuy = GamePlayerPrefs.IsBuyedItem(Index);
        //bool isUnlock = isBuy && GamePlayerPrefs.GetCurrItem() != Index;
        //bool isChoose = isBuy && GamePlayerPrefs.GetCurrItem() == Index;

        //LockImg.gameObject.SetActive(!isBuy);
        //CheckImg.gameObject.SetActive(isChoose);
        //SignImg.gameObject.SetActive(isChoose);
    }
    



    public override void Update ()
    {
        base.Update();
	}
}
