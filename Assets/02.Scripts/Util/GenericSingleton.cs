using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T inst;

    public static T Inst
    {
        get
        {
            if(inst == null)
            {
                inst =  FindObjectOfType<T>();

                if(inst == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name);
                    inst = obj.AddComponent<T>();
                    DontDestroyOnLoad(obj);
                }
            }

            return inst;
        }
    }

    protected virtual void Awake()
    {
        if(inst == null)
        {
            inst = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if(inst != this)
        {
            Destroy(gameObject);
        }
    }
}
