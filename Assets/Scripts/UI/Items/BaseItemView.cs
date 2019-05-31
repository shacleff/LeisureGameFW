using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseItemView : MonoBehaviour
{
    public Image ItemImg;
    public Image BgImg;
    public Image CheckImg;
    public Image LockImg;
    public Text NameText;
    public Text ValueText;

    public BaseItem itemData;
    public int Index { get; set; }

    // Start is called before the first frame update
    public virtual void Start()
    {
        Sprite _sprite = UIResourceManager.Instance.spriteArr[Index];
        ItemImg.sprite = _sprite;
        NameText.text = Index.ToString();
        GetComponent<Button>().onClick.AddListener(() => ClickHandle());
        UpdateState();
    }

    public virtual void ClickHandle()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void UpdateState()
    {
        bool isBuy = GamePlayerPrefs.IsBuyedItem(Index);
        bool isUnlock = isBuy && GamePlayerPrefs.GetCurrItem() != Index;
        bool isChoose = isBuy && GamePlayerPrefs.GetCurrItem() == Index;

        LockImg.gameObject.SetActive(!isBuy);
        CheckImg.gameObject.SetActive(isChoose);
    }
}
