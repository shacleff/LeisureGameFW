using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpiralInstance : MonoBehaviour
{
    public GameObject obj;
    /// <summary>
    /// 改变螺线形状
    /// </summary>
    public float a = 1;
    /// <summary>
    /// 螺线间距离
    /// </summary>
    public float b = 1;
    public static float angleOffset = 0.2f;
    public static bool isMove = false;

    // Start is called before the first frame update
    void Start()
    {
        //r=a*e^(b*angle)
        float angle = 0;
        
        for (int i = 0; i < 1000; i++)
        {
            
            //float _r = a * Mathf.Pow((float)Math.E, b * angle);
            float _r = a +b*angle;
            float _x = _r * Mathf.Cos(angle);
            float _y = _r * Mathf.Sin(angle);
            float _high = 0.1f*i;
            angle += angleOffset;
            //_x=float.Parse(_x.ToString("0.00"));
            //_y=float.Parse(_y.ToString("0.00"));
            Debug.Log(string.Format("i:{0},r:{1},_x:{2},_y:{3},angle:{4}",(i+1), _r, _x, _y,angle));
            GameObject obj1 = Instantiate(obj);
            obj1.transform.localPosition = new Vector3(_x, 0, _y);
            obj1.GetComponent<SpiralMotion>().angle = angle;
            //obj1.GetComponent<SpiralMotion>().high = _high;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
