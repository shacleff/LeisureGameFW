using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 我的做法是每个界面的最上层都是一个横纵Stretch自动拉伸的，检测当发现是iPhoneX时，打开界面代码中自动设置 Left Top Right Bottom 为44.
/// link:https://www.xuanyusong.com/archives/4464
/// </summary>
public class AdaptiveIphoneX : MonoBehaviour
{

    /// <summary>
    /// 自适应iPhoneX
    /// </summary>
    /// <param name="canvas">Canvas.</param>
    private void OpeniPhoneX(Canvas canvas)
    {

#if UNITY_IPHONE
			if (Screen.width == 2436 && Screen.height == 1125){
				RectTransform rectTransform = (canvas.transform as RectTransform);
				rectTransform.offsetMin = new Vector2(44f,0f);
				rectTransform.offsetMax = new Vector2(-44f,0f);
			}
#endif
    }



}

/// <summary>
/// 自适应iPhoneX背景
/// </summary>
public class UIRectLayout
{
#if UNITY_IPHONE
	void Awake () {
		if (Screen.width == 2436 && Screen.height == 1125) {
			AspectRatioFitter aspectRatioFitter = GetComponent<AspectRatioFitter> ();
			if (aspectRatioFitter) {
				aspectRatioFitter.aspectRatio = 2.165333f;
			} else {
				RectTransform rectTransform = transform as RectTransform;
				if (rectTransform.anchorMax.x == 1f) {
					rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x - 44f,rectTransform.offsetMin.y);
					rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x +44f,rectTransform.offsetMax.y);
				}
			}
		}
	}
#endif
}
