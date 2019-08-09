using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStarsTool : MonoBehaviour
{
    public Sprite[] spriteArray;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeStarColor(int _count,Color _color)
    {
      
        if (_color == null) _color = Color.yellow;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i < _count)
            {
                transform.GetChild(i).GetComponent<Image>().color = _color;
            }
            else
            {
                transform.GetChild(i).GetComponent<Image>().color = Color.white;
            }
        }
    }

    public void SetImageSprite(int _index,int _count)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if(i<_count)
            {
                transform.GetChild(i).GetComponent<Image>().sprite = spriteArray[_index];
            }
            else
            {
                transform.GetChild(i).GetComponent<Image>().sprite = spriteArray[0];
            }
        }
    }
}