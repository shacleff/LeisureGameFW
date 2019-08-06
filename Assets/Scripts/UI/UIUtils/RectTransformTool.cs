using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RectTransformTool 
{
    public static readonly int ReferenceResolutionW=720;
    public static readonly int ReferenceResolutionH=1280;

    /// <summary>
    /// UI子对象的坐标转换为已Canvas为父对象的坐标
    /// </summary>
    /// <param name="child"></param>
    /// <returns></returns>
    public static Vector2 ChildToCanvasCoord(Transform child, Transform canvas=null)
    {
        if (canvas == null) canvas = Object.FindObjectOfType<Canvas>().transform;
        RectTransform canvasRectTrans = canvas.GetComponent<RectTransform>();
        Vector2 _screenPoint = Vector2.zero;
        Camera camera = canvasRectTrans.GetComponent<Canvas>().worldCamera;

        Vector2 local;
        if (canvasRectTrans.GetComponent<Canvas>().renderMode == RenderMode.ScreenSpaceOverlay)
        {
            _screenPoint = child.position;
            camera = null;
        }
        else
        {
            _screenPoint = Camera.main.WorldToScreenPoint(child.position);
            camera = canvasRectTrans.GetComponent<Canvas>().worldCamera;
        }
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTrans, _screenPoint, camera, out local))
        {
            return local;
        }

        return new Vector2(0, 0);
    }

    /// <summary>
    /// 已左下角为中心的鼠标点转换为中心点在屏幕的坐标系统
    /// </summary>
    /// <returns></returns>
    public static Vector2 MousePointToCanvasPoint(Transform _child)
    {
        Debug.Log("ChildToCanvasCoord behind: " + _child.GetComponent<RectTransform>().anchoredPosition);   
        Vector2 V1 = ChildToCanvasCoord(_child);
        Vector2 V3 = Input.mousePosition;
        Debug.Log("ChildToCanvasCoord: "+V1+",V3: "+V3);
        Vector2 targetV = new Vector2(V3.x - ReferenceResolutionW / 2, V3.y - ReferenceResolutionH / 2);

        return V1;
    }
}
