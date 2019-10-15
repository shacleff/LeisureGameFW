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
        /// 
        /// </summary>
        /// <param name="_rect"></param>
        /// <param name="_v2"></param>
        /// <param name="_duration"></param>
        /// <param name="_callback"></param>
        /// <param name="_ease"></param>
        public static void UIMove(this GameObject _obj, Vector2 _v2, float _duration, Action _callback = null, Ease _ease = Ease.Linear)
        {
            _obj.GetComponent<RectTransform>().DOAnchorPos(_v2, _duration).SetEase(_ease).OnComplete(() => { _callback?.Invoke(); });
        }

        /// <summary>
        /// 透明渐变
        /// 只支持UGUI Image Component组件
        /// </summary>
        /// <param name="_rect">渐变对象</param>
        /// <param name="_value">alpha最终值</param>
        /// <param name="_duration"></param>
        public static void AlphaFade(this RectTransform _image, float _value,float _duration)
        {
            if (_image.GetComponent<Image>() == null) Debug.LogError(string.Format("the GameObject {0} Image Component is null", _image.name));
            _image.GetComponent<Image>().DOFade(_value, _duration);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_image">渐变对象</param>
        /// <param name="_value">alpha最终值</param>
        /// <param name="_duration">渐变时间</param>
        public static void AlphaFade(this Image _image, float _value, float _duration)
        {
            _image.DOFade(_value, _duration);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_image">渐变对象</param>
        /// <param name="_value">alpha最终值</param>
        /// <param name="_duration">渐变时间</param>
        public static void AlphaFade(this GameObject _image,float _value,float _duration)
        {
            if (_image.GetComponent<Image>() == null) Debug.LogError(string.Format("the GameObject {0} Image Component is null", _image.name));
            _image.GetComponent<Image>().DOFade(_value, _duration);
        }

        /// <summary>
        /// 透明渐变
        /// </summary>
        /// <param name="_image">渐变对象</param>
        /// <param name="_value">alpha最终值</param>
        /// <param name="_duration">渐变时间</param>
        /// <param name="_callback">完成回调</param>
        public static void AlphaFade(this Image _image, float _value, float _duration,Action _callback=null)
        {
            _image.DOFade(_value, _duration).OnComplete(()=> { _callback?.Invoke(); });
        }

        /// <summary>
        /// 设置UI 旋转
        /// </summary>
        /// <param name="_rect">旋转对象</param>
        /// <param name="_v2">旋转值（最终rotation）</param>
        /// <param name="_duration">时间</param>
        /// <param name="_callback">完成回调</param>
        /// <returns></returns>
        public static Tweener UIRotation(this GameObject _rect, Vector3 _v2, float _duration, Action _callback = null)
        {
            if(_rect.GetComponent<RectTransform>() == null) Debug.LogError(string.Format("the GameObject {0} Component is null", _rect.name));
            return _rect.GetComponent<RectTransform>().DOLocalRotate(_v2, _duration).SetEase(Ease.InOutCirc).OnComplete(() => { _callback?.Invoke(); });
        }

        /// <summary>
        /// 设置UI 旋转
        /// </summary>
        /// <param name="_rect">旋转对象</param>
        /// <param name="_v2">旋转值（最终rotation）</param>
        /// <param name="_duration">时间</param>
        /// <param name="_callback">完成回调</param>
        public static Tweener UIRotation(this Transform _rect, Vector3 _v2, float _duration, Action _callback = null)
        {
            if (_rect.GetComponent<RectTransform>() == null) Debug.LogError(string.Format("the GameObject {0} Component is null", _rect.name));
            return _rect.GetComponent<RectTransform>().DOLocalRotate(_v2, _duration).SetEase(Ease.InOutCirc).OnComplete(() => { _callback?.Invoke(); });
        }

    }

}



