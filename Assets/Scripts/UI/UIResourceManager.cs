using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIResourceManager : MonoBehaviour
{
    public static UIResourceManager Instance;

    public List<Sprite> spriteArr=new List<Sprite>();
    public List<Sprite> spriteArr1
    {
        get
        {
            return spriteArr;
        }
        set
        {
            this.spriteArr = value;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {

    }

    void Update()
    {

    }

}

