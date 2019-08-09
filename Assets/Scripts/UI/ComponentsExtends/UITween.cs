using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace UIExtension
{
    /// <summary>
    /// 针对UGUI扩展的Tween
    /// </summary>
    public static class UITween
    {
        public static Tweener UIMove(this GameObject _obj, Vector2 _v2, float _duration)
        {
            RectTransform _rect = _obj.GetComponent<RectTransform>();
            return _rect.DOAnchorPos(_v2, _duration);
        }

        public static Tweener UIMove(this Transform _tran, Vector2 _v2, float _duration)
        {
            RectTransform _rect = _tran.GetComponent<RectTransform>();
            return _rect.DOAnchorPos(_v2, _duration);
        }

        public static Tweener UIMove(this RectTransform _rect,Vector2 _v2,float _duration)
        {
            return _rect.DOAnchorPos(_v2, _duration);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_rect"></param>
        /// <param name="_v2"></param>
        /// <param name="_duration"></param>
        /// <param name="_callback"></param>
        /// <param name="_ease"></param>
        public static void UIMove(this RectTransform _rect, Vector2 _v2, float _duration, Action _callback=null,Ease _ease=Ease.Linear)
        {
            _rect.DOAnchorPos(_v2, _duration).SetEase(_ease).OnComplete(() => { _callback?.Invoke(); });
        }

        /// <summary>
        /// 只支持UGUI Image Component组件
        /// </summary>
        /// <param name="_rect"></param>
        /// <param name="_value"></param>
        /// <param name="_duration"></param>
        public static void AlphaFade(this RectTransform _rect,float _value,float _duration)
        {
            _rect.GetComponent<Image>().DOFade(_value, _duration);
        }

        public static void AlphaFade(this Image _image, float _value, float _duration)
        {
            _image.DOFade(_value, _duration);
        }


    }

}



