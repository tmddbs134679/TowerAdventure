using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T inst;

    private static bool isShuttingDown = false;     //싱글톤 자동생성 코드에서 게임 종료 할 때 자동생성 되는거 flag
    public static T Inst
    {
        get
        {
           
            if (isShuttingDown) return null;

            if (inst == null)
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

    private void OnApplicationQuit()
    {
        isShuttingDown = true;
    }

}
