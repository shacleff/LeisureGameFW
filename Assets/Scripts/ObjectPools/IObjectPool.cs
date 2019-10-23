using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IObjectPool
{
    string Name { set; get; }
    Type ObjectType { set; get; }
    int MaxCount { set; get; }
    int PreCount { set; get; }
    int SpawnCount { set; get; }
    GameObject Spawn();
    void UnSpawn(GameObject _obj);
    void Release();
    void ReleaseAll();

}

public interface IObjectPool<T>
{
    string Name { set; get; }
    Type ObjectType { set; get; }
    int Count { set; get; }
    T Spawn();
    void UnSpawn(T _obj);
    void Release(T _obj);
    void ReleaseAll();
}
