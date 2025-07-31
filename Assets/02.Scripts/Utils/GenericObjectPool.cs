using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObjectPool<T> where T : Component
{
    private readonly T prefab;
    private readonly Queue<T> pool = new Queue<T>();
    private readonly Transform parent;

    private int currentSize;
    public GenericObjectPool(T prefab, Transform parent, int initSize)
    {
        this.prefab = prefab;
        this.parent = parent;

        for(int i =0; i < initSize; i++)
        {
           
            T obj = GameObject.Instantiate(prefab, parent);
            obj.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }
    }


    public T Get()
    {
        // 사이즈 모자르면 PoolSize 2배 증가
        if(pool.Count == 0)
        {
            SizeUpPool(currentSize);
        }

        var obj = pool.Dequeue();
        obj.gameObject.SetActive(true);
        return obj;
    }

    private void SizeUpPool(int currentSize)
    {
        for(int i=0; i < currentSize; i++)
        {
            T obj = GameObject.Instantiate(prefab, parent);
            obj.gameObject.SetActive(true);
            pool.Enqueue(obj);
        }

        currentSize *= 2;
    }

    public void Return(T obj)
    {
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }
}
