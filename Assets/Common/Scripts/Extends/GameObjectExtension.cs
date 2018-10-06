using System;
using UnityEngine;
using UnityEngine.UI;

public static class GameObjectExtension
{
    public static T Get<T>(this GameObject thiz) where T : Component
    {
        T t = thiz.GetComponent<T>();
        if (t == default(T))
            t = thiz.AddComponent<T>();
        return t;
    }

    public static T Get<T>(this GameObject thiz, int childIdx) where T : Component
    {
        return thiz.gameObject.transform.GetChild(childIdx).Get<T>();
    }

    public static T Get<T>(this Transform thiz) where T : Component
    {
        return thiz.gameObject.Get<T>();
    }

    public static T GetChild<T>(this GameObject _trans)
    {
        return _trans.GetComponentInChildren<T>();
    }

    /// <summary>
    /// 重置Transform
    /// </summary>
    public static void Reset(this Transform transform)
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;
    }


    public static void Reset(this GameObject gameobject)
    {
        gameobject.transform.localPosition = Vector3.zero;
        gameobject.transform.localRotation = Quaternion.Euler(Vector3.zero);
        gameobject.transform.localScale = Vector3.one;
    }


    public static void SetGameObjectTransform(this GameObject gameObject, Vector3 _pos, Quaternion _rot, Vector3 _local, bool changePos = true, bool changeRot = true, bool changeLocal = true)
    {
        if (changePos) gameObject.transform.localPosition = _pos;
        if (changeRot) gameObject.transform.localRotation = _rot;
        if (changeLocal) gameObject.transform.localScale = _local;
    }

    public static void SetGameObjectPosition(this GameObject gameObject, Vector3 _pos)
    {
        gameObject.transform.localPosition = _pos;
    }

    public static void SetGameObjectRotation(this GameObject gameObject, Quaternion _rot)
    {
        gameObject.transform.rotation = _rot;
    }

    public static void SetGameObjectScale(this GameObject gameObject, Vector3 _scale)
    {
        gameObject.transform.localScale = _scale;
    }

    public static Vector2 GetAnchorPosition(this GameObject gameObject)
    {
        return GetAnchoredPosition(gameObject.transform);
    }

    public static Vector2 GetAnchorPosition(this Transform transform)
    {
        return GetAnchoredPosition(transform);
    }

    public static Vector3 GetAnchorPosition3D(this Transform transform)
    {
        return new Vector3(GetAnchoredPosition(transform).x, GetAnchoredPosition(transform).y, 0);
    }

    private static Vector2 GetAnchoredPosition(Transform transform)
    {
        if (transform.GetComponent<RectTransform>() == null)
        {
            return Vector2.zero;
        }

        Vector2 vector2 = transform.GetComponent<RectTransform>().anchoredPosition;
        return vector2;
    }

    public static void SetAnchorPosition(this GameObject gameObject, Vector2 vector2)
    {
        SetAnchoredPosition(gameObject.transform, vector2);
    }

    public static void SetAnchorPosition(this Transform transform, Vector2 vector2)
    {
        SetAnchoredPosition(transform, vector2);
    }

    public static void SetAnchorPosition3D(this Transform transform, Vector3 vector3)
    {
        SetAnchoredPosition(transform, vector3);
    }

    private static void SetAnchoredPosition(Transform transform, Vector2 vector2)
    {
        if (transform.GetComponent<RectTransform>() == null)
        {
            return;
        }
        transform.GetComponent<RectTransform>().anchoredPosition = vector2;
    }

    public static void SetAnchoredPosition(Transform transform, Vector3 vector3)
    {
        if (transform.GetComponent<RectTransform>() == null)
        {
            return;
        }
        transform.GetComponent<RectTransform>().anchoredPosition3D = vector3;
    }
    
    /// <summary>
    /// 播放动作
    /// </summary>
    /// <returns>The animator.</returns>
    /// <param name="thiz">Thiz.</param>
    /// <param name="statename">Statename.</param>
    public static GameObject PlayerAnimator(this GameObject thiz, string statename)
    {
        var animators = thiz.GetComponentsInChildren<Animator>();
        for (int i = 0; i < animators.Length; ++i)
        {
            var ani = animators[i];
            if (ani != null)
            {
                ani.Play(statename, 0, 0f);
                ani.Update(0f);
            }
        }
        return thiz;
    }

    public static void OnClick(this GameObject _go, Action _callback)
    {
        //UI点击事件
        _go.GetComponent<Button>().onClick.AddListener(delegate () { _callback(); });
        
    }

    public static void OnClick(this GameObject _go, Action<GameObject> _callback)
    {
        //UI点击事件
        _go.GetComponent<Button>().onClick.AddListener(delegate () { _callback(_go); });
        
    }

    public static void Show(Transform _trans)
    {
        if (!_trans.gameObject.activeSelf)
            _trans.gameObject.SetActive(true);
    }

    public static void Hide(Transform _trans)
    {
        if (_trans.gameObject.activeSelf)
            _trans.gameObject.SetActive(false);
    }

    public static void Show(GameObject _go)
    {
        if (!_go.activeSelf)
            _go.SetActive(true);
    }

    public static void Hide(GameObject _go)
    {
        if (!_go.activeSelf)
            _go.SetActive(false);
    }
}


