using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TipBox :MonoBehaviour
{
    public static TipBox Instance;
    public Text msgText;
    private RectTransform rectTrans;
    private bool isLock=false;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowMessage(string str,float _timer=1)
    {
        if (isLock) return;
        gameObject.SetActive(true);
        msgText.text = str;
        isLock = true;
        gameObject.SetAnchorPosition(new Vector2(0, -100));
        rectTrans.DOAnchorPosY(300, _timer).OnComplete(()=> {
            isLock = false;
            gameObject.SetActive(false);
        });
    }

    void Start()
    {
        this.gameObject.SetActive(false);
        rectTrans = gameObject.GetComponent<RectTransform>();
    }


    void Update()
    {
        
    }
}
