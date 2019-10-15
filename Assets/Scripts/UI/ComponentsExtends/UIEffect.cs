using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;
using UIExtension;


public static class UIEffect 
{

    /// <summary>
    /// 震动效果
    /// 缩放的同时旋转UI
    /// </summary>
    /// <param name="obj"></param>
    public static void Snake(this GameObject obj)
    {
        DOTween.KillAll();
        TimerManager.StopCoroutine();
        //TimerManager.Instance.StopAllCoroutines();
        if (obj == null)
        {
            // DelayTimer.Instance.StopAllCoroutines();
            return;
        }
        obj.transform.localScale = Vector3.one;

        obj.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 1.0f / 12.0f).OnComplete(() => {

            TimerManager.Schedule(1.0f / 12.0f, () =>
            {
                if (obj != null) obj.transform.DOScale(Vector3.one, 1.0f / 12.0f);
            });
        });
        obj.transform.DOLocalRotate(new Vector3(0, 0, -6), 1.0f / 12.0f).OnComplete(() => {
            obj.transform.DOLocalRotate(new Vector3(0, 0, 6), 1.0f / 12.0f).OnComplete(() => {
                obj.transform.DOLocalRotate(new Vector3(0, 0, 0), 1.0f / 12.0f).OnComplete(() => {
                    TimerManager.Schedule(1.5f, () =>
                    {
                        if (obj != null) obj.Snake();
                    });
                });
            });
        });
    }

    /// <summary>
    /// 加金币效果，现在中间放大，然后散开，然后聚集到金币UI上消失
    /// </summary>
    /// <param name="_coin"></param>
    /// <param name="_coinPrefab"></param>
    /// <param name="_parent"></param>
    /// <param name="_target"></param>
    /// <param name="_completed"></param>
    public static void ShowCoinEffect(int _coin,GameObject _coinPrefab,Transform _parent,Transform _target, Action _completed = null)
    {
        _coin = Mathf.Min(_coin, 40);

        //int size = Random.Range(5, 40);
        for (int i = 0; i < 10; i++)
        {
            GameObject _effect = GameObject.Instantiate(_coinPrefab, _parent); //coinPrefab.Spawn(parent);
            int _r = UnityEngine.Random.Range(100, 210);
            int _angle = UnityEngine.Random.Range(0, 360);
            float _x = _r * Mathf.Sin(_angle);
            float _y = _r * Mathf.Cos(_angle);
            // _effect.SetAnchorPosition(new Vector2(_x,_y));
            _effect.UIMove(new Vector2(_x, _y), 0.5f, () => {
                _effect.UIMove(RectTransformTool.ChildToCanvasCoord(_target, _parent), 0.3f, () => {
                    if (i == 10)
                    {
                        GameObject.Destroy(_effect);
                    }

                });
            });
        }
        APP.GetInstance().StartCoroutine(Complete(_completed));

    }

    static IEnumerator Complete(Action _completed = null)
    {
        yield return new WaitForSeconds(1.0f);
        _completed?.Invoke();
    }

}
