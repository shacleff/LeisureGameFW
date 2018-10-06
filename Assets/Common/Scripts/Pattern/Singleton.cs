using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/// <summary>
/// 1、泛型
/// 2、反射
/// 3、抽象
/// 4、命名空间
/// </summary>
public abstract class Singleton<T> where T : Singleton<T>
{
    protected static T Instance = null;

    protected Singleton()
    {

    }

    public static T GetInstance()
    {
        if (Instance == null)
        {
            ConstructorInfo[] constructorInfos = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            //ConstructorInfo: 发现类构造函数的属性，并提供对构造函数元数据的访问权限。
            ConstructorInfo constructorInfo = Array.Find(constructorInfos, c => c.GetParameters().Length == 0);
            if (constructorInfo == null)
                throw new Exception("Non public Constructor is not found");
            Instance = constructorInfo.Invoke(null) as T;

        }

        return Instance;
    }

}