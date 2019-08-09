using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpiralMotion : MonoBehaviour
{
    public SpiralInstance mathTool;
    public float angle { get; set; }
    private float radius = 0;
    private float _x = 0;
    private float _y = 0;
    public float high { get; set; }
    private bool isMove = false;

    // Start is called before the first frame update
    void Start()
    {
        float r = UnityEngine.Random.Range(0f, 1f);
        float g = UnityEngine.Random.Range(0f, 1f);
        float b = UnityEngine.Random.Range(0f, 1f);
        Color color = new Color(r, g, b);
        GetComponent<Renderer>().material.SetColor("_Color", color);
        GetComponent<Renderer>().material.SetColor("_EmissionColor", color);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            isMove = true;
        }

        if(isMove)
        {
            radius = mathTool.a + mathTool.b * angle;
            _x = radius * Mathf.Cos(angle);
            _y = radius * Mathf.Sin(angle);
            angle += 0.02f;
            high += 0.1f;
            transform.localPosition = new Vector3(_x, 0, _y);
            if (angle > 200) angle = 0;
            if (high > 100) high = 0;
        }
        
    }
}
