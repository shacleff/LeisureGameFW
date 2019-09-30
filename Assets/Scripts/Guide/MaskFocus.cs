using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[ExecuteInEditMode]
public class MaskFocus : MonoSingleton<MaskFocus>
{
    public Camera cam;
    Material material;
    Vector2 targetPos;
    Vector2 smoothPos;
    float targetRadius;
    float smoothRadius;
    Vector4 parameters;

    private void Awake()
    {
        material = GetComponent<Image>().material;

        targetPos = new Vector2(Screen.width / 2, Screen.height / 2);
        smoothPos = targetPos;
        targetRadius = Screen.height;
        smoothRadius = targetRadius;

        if (material != null)
        {
            UpdateParameters();
        }
       
    }


    public void Clear(bool instant = false)
    {
        targetPos = new Vector2(Screen.width / 2, Screen.height / 2);
        targetRadius = Screen.height;

        if (instant)
        {
            smoothPos = targetPos;
            smoothRadius = targetRadius;
            UpdateParameters();
        }
    }

    public void Close(bool position = false, bool instant = false)
    {
        if (position)
            targetPos = new Vector2(Screen.width / 2, Screen.height / 2);

        targetRadius = 0f;

        if (instant)
        {
            if (position)
                smoothPos = targetPos;

            smoothRadius = targetRadius;
            UpdateParameters();
        }
    }

    public Vector3 ScreenPoint()
    {
        return targetPos;
    }

    const float posRate = 10f;
    const float radRate = 10f;
    bool updateParams;
    private void Update()
    {
        if (!Application.isPlaying)
            return;

        /*
        if (Input.GetMouseButtonDown(0))
        {
            SetPosition(Input.mousePosition, false);
            SetRadius(Random.Range(40f, 120));
        }
        */

        if (material != null)
        {
            updateParams = false;

            if (smoothPos != targetPos)
            {
                smoothPos = Vector2.Lerp(smoothPos, targetPos, posRate * Time.deltaTime);
                //smoothPos = Vector2.MoveTowards(smoothPos, targetPos, posRate * (float)Screen.height * Time.deltaTime);
                updateParams = true;
            }

            if (smoothRadius != targetRadius)
            {
                smoothRadius = Mathf.Lerp(smoothRadius, targetRadius, radRate * Time.deltaTime);
                //smoothRadius = Mathf.MoveTowards(smoothRadius, targetRadius, radRate * (float)Screen.height * Time.deltaTime);
                updateParams = true;
            }

            if (updateParams)
            {
                UpdateParameters();
            }
        }
    }

    const int borderMargin = 10;
    public void FocusUI(IEnumerable<UIBehaviour> uis, float radiusMultiplier = 1f, bool instant = false)
    {
        if (uis == null)
            return;

        List<Vector3> allCorners = new List<Vector3>();
      //  Camera cam;
        RectTransform rTrans;
        foreach (UIBehaviour ui in uis)
        {
           // cam = ui.GetComponentInParent<Canvas>().worldCamera;

            if (cam != null)
            {
                rTrans = ui.GetComponent<RectTransform>();

                if (rTrans == null)
                    continue;

                Vector3[] corners = new Vector3[4];
                rTrans.GetWorldCorners(corners);

                for (int i = 0; i < corners.Length; i++)
                    corners[i] = cam.WorldToScreenPoint(corners[i]);

                allCorners.AddRange(corners);
            }
            else
                throw new System.NotImplementedException();
        }

        if (allCorners.Count == 0)
            return;

        for (int i = 0; i < allCorners.Count; i++)
        {
            if (allCorners[i].x < borderMargin)
                allCorners[i] = new Vector3(borderMargin, allCorners[i].y, allCorners[i].z);
            else if (allCorners[i].x > Screen.width - borderMargin)
                allCorners[i] = new Vector3(Screen.width - borderMargin, allCorners[i].y, allCorners[i].z);

            if (allCorners[i].y < borderMargin)
                allCorners[i] = new Vector3(allCorners[i].x, borderMargin, allCorners[i].z);
            else if (allCorners[i].y > Screen.height - borderMargin)
                allCorners[i] = new Vector3(allCorners[i].x, Screen.height - borderMargin, allCorners[i].z);
        }

        Vector3 center = Vector3.zero;
        for (int i = 0; i < allCorners.Count; i++)
            center += allCorners[i];
        center /= (float)allCorners.Count;

        float radius = 0f;
        for (int i = 0; i < allCorners.Count; i++)
        {
            radius = Mathf.Max(radius, Vector2.Distance(center, allCorners[i]));
        }

        SetPosition(center, instant);
        SetRadius(radius * radiusMultiplier, instant);
    }

    public void SetPosition(Vector2 pos, bool instant = false)
    {
        targetPos = GetCenteredPosition(pos);

        if (instant)
        {
            smoothPos = targetPos;
            UpdateParameters();
        }
    }

    public void SetRadius(float rad, bool instant = false)
    {
        targetRadius = rad;

        if (instant)
        {
            smoothRadius = targetRadius;
            UpdateParameters();
        }
    }

    Vector2 GetCenteredPosition(Vector2 pos)
    {
        return pos;
        return new Vector2(pos.x - Screen.width / 2, (Screen.height - pos.y) - Screen.height / 2);
    }

    void UpdateParameters()
    {
        parameters.x = smoothPos.x;
        parameters.y = smoothPos.y;
        parameters.z = smoothRadius;
        material.SetVector("_Parameters", parameters);
    }

    public void Activate()
    {
        //Util.Log("Activate");
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
       
        gameObject.SetActive(false);
    }

    public void OnPointerDown(BaseEventData data)
    {
        if(Vector2.Distance(GetCenteredPosition(data.currentInputModule.input.mousePosition), smoothPos) < smoothRadius)
        {
            Debug.Log(data);
        }
        //if (Vector2.Distance(GetCenteredPosition(data.currentInputModule.input.mousePosition), smoothPos) < smoothRadius)
       //     TutorialManager.Instance.OnPointerDown(data);
    }

    public bool IsActive()
    {
        return gameObject.activeSelf;
    }


}
