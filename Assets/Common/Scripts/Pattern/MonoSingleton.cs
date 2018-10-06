using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    protected static T Instance = null;

    public static T GetInstance()
    {
        if (Instance == null)
        {
            Instance = FindObjectOfType<T>();
            if (FindObjectsOfType<T>().Length > 1)
            {
                return Instance;
            }

            if (Instance == null)
            {
                string instanceName = typeof(T).Name;
                GameObject instanceGameObject = GameObject.Find(instanceName);
                if (instanceGameObject == null)
                    instanceGameObject = new GameObject(instanceName);
                Instance = instanceGameObject.AddComponent<T>();
                DontDestroyOnLoad(instanceGameObject);
            }

        }

        return Instance;
    }

    protected virtual void OnDestroy()
    {
        Instance = null;
    }

}
