using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAlpha 
{

    /// <summary>
    /// alpha渐变从0到1
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public IEnumerator FadeObjectToAlpha(GameObject obj, float t)
    {
        Image image = obj.GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        while (image.color.a < 1.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.r, image.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    /// <summary>
    /// alpha渐变从1到0
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public IEnumerator FadeObjectToZeroAlpha(GameObject obj, float t)
    {
        Image image = obj.GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        while (image.color.a > 0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.r, image.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
