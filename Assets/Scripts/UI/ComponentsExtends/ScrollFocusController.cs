using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// 横向滑动聚焦某中心点组件
/// </summary>
public class ScrollFocusController : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    private float[] itemIndexArr = new float[] { 0f, 0.25f, 0.47f, 0.75f, 0.97f };
    public Transform[] GunsTran;
    private float targetPos = 0;
    private bool isDrag = false;
    private ScrollRect scrollRect;
    private float smooth = 10;
    private GameObject CurrSelectedObj;
    private float targetScale = 0;
    private float MaxScale = 0;
    private float proportion = 0;

    private void Awake()
    {
        scrollRect = GetComponent<ScrollRect>();
    }

    void Start()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = true;
        CurrSelectedObj = eventData.selectedObject;
        if (CurrSelectedObj == null) return;
        targetScale = CurrSelectedObj.Get<BaseItemView>().CurrLocalScale.x;
        MaxScale = CurrSelectedObj.transform.localScale.x;
        proportion = (MaxScale - targetScale) / 1.5f;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        CurrSelectedObj = null;
        isDrag = false;
        float posX = scrollRect.horizontalNormalizedPosition;
        int index = 0;
        float offset = Mathf.Abs(itemIndexArr[index] - posX);
        for (int i = 0; i < itemIndexArr.Length; i++)
        {
            float offsetTmp = Mathf.Abs(itemIndexArr[i] - posX);
            if (offsetTmp < offset)
            {
                index = i;
                offset = offsetTmp;
            }
        }
        targetPos = itemIndexArr[index];
        //Debug.Log(scrollRect.horizontalNormalizedPosition);

    }


    void Update()
    {
        if (isDrag == false)
        {
            scrollRect.horizontalNormalizedPosition = Mathf.Lerp(scrollRect.horizontalNormalizedPosition, targetPos, Time.deltaTime * smooth);
        }

        for (int i = 0; i < GunsTran.Length; i++)
        {
            float _distance = transform.position.x - GunsTran[i].transform.position.x;
            if (_distance < 1.5f && _distance > 0)
            {
                Transform _tran = GunsTran[i];
                targetScale = _tran.Get<BaseItemView>().CurrLocalScale.x;
                MaxScale = targetScale + 0.4f;
                proportion = (MaxScale - targetScale) / 1.5f;
                if (_distance > 0)
                {
                    float _current = MaxScale - proportion * _distance;
                    _current = Mathf.Clamp(_current, targetScale, MaxScale);
                    _tran.localScale = new Vector3(_current, _current, 1);

                }

            }
            else if (_distance <= 0 && _distance > -2f)
            {
                MaxScale = GunsTran[i].Get<BaseItemView>().CurrLocalScale.x + 0.4f;
                GunsTran[i].localScale = new Vector3(MaxScale, MaxScale, 1);
            }
            else if (_distance > -3.5f && _distance <= -2f)
            {
                Transform _tran = GunsTran[i];
                targetScale = _tran.Get<BaseItemView>().CurrLocalScale.x;
                MaxScale = targetScale + 0.4f;
                proportion = (MaxScale - targetScale) / 1.5f;
                if (_distance < -2f)
                {
                    float _current = MaxScale + proportion * (_distance + 2);
                    _current = Mathf.Clamp(_current, targetScale, MaxScale);
                    _tran.localScale = new Vector3(_current, _current, 1);
                }
            }

        }
    }


}


