/**
 * 
 * Author:JoeyHuang
 * Time: 2019/10/15 11:58:56
 * 说明：
 */

using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ObjectPool<T> : IObjectPool<T>
{
    public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public Type ObjectType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int Count { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public ObjectPool(string _name)
    {

    }

    public void Release(T _obj)
    {
        throw new NotImplementedException();
    }

    public void ReleaseAll()
    {
        throw new NotImplementedException();
    }

    public T Spawn()
    {
        throw new NotImplementedException();
    }

    public void UnSpawn(T _obj)
    {
        throw new NotImplementedException();
    }

}

public class ObjectPool : IObjectPool
{
    public string Name { get ; set ; }
    public Type ObjectType { get { return typeof(GameObject); } set { value = typeof(GameObject); } }
    public int MaxCount { get ; set ; }
    public int PreCount { get ; set ; }
    public int SpawnCount { get ; set ; }

    public Queue<GameObject> ObjList=new Queue<GameObject>();

    public ObjectPool(string _name)
    {
        this.Name = _name;
    }

    public ObjectPool(string _name, GameObject _prefab) : this(_name)
    {

    }

    public ObjectPool(string _name, GameObject _prefab, Transform _parent, int _preCount, int _maxCount=0) : this(_name)
    {
        SpawnCount = 0;
        this.PreCount = _preCount;
        this.MaxCount=_maxCount== 0 ? PreCount : _maxCount;
        CreatePool(_prefab, _parent, Vector3.zero, Quaternion.identity, Vector3.one, PreCount);
    }

    public ObjectPool(string _name, GameObject _prefab, Transform _parent, Vector3 _pos, Quaternion _rot, Vector3 _scale, int _preCount,int _maxCount=0) : this(_name)
    {
        SpawnCount = 0;
        this.PreCount = _preCount;
        this.MaxCount = _maxCount == 0 ? PreCount : _maxCount;
        CreatePool(_prefab, _parent, _pos, _rot, _scale,PreCount);
    }

    public void CreatePool(GameObject _prefab,Transform _parent,Vector3 _pos,Quaternion _rot,Vector3 _scale,int _count)
    {
        GameObject _obj = null;
        SpawnCount = 0;
        for (int i = 0; i < _count; i++)
        {
            _obj = Instantiate(_prefab, _parent, _pos, _rot, _scale);
            ObjList.Enqueue(_obj);
        }
    }

    public GameObject Instantiate(GameObject _obj)
    {
        return Instantiate(_obj, _obj.transform.parent, _obj.transform.localPosition,_obj.transform.localRotation,_obj.transform.localScale);
    }

    public GameObject Instantiate(Transform _obj)
    {
        return Instantiate(_obj.gameObject, _obj.parent, _obj.localPosition, _obj.localRotation, _obj.localScale);
    }

    public GameObject Instantiate(GameObject _prefab, Transform _parent, Vector3 _pos, Quaternion _rot, Vector3 _scale)
    {
        GameObject _obj = GameObject.Instantiate(_prefab);
        _obj.name = _prefab.name;
        _obj.transform.localPosition = _pos;
        _obj.transform.localRotation = _rot;
        _obj.transform.localScale = _scale;
        _obj.transform.SetParent(_parent);
        return _obj;
    }

    public object Spawn()
    {
        if(SpawnCount>=MaxCount) Debug.LogError("The Object Pool Count is 0");
        if(SpawnCount>=PreCount-1)
        {
            //如果一开始预备的对象已经没有了，就多创建一个
            ObjList.Enqueue(Instantiate(ObjList.Peek()));
        }
        GameObject _obj = ObjList.Dequeue();
        SpawnCount++;
        _obj.SetActive(true);
        return _obj;
    }

    public void UnSpawn(GameObject _obj)
    {
        if(ObjList.Count<MaxCount)
        {
            _obj.SetActive(false);
            SpawnCount--;
            ObjList.Enqueue(_obj);
        }
        
    }

    public void Release()
    {

    }

    public void ReleaseAll()
    {
        for (int i = ObjList.Count - 1; i >= 0; i--)
        {
            //GameObject.Destroy(ObjList[i]);
        }
        ObjList.Clear();
    }

}
