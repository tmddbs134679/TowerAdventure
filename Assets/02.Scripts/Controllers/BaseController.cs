using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{

    
    private void Awake()
    {
        Init();
    }

    void Start()
    {
        
    }


    bool _init = false;

    public virtual bool Init()
    {
        if (_init)
            return false;

        _init = true;
        return true;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
