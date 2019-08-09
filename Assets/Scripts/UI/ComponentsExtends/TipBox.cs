using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UIExtension;

public class TipBox :MonoBehaviour
{
    public static TipBox Instance;
    public Text msgText;
    private Transform canvasTran;
    private RectTransform rectTrans;
    private bool isLock=false;


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        this.gameObject.SetActive(false);
        rectTrans = gameObject.GetComponent<RectTransform>();
        canvasTran = FindObjectOfType<Canvas>().transform;

       
    }

    public void BaseSetting(string _msg)
    {
        if (isLock) return;
        gameObject.SetActive(true);
        msgText.text = _msg;
        isLock = true;
    }

    public void ShowMessage(string _msg, float _timer=1, Action _callback = null)
    {
        BaseSetting(_msg);
        gameObject.SetAnchorPosition(new Vector2(0, -100));
        
        rectTrans.DOAnchorPosY(300, _timer).OnComplete(() => { _callback?.Invoke(); });
    }

    public void ShowMessage(string _msg, Transform _target,float _timer=1, Action _callback = null)
    {
        Vector2 targetV2 = RectTransformTool.ChildToCanvasCoord(_target, canvasTran);
        BaseSetting(_msg);
        gameObject.SetAnchorPosition(targetV2);
        rectTrans.DOAnchorPosY(300, _timer).OnComplete(() => { _callback?.Invoke(); });
    }

    public void ShowMessage( string _msg,Transform _target,int _offsetY,float _timer=1, Action _callback = null)
    {
        Vector2 targetV2 = RectTransformTool.ChildToCanvasCoord(_target, canvasTran);
        BaseSetting(_msg);
        gameObject.SetAnchorPosition(targetV2);
        rectTrans.DOAnchorPosY(_offsetY, _timer).OnComplete(() => { _callback?.Invoke(); });
    }

    public void ShowMessage(string _msg, Transform _target, Vector2 _offsetV2, float _timer = 1, Action _callback = null)
    {
        Vector2 targetV2 = RectTransformTool.ChildToCanvasCoord(_target, canvasTran);
        BaseSetting(_msg);
        gameObject.SetAnchorPosition(targetV2);
        rectTrans.DOAnchorPos(_offsetV2,_timer).OnComplete(() => { _callback?.Invoke(); });
    }

    public void ShowMessage(string _msg, Vector2 _startV2, Vector2 _endV2, float _timer = 1, Action _callback = null)
    {
        BaseSetting(_msg);
        gameObject.SetAnchorPosition(_startV2);
        rectTrans.DOAnchorPos(_endV2, _timer).OnComplete(() => { _callback?.Invoke(); });
    }

    public void ShowMessage(string _msg, Transform _startTrans, Transform _endTrans, float _timer = 1, Action _callback=null)
    {
        Vector2 startV2 = RectTransformTool.ChildToCanvasCoord(_startTrans, canvasTran);
        Vector2 endV2 = RectTransformTool.ChildToCanvasCoord(_endTrans, canvasTran);
        BaseSetting(_msg);
        gameObject.SetAnchorPosition(startV2);
        rectTrans.DOAnchorPos(endV2, _timer).OnComplete(()=> { _callback?.Invoke(); });
    }

    public void MovingComplete()
    {
        isLock = false;
        gameObject.SetActive(false);
    }

    public void MovingComplete(Action _callback)
    {
        isLock = false;
        gameObject.SetActive(false);
        _callback?.Invoke();
    }

    void Update()
    {
        
    }
}
