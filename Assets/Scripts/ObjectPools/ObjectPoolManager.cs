/**
 * 
 * Author:JoeyHuang
 * Time: 2019/10/15 14:06:03
 * 说明：
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ObjectPoolManager:MonoSingleton<ObjectPoolManager>
{
    private ObjectPoolManager() { }

    private Dictionary<string, ObjectPool> PoolDict = new Dictionary<string, ObjectPool>();


    public void Init()
    {
        //ObjectPool<GameObject> objectPool = new ObjectPool<GameObject>("dd");
    }

    public void InitPool()
    {
        GameObject _pre = new GameObject("UiPool");
        ObjectPool op = new ObjectPool("Pre", _pre, transform, 20);
        PoolDict.Add(op.Name, op);
    }

    public void IncreaseObjectPool(GameObject _prefab, Transform _parent)
    {
        ObjectPool op = new ObjectPool(_prefab.name, _prefab, _parent, 20);
        PoolDict.Add(op.Name, op);
    }

   


}
