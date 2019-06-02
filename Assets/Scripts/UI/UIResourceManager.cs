using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// UI资源管理工具，用于更方便的添加UI物品icon或者其他涉及到UI图片的操作
/// </summary>
public class UIResourceManager : MonoBehaviour
{
    public static UIResourceManager Instance;

    public List<Sprite> spriteArr=new List<Sprite>();

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

